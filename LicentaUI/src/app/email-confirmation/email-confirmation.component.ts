import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { GenericResponse } from '../module/interfaces/GenericResponse';
import { UserModelService } from '../module/services/userServices/user.service';
@Component({
  selector: 'app-email-confirmation',
  templateUrl: './email-confirmation.component.html',
  styleUrls: ['./email-confirmation.component.css'],
})
export class EmailConfirmationComponent implements OnInit {
  message: string;
  email: string;
  token: string;
  constructor(
    private rout: ActivatedRoute,
    private _service: UserModelService
  ) {}

  ngOnInit(): void {
    this.rout.queryParams.subscribe((params) => {
      console.log(params.email);
      this._service.putEmailConfirmation(params.email, params.token).subscribe({
        next: (result: GenericResponse) => {
        if(result.statusCode==200)
          this.message=result.message;
          else
          this.message=result.message;
        
        },
        error: (error: GenericResponse) => {
          
          this.message = error.message;
        },
      });
    });
  }
}
