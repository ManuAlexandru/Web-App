import { Component, DoCheck, OnInit } from '@angular/core';
import { Route, Router } from '@angular/router';
import { NgxPubSubService } from '@pscoped/ngx-pub-sub';
import { Observable } from 'rxjs';
import { AuthUser } from '../module/services/userServices/authUser.service';
import { MatDialog } from '@angular/material/dialog';
import { DialogLogoutComponent } from '../shared/dialogs/dialog-logout/dialog-logout.component';
import { OwnerGymServices } from '../module/services/ownerGymServices/ownerServices';
import { GenericResponse } from '../module/interfaces/GenericResponse';
import { TrainerService } from '../module/services/trainerService/trainerService';
@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css'],
})
export class NavbarComponent implements OnInit {
  isAuthenticated: boolean;
  page: string;
  role: string;
  constructor(
    public authUser: AuthUser,
    public router: Router,
    private pubsub: NgxPubSubService,
    public dialog: MatDialog,
    private _serviceGymOwner: OwnerGymServices,
    private _serviceTrainer: TrainerService
  ) {}

  ngOnInit(): void {
    this.isAuthenticated = this.authUser.isUserAuthenticated();

    this.pubsub.subscribe('login', (value: any) => {
      this.isAuthenticated = value;
    });
    this.pubsub.subscribe('logout', (value: any) => {
      this.isAuthenticated = value;
    });
  }
  logout() {
    let dialogRef = this.dialog.open(DialogLogoutComponent);
  }
  CheckIfOwnerPageCreated() {
    this._serviceGymOwner
      .getCheckIfPageExist(this.authUser.getId())
      .subscribe((response: GenericResponse) => {
        if (response.statusCode == 200) this.page = 'ownerPageEdit';
        else this.page = 'ownerPage';
        this.router.navigate([this.page]);
      });
  }

  CheckIfTrainerPageCreated() {
    this._serviceTrainer
      .getCheckIfPageExist(this.authUser.getId())
      .subscribe((response: GenericResponse) => {
        console.log('From check page ', response);
        if (response.statusCode == 200) this.page = 'trainerPageEdit';
        else this.page = 'trainerPage';
        this.router.navigate([this.page]);
      });
  }
}
