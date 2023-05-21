import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { GymModel } from 'src/app/module/models/gymModel';
import { OwnerGymServices } from 'src/app/module/services/ownerGymServices/ownerServices';

@Component({
  selector: 'gym-list',
  templateUrl: './gym-list.component.html',
})
export class GymListComponent implements OnInit {
  gyms: GymModel[] = [];
  filterText: string = '';

  constructor(
    private _ownerService: OwnerGymServices,
    private _router: Router
  ) {}
  ngOnInit(): void {
    this._ownerService.getGyms().subscribe((res: GymModel[]) => {
      this.gyms = res;
      console.log(res);
    });
  }

  viewGym(id: string) {
    this._router.navigate(['/Gyms', id]);
  }
}
