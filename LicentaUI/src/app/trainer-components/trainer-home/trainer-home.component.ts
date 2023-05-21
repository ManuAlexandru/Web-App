import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-trainer-home',
  templateUrl: './trainer-home.component.html',
  styleUrls: ['./trainer-home.component.css'],
})
export class TrainerHomeComponent implements OnInit {
  constructor(private _router: Router) {}

  ngOnInit(): void {}
  RedirectToContacUs() {
    this._router.navigate(['/contact']);
  }
}
