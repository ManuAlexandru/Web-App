import { Component, OnInit, Inject } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { AdminService } from '../../../module/services/adminServices/admin.service';
import { UserModel } from '../../../module/models/userModel';
@Component({
  selector: 'app-dialog-user',
  templateUrl: './dialog-user.component.html',
  styleUrls: ['./dialog-user.component.css'],
})
export class DialogUserComponent implements OnInit {
  roles = ['User', 'OwnerOfGym', 'Trainer', 'Admin'];
  constructor(
    @Inject(MAT_DIALOG_DATA) public data: UserModel,
    public service: AdminService
  ) {}

  ngOnInit(): void {}
}
