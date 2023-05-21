import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { TrainerModel } from 'src/app/module/models/trainerModel';
import { GeoService } from 'src/app/module/services/GeoService.ts/geo.service';

import { TrainerService } from 'src/app/module/services/trainerService/trainerService';
import { AuthUser } from 'src/app/module/services/userServices/authUser.service';

@Component({
  selector: 'app-trainer-page-information',
  templateUrl: './trainer-page-information.component.html',
  styleUrls: ['./trainer-page-information.component.css'],
})
export class TrainerPageInformationComponent implements OnInit {
  formGroup: FormGroup;
  trainer: TrainerModel = new TrainerModel();
  constructor(
    private _formBuilder: FormBuilder,
    private _trainerService: TrainerService,
    private _serviceAuth: AuthUser,
    private _geoService: GeoService
  ) {}

  ngOnInit(): void {
    this.formGroup = this._formBuilder.group({
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      description: ['', Validators.required],
      city: ['', Validators.required],
      country: ['', Validators.required],
      address: ['', Validators.required],
    });

    this.refreshPage();
  }

  get getFirstName() {
    return this.formGroup.get('firstName');
  }

  get getLastName() {
    return this.formGroup.get('lastName');
  }

  get getDescription() {
    return this.formGroup.get('description');
  }
  get getCity() {
    return this.formGroup.get('city');
  }
  get getCountry() {
    return this.formGroup.get('country');
  }
  get getAddress() {
    return this.formGroup.get('address');
  }

  onsubmit() {
    this.SetDataFromForm();
    console.log(this.trainer);
    this._trainerService.updatePageInfo(this.trainer).subscribe((response) => {
      this.refreshPage();
    });
  }

  SetDataFromForm() {
    this.trainer.userId = this._serviceAuth.getId();
    this.trainer.firstName = this.formGroup.value.firstName;
    this.trainer.lastName = this.formGroup.value.lastName;
    this.trainer.description = this.formGroup.value.description;
    this.trainer.city = this.formGroup.value.city;
    this.trainer.country = this.formGroup.value.country;
    this.trainer.address = this.formGroup.value.address;
  }

  refreshPage() {
    this._trainerService
      .getPage(this._serviceAuth.getId())
      .subscribe((response) => {
        this.formGroup.patchValue(response);
      });
  }
}
