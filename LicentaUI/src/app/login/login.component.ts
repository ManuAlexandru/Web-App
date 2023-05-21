import { Component, OnInit } from '@angular/core';
import { NgForm, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { UserModel } from '../module/models/userModel';
import { UserModelService } from '../module/services/userServices/user.service';
import { HttpErrorResponse } from '@angular/common/http';
import { AuthResponse } from '../module/interfaces/AuthResponse';
import { Router } from '@angular/router';
import { NgxPubSubService } from '@pscoped/ngx-pub-sub';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent implements OnInit {
  forData: UserModel = new UserModel();
  myForm: FormGroup;
  errorMessage: string;
  hide: boolean = true;
  constructor(
    public _service: UserModelService,
    public router: Router,
    private fb: FormBuilder,
    private pubsub: NgxPubSubService
  ) {}

  ngOnInit() {
    this.myForm = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
      password: [
        '',
        [
          Validators.required,
          Validators.pattern(
            '^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[$@$!%.*?&])[A-Za-zd$@$!%*?&].{7,15}'
          ),
        ],
      ],
    });
  }

  get getEmail() {
    return this.myForm.get('email');
  }
  get getPassword() {
    return this.myForm.get('password');
  }
  onSubmit() {
    this.forData = this.myForm.value;
    this._service.postUserLogin(this.forData).subscribe({
      next: (res: AuthResponse) => {
        localStorage.setItem('token', res.token);
        this.router.navigateByUrl('profile');
        this._service.invalidLogin = false;
        this.pubsub.publishEvent('login', true);
      },
      error: (err: HttpErrorResponse) => {
        this._service.invalidLogin = true;
        this.errorMessage = err.error.message;
      },
    });
  }
}
