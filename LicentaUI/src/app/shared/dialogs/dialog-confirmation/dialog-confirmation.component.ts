import { Component, Inject, OnInit } from '@angular/core';
import {
  MatDialog,
  MatDialogRef,
  MAT_DIALOG_DATA,
} from '@angular/material/dialog';

@Component({
  selector: 'dialog-confirmation',
  templateUrl: './dialog-confirmation.component.html',
})
export class DialogConfirmationComponent implements OnInit {
  constructor(
    public dialogRef: MatDialogRef<DialogConfirmationComponent>,
    @Inject(MAT_DIALOG_DATA) public data: string
  ) {}

  text: string;
  ngOnInit(): void {
    this.text = this.data;
  }

  onClickConfirm() {
    this.dialogRef.close(true);
  }

  onClickCancel() {
    this.dialogRef.close(false);
  }
}
