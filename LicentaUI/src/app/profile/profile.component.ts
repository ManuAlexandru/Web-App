import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserModelService } from '../module/services/userServices/user.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ProfileNameModel } from '../module/models/ProfileModels/ProfileNameModel';
import { MatDialog } from '@angular/material/dialog';
import { DialogConfirmationComponent } from '../shared/dialogs/dialog-confirmation/dialog-confirmation.component';
import { NotificationServiceProvider } from '../module/services/NotificationService';
import { AuthResponse } from '../module/interfaces/AuthResponse';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css'],
})
export class ProfileComponent implements OnInit {
  userDetails: any;
  hideNewPassword: boolean = true;
  hideCurrentPassword: boolean = true;
  profileForm: FormGroup;
  imageForm: FormGroup;
  nameForm: FormGroup;
  passwordForm: FormGroup;

  avatarFileUrl: any;

  constructor(
    private _router: Router,
    private _service: UserModelService,
    private _fb: FormBuilder,
    private _dialog: MatDialog,
    private _notificationService: NotificationServiceProvider
  ) {}

  ngOnInit(): void {
    this.imageForm = this._fb.group({
      image: [null],
      profileImage: [''],
    });
    this.nameForm = this._fb.group({
      firstName: ['', [Validators.required]],
      lastName: ['', [Validators.required]],
    });
    this.passwordForm = this._fb.group({
      currentPassword: [
        '',
        [
          Validators.required,
          Validators.pattern(
            '^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[$@$!%.*?&])[A-Za-zd$@$!%*?&].{7,15}'
          ),
        ],
      ],
      newPassword: [
        '',
        [
          Validators.required,
          Validators.pattern(
            '^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[$@$!%.*?&])[A-Za-zd$@$!%*?&].{7,15}'
          ),
        ],
      ],
    });
    this.refreshPage();
  }

  get getFirstName() {
    return this.nameForm.get('firstName');
  }

  get getLastName() {
    return this.nameForm.get('lastName');
  }
  get getCurrentPassword() {
    return this.passwordForm.get('currentPassword');
  }

  get getNewPassword() {
    return this.passwordForm.get('newPassword');
  }

  get getImage() {
    return this.imageForm.get('image');
  }

  get getProfileImage() {
    return this.imageForm.get('profileImage');
  }

  onFileChange($event) {
    console.log($event);
  }

  removeAvatar() {
    console.log('remove avatar');
  }

  submitName() {
    const dialogRef = this._dialog.open(DialogConfirmationComponent, {
      data: 'Are you sure you want to change your name?',
    });
    dialogRef.afterClosed().subscribe((response) => {
      if (response) {
        this._service
          .postUserName(this.nameForm.value)
          .subscribe((response) => {
            if (response.statusCode == 200)
              this._notificationService.onSucces(response.message);
            else this._notificationService.onFailed(response.message);
            this.refreshPage();
          });
      }
    });
  }

  submitPassword() {
    const dialogRef = this._dialog.open(DialogConfirmationComponent, {
      data: 'Are you sure you want to change your password?',
    });
    dialogRef.afterClosed().subscribe((response) => {
      if (response) {
        this._service
          .postUserPassword(this.passwordForm.value)
          .subscribe((response) => {
            if (response.statusCode == 200)
              this._notificationService.onSucces(response.message);
            else this._notificationService.onFailed(response.message);
            this.refreshPage();
          });
      }
    });
  }

  refreshPage() {
    this._service.getUserProfile().subscribe((res) => {
      this.userDetails = res;
      this.nameForm.patchValue(res);
    });
  }
}
