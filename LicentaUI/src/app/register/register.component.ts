import { Component, OnInit } from '@angular/core';
import {
  FormGroup,
  NgForm,
  Validators,
  FormBuilder,
  ReactiveFormsModule,
} from '@angular/forms';
import { AuthResponse } from '../module/interfaces/AuthResponse';
import { GenericResponse } from '../module/interfaces/GenericResponse';
import { UserModel } from '../module/models/userModel';
import { UserModelService } from '../module/services/userServices/user.service';
import { NotificationServiceProvider } from '../module/services/NotificationService';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
})
export class RegisterComponent implements OnInit {
  hide: boolean = true;
  formData: UserModel = new UserModel();
  constructor(
    public _service: UserModelService,
    private _fb: FormBuilder,
    private _notificationService: NotificationServiceProvider,
    private _router: Router
  ) {}
  myForm: FormGroup;

  ngOnInit() {
    this.myForm = this._fb.group({
      firstName: ['', [Validators.required, Validators.pattern('^[a-zA-Z]+$')]],
      lastName: ['', [Validators.required, Validators.pattern('^[a-zA-Z]+$')]],
      email: [
        '',
        [
          Validators.required,
          Validators.pattern('^[a-z0-9._%+-]+@[a-z0-9.-]+\\.[a-z]{2,4}$'),
        ],
      ],
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
  get getlastName() {
    return this.myForm.get('lastName');
  }
  get getfirstName() {
    return this.myForm.get('firstName');
  }

  onSubmit() {
    this.formData = this.myForm.value;
    this._service
      .postUserRegister(this.formData)
      .subscribe((res: GenericResponse) => {
        if (res.statusCode == 200) {
          this._notificationService.onSucces(res.message);
          this._router.navigate(['/auth//login']);
        } else {
          this._notificationService.onFailed(res.message);
        }
      });
  }
}
