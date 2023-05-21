import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { CountryModel } from 'src/app/module/models/GeoModels/country-model';
import { TrainerModel } from 'src/app/module/models/trainerModel';
import { GeoService } from 'src/app/module/services/GeoService.ts/geo.service';
import { TrainerService } from 'src/app/module/services/trainerService/trainerService';
import { AuthUser } from 'src/app/module/services/userServices/authUser.service';

@Component({
  selector: 'app-trainer-page',
  templateUrl: './trainer-page.component.html',
  styleUrls: ['./trainer-page.component.css'],
})
export class TrainerPageComponent implements OnInit {
  formGroup: FormGroup;
  countries: CountryModel[] = [];
  cities: string[] = [];
  trainer: TrainerModel = new TrainerModel();
  constructor(
    private _formBuilder: FormBuilder,
    private _trainerService: TrainerService,
    private _serviceAuth: AuthUser,
    private _geoService: GeoService,
    private _router: Router
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

    this._geoService.getCountries('dsad').subscribe((response) => {
      this.countries = response;
      console.log(response);
    });
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
    this._trainerService.postCreatePage(this.trainer).subscribe((response) => {
      console.log(response);
    });
  }

  getCitiesByCountry() {
    this._geoService
      .getCitiesByCountry(this.formGroup.value.country)
      .subscribe((response) => {
        this.cities = response.data;
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
}
