import { Component, OnInit } from '@angular/core';
import { UserModelService } from '../module/services/userServices/user.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent implements OnInit {
  VmImage: any;
  imageToShow: any;
  constructor(private _service: UserModelService) {}

  ngOnInit(): void {}
}
