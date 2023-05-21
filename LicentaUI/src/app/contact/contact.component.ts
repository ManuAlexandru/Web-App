import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ContactService } from '../module/services/contactServices/contact.service';
import { MatDialog } from '@angular/material/dialog';
import { NotificationServiceProvider } from '../module/services/NotificationService';
import { DialogConfirmationComponent } from '../shared/dialogs/dialog-confirmation/dialog-confirmation.component';

@Component({
  selector: 'app-contact',
  templateUrl: './contact.component.html',
  styleUrls: ['./contact.component.css'],
})
export class ContactComponent implements OnInit {
  contact: FormGroup;
  constructor(
    private fb: FormBuilder,
    private _contactService: ContactService,
    private _dialog: MatDialog,
    private _notificationService: NotificationServiceProvider
  ) {}

  ngOnInit(): void {
    this.contact = this.fb.group({
      name: ['', [Validators.required]],
      email: ['', [Validators.required]],
      message: ['', [Validators.required]],
    });
  }

  get getName() {
    return this.contact.get('name');
  }

  get getEmail() {
    return this.contact.get('email');
  }

  get getMessage() {
    return this.contact.get('message');
  }

  SendMessage() {
    const dialogRef = this._dialog.open(DialogConfirmationComponent, {
      data: 'Are you sure you want to send the message?',
    });
    dialogRef.afterClosed().subscribe((result) => {
      if (!result) return;
      this._contactService
        .postContact(this.contact.value)
        .subscribe((response) => {
          this._notificationService.onSucces('Messaged Saved');
          // if (response.statusCode == 200) {
          //   this._notificationService.onSucces('Messaged Saved');
          // }
          // else {
          //   this._notificationService.onFailed(
          //     'Message not saved, please try again later'
          //   );
          // }
          this.contact.reset();
        });
    });
  }
}
