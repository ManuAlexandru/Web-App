import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ThemePalette } from '@angular/material/core';
import { OwnerPageModel } from '../../module/models/ownerPageModel';
import { OwnerGymServices } from 'src/app/module/services/ownerGymServices/ownerServices';
import { AuthUser } from 'src/app/module/services/userServices/authUser.service';
import { NotificationServiceProvider } from 'src/app/module/services/NotificationService';
import { MatDialog } from '@angular/material/dialog';
import { GeoService } from 'src/app/module/services/GeoService.ts/geo.service';
import { CountryModel } from 'src/app/module/models/GeoModels/country-model';
import { DialogConfirmationComponent } from 'src/app/shared/dialogs/dialog-confirmation/dialog-confirmation.component';
import { GenericResponse } from 'src/app/module/interfaces/GenericResponse';
import { Router } from '@angular/router';

@Component({
  selector: 'app-owner-page',
  templateUrl: './owner-page.component.html',
  styleUrls: ['./owner-page.component.css'],
})
export class OwnerPageComponent implements OnInit {
  dataToSend: OwnerPageModel;
  firstFormGroup: FormGroup;
  secondFormGroup: FormGroup;
  thirdFormGroup: FormGroup;
  isLinear = true;
  countries: CountryModel[] = [];
  cities: string[] = [];

  constructor(
    private _formBuilder: FormBuilder,
    private _ownerService: OwnerGymServices,
    private _notificationService: NotificationServiceProvider,
    private _geoService: GeoService,
    private _dialog: MatDialog,
    private _authService: AuthUser,
    private _router: Router
  ) {}

  ngOnInit(): void {
    console.log(this._authService.getId());
    this.firstFormGroup = this._formBuilder.group({
      gymName: ['', Validators.required],
      country: ['', Validators.required],
      city: ['', Validators.required],
      addres: ['', Validators.required],
      price: ['', Validators.required],
    });
    this.secondFormGroup = this._formBuilder.group({
      description: ['', Validators.required],
    });
    this.thirdFormGroup = this._formBuilder.group({
      isCreditCardPaymentPossible: [false],
      hasSevenCard: [false],
    });

    this._geoService.getCountries('dsad').subscribe((response) => {
      this.countries = response;
      console.log(response);
    });
  }
  get getGymName() {
    return this.firstFormGroup.get('gymName');
  }
  get getCountry() {
    return this.firstFormGroup.get('country');
  }
  get getCity() {
    return this.firstFormGroup.get('city');
  }
  get getAddres() {
    return this.firstFormGroup.get('addres');
  }
  get getPrice() {
    return this.firstFormGroup.get('price');
  }
  get getDescription() {
    return this.secondFormGroup.get('description');
  }
  get getIsCreditCardPaymentPossible() {
    return this.thirdFormGroup.get('isCreditCardPaymentPossible');
  }
  get getHasSevenCard() {
    return this.thirdFormGroup.get('hasSevenCard');
  }

  getCitiesByCountry() {
    this._geoService
      .getCitiesByCountry(this.firstFormGroup.value.country)
      .subscribe((response) => {
        this.cities = response.data;
      });
  }

  onsubmit() {
    this.dataToSend = this.firstFormGroup.value;
    const desciption = this.secondFormGroup.value.description;
    this.dataToSend.isCreditCardPaymentPossible =
      this.thirdFormGroup.value.isCreditCardPaymentPossible;
    this.dataToSend.hasSevenCard = this.thirdFormGroup.value.hasSevenCard;
    this.dataToSend.description = desciption;

    this.dataToSend.userId = this._authService.getId();
    const dialogRef = this._dialog.open(DialogConfirmationComponent, {
      data: 'Are you sure you want to create the page?',
    });

    dialogRef.afterClosed().subscribe((result) => {
      if (!result) return;
      this._ownerService
        .postCreatePage(this.dataToSend)
        .subscribe((response: GenericResponse) => {
          if (response.statusCode == 200) {
            this._notificationService.onSucces(response.message);
            this._router.navigate(['/ownerPageEdit']);
          } else {
            this._notificationService.onFailed(response.message);
          }
        });
    });
  }
}
