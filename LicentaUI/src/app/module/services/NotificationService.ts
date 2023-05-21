import { Injectable } from '@angular/core';
import { NotificationsService } from 'angular2-notifications';
@Injectable({
  providedIn: 'root',
})
export class NotificationServiceProvider {
  constructor(public notificationService: NotificationsService) {}
  onSucces(message) {
    this.notificationService.success('Success', message, {
      positiion: ['bottom', 'right'],
      timeOut: 2000,
      animate: 'fade',
      showProgress: true,
    });
  }
  onFailed(message) {
    this.notificationService.error('Error', message, {
      positiion: ['bottom', 'right'],
      timeOut: 2000,
      animate: 'fade',
      showProgress: true,
    });
  }
}
