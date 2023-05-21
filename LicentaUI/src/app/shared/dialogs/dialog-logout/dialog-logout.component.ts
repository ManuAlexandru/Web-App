import { Component, Inject, OnInit } from '@angular/core';
import {
  MatDialog,
  MatDialogRef,
  MAT_DIALOG_DATA,
} from '@angular/material/dialog';
import { Router } from '@angular/router';
import { NgxPubSubService } from '@pscoped/ngx-pub-sub';

@Component({
  selector: 'app-dialog-logout',
  templateUrl: './dialog-logout.component.html',
  styleUrls: ['./dialog-logout.component.css'],
})
export class DialogLogoutComponent implements OnInit {
  constructor(
    public router: Router,
    public pubsub: NgxPubSubService,
    public dialogRef: MatDialogRef<DialogLogoutComponent>
  ) {}

  ngOnInit(): void {}
  onClick() {
    this.dialogRef.close();
    localStorage.removeItem('token');
    this.pubsub.publishEvent('logout', false);
    this.router.navigateByUrl('');
  }
}
