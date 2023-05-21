import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { AdminService } from '../module/services/adminServices/admin.service';
import { MatDialog } from '@angular/material/dialog';
import { DialogUserComponent } from '../shared/dialogs/dialog-user/dialog-user.component';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { UserModifyModel } from '../module/models/UserModifyModel';
import { MatFormField } from '@angular/material/form-field';
import { DialogDeleteComponent } from '../shared/dialogs/dialog-delete/dialog-delete.component';
import { NotificationsService } from 'angular2-notifications';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { Title } from '@angular/platform-browser';
import { NotificationServiceProvider } from '../module/services/NotificationService';
@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css'],
})
export class AdminComponent implements OnInit, AfterViewInit {
  displayedColumns: string[] = ['firstName', 'lastName', 'email', 'role', 'id'];
  lstUsers: UserModifyModel[];
  updateUser: UserModifyModel = new UserModifyModel();
  userId: string;
  dataSource = new MatTableDataSource();
  value: string;
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;

  constructor(
    private _service: AdminService,
    public dialog: MatDialog,
    private notificationService: NotificationServiceProvider
  ) {}

  ngOnInit(): void {
    this._service.getAllUsers().subscribe((data) => {
      this.lstUsers = data;
      this.dataSource.data = this.lstUsers;
      this.dataSource.paginator = this.paginator;
    });
  }

  ngAfterViewInit() {
    this.dataSource.sort = this.sort;
  }

  applyFilter($event: any) {
    this.dataSource.filter = $event.target.value;
  }

  deleteUser(id: string) {
    this.openDeleteDialog(id);
  }

  editUser(id: string) {
    this._service.getUser(id).subscribe((data) => {
      this.openUserDialog(data);
    });
  }
  openUserDialog(user: UserModifyModel): void {
    let dialogRef = this.dialog.open(DialogUserComponent, {
      data: user,
    });

    dialogRef.afterClosed().subscribe((result) => {
      this.updateUser = result;
      if (result) {
        this._service.putModifyUser(this.updateUser).subscribe((data) => {
          if (data.statusCode == 200)
            this.notificationService.onSucces(data.message);
          else this.notificationService.onFailed(data.message);
          this.ngOnInit();
        });
      }
    });
  }
  openDeleteDialog(userId: string) {
    let dialogRef = this.dialog.open(DialogDeleteComponent, {
      data: userId,
    });
    dialogRef.afterClosed().subscribe((result) => {
      if (result) {
        this._service.postDeleteUser(result).subscribe((data) => {
          if (data.statusCode == 200)
            this.notificationService.onSucces(data.message);
          else this.notificationService.onFailed(data.message);
          this.ngOnInit();
        });
      }
    });
  }
}
