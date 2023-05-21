import { Component, OnInit } from '@angular/core';
import { GenericResponse } from 'src/app/module/interfaces/GenericResponse';
import { OwnerPageInterface } from 'src/app/module/interfaces/ownerPageInterface';
import { OwnerGymServices } from 'src/app/module/services/ownerGymServices/ownerServices';
import { AuthUser } from 'src/app/module/services/userServices/authUser.service';
import { NotificationServiceProvider } from 'src/app/module/services/NotificationService';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { GeoService } from 'src/app/module/services/GeoService.ts/geo.service';
import { CountryModel } from 'src/app/module/models/GeoModels/country-model';
import { CityModel } from 'src/app/module/models/GeoModels/city-model';
import { MatDialog } from '@angular/material/dialog';
import { DialogConfirmationComponent } from 'src/app/shared/dialogs/dialog-confirmation/dialog-confirmation.component';

@Component({
  selector: 'app-owner-page-information',
  templateUrl: './owner-page-information.component.html',
  styleUrls: ['./owner-page-information.component.css'],
})
export class OwnerPageInformationComponent implements OnInit {
  id: string;
  page: FormGroup;
  countries: CountryModel[] = [];
  cities: string[] = [];

  constructor(
    private _serviceOwner: OwnerGymServices,
    private _serviceAuth: AuthUser,
    private _notificationService: NotificationServiceProvider,
    private _fb: FormBuilder,
    private _geoService: GeoService,
    private _dialog: MatDialog
  ) {}

  ngOnInit(): void {
    this.id = this._serviceAuth.getId();
    this.page = this._fb.group({
      userId: ['', [Validators.required]],
      gymName: ['', [Validators.required]],
      description: ['', [Validators.required]],
      country: ['', [Validators.required]],
      city: ['', [Validators.required]],
      addres: ['', [Validators.required]],
      price: ['', [Validators.required]],
      typeOfMoney: ['', [Validators.required]],
      typeOfGym: [''],
      phoneNumber: [0, [Validators.required]],
      isCreditCardPaymentPossible: [false],
      hasSevenCard: [false],
    });
    this._serviceOwner
      .getPage(this.id)
      .subscribe((response: OwnerPageInterface) => {
        this.page.patchValue({
          userId: response.userId,
          gymName: response.gymName,
          description: response.description,
          country: response.country,
          city: response.city,
          addres: response.addres,
          price: response.price,
          typeOfMoney: response.typeOfMoney,
          typeOfGym: response.typeOfGym,
          phoneNumber: response.phoneNumber,
          isCreditCardPaymentPossible: response.isCreditCardPaymentPossible,
          hasSevenCard: response.hasSevenCard,
        });
      });

    this._geoService.getCountries('dsad').subscribe((response) => {
      this.countries = response;
      console.log(response);
    });
  }
  SendInfo() {
    const dialogRef = this._dialog.open(DialogConfirmationComponent, {
      data: 'Are you sure you want to save your changes?',
    });

    dialogRef.afterClosed().subscribe((result) => {
      if (result) {
        this._serviceOwner
          .updatePageInfo(this.page.value, this.page.value.userId)
          .subscribe((response: GenericResponse) => {
            if (response.statusCode == 200)
              this._notificationService.onSucces(response.message);
            else this._notificationService.onFailed(response.message);
          });
      }
    });
  }
  get getGymName() {
    return this.page.get('gymName');
  }
  get getDescription() {
    return this.page.get('description');
  }
  get getAddres() {
    return this.page.get('addres');
  }
  get getPrice() {
    return this.page.get('price');
  }
  get getTypeOfMoney() {
    return this.page.get('typeOfMoney');
  }
  get getTypeOfGym() {
    return this.page.get('typeOfGym');
  }
  get getPhoneNumber() {
    return this.page.get('phoneNumber');
  }
  get getCountry() {
    return this.page.get('country');
  }
  get getCity() {
    return this.page.get('city');
  }

  GetCitiesByCountry() {
    this._geoService
      .getCitiesByCountry(this.page.value.country)
      .subscribe((response) => {
        this.cities = response.data;
        console.log(response);
        console.log(this.cities);
      });
  }
}
