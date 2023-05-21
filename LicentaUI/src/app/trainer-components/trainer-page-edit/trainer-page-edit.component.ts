import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-trainer-page-edit',
  templateUrl: './trainer-page-edit.component.html',
  styleUrls: ['./trainer-page-edit.component.css'],
})
export class TrainerPageEditComponent implements OnInit {
  containerNr: number = 0;
  constructor() {}
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
  onClickPrograms() {
    this.containerNr = 3;
  }
}
