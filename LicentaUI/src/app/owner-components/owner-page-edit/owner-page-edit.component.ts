import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { GenericResponse } from 'src/app/module/interfaces/GenericResponse';
import { NotificationServiceProvider } from 'src/app/module/services/NotificationService';
import { OwnerGymServices } from 'src/app/module/services/ownerGymServices/ownerServices';
import { AuthUser } from 'src/app/module/services/userServices/authUser.service';
import { DialogConfirmationComponent } from 'src/app/shared/dialogs/dialog-confirmation/dialog-confirmation.component';

@Component({
  selector: 'app-owner-page-edit',
  templateUrl: './owner-page-edit.component.html',
  styleUrls: ['./owner-page-edit.component.css'],
})
export class OwnerPageEditComponent implements OnInit {
  containerNr: number = 0;
  constructor(
    private _ownerService: OwnerGymServices,
    private _dialog: MatDialog,
    private _router: Router,
    private _authService: AuthUser,
    private _notificationService: NotificationServiceProvider
  ) {}
  arrow: string = 'arrow_forward_ios';
  ngOnInit(): void {}
  onClick() {
    if (this.arrow == 'arrow_forward_ios') this.arrow = 'arrow_back_ios';
    else this.arrow = 'arrow_forward_ios';
  }
  onClickHome() {
    this.containerNr = 0;
  }
  onClickInformation() {
    this.containerNr = 1;
  }
  onClickImages() {
    this.containerNr = 2;
  }
  onClickTrainers() {
    this.containerNr = 3;
  }
  onClickDelete() {
    const dialogRef = this._dialog.open(DialogConfirmationComponent, {
      data: 'Are you sure you want to delete the page?',
    });
    dialogRef.afterClosed().subscribe((result) => {
      if (result == true) {
        this._ownerService
          .deleteOwnerPage(this._authService.getId())
          .subscribe((response: GenericResponse) => {
            if (response.statusCode == 200) {
              this._notificationService.onSucces(response.message);
              this._router.navigate(['/ownerPage']);
            } else {
              this._notificationService.onFailed(response.message);
            }
          });
      }
    });
  }
}
