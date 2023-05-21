import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-owner-page-home',
  templateUrl: './owner-page-home.component.html',
  styleUrls: ['./owner-page-home.component.css'],
})
export class OwnerPageHomeComponent implements OnInit {
  constructor(private _router: Router) {}

  ngOnInit(): void {}
  RedirectToContacUs() {
    this._router.navigate(['/contact']);
  }
}
