import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-role-model',
  template: ` <p>role-model works!</p> `,
  styles: [],
})
export class RoleModelComponent implements OnInit {
  static AdminPage: string[] = ['Admin'];
  static OwnerPage: string[] = ['Admin', 'OwnerOfGym'];
  static TrainerPage: string[] = ['Admin', 'OwnerOfGym', 'Trainer'];
  static UserPage: string[] = ['User','Admin', 'OwnerOfGym', 'Trainer'];
  constructor() {}

  ngOnInit(): void {}
}
