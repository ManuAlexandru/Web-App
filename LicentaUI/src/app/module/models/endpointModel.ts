import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class EndpointModel {
  private readonly host = 'https://localhost:7041/';

  readonly urlAllUsers = this.host + 'api/Admin/Users';
  readonly urlEdit = this.host + 'api/Admin/';
  readonly urlModify = this.host + 'api/Admin/Modify';
  readonly urlDeleteUser = this.host + 'api/Admin/';
  readonly urlUpdateUser = this.host + 'api/Admin/UpdateUser';

  readonly urlOwnerCreatePage = this.host + 'api/Owner/CreatePage';
  readonly urlOwnerGetPhotos = this.host + 'api/Owner/GetPhotosRoutes/';
  readonly urlOwnerEditPageInfo = this.host + 'api/Owner/EditPageInfo/';
  readonly urlOwnerGetCheckPageExist = this.host + 'api/Owner/ExistPage/';
  readonly urlOwnerGetPage = this.host + 'api/Owner/GetPage/';
  readonly urlOwnerDeletePage = this.host + 'api/Owner/DeletePage/';
  readonly urlOwnerAddPhotos = this.host + 'api/Owner/SendPhotos/';
  readonly urlOwnerDeletePhotos = this.host + 'api/Owner/DeletePhotos';

  readonly urlTrainerCreatePage = this.host + 'api/Trainer/CreatePage';
  readonly urlTrainerGetPhotos = this.host + 'api/Trainer/GetPhotosRoutes/';
  readonly urlTrainerEditPageInfo = this.host + 'api/Trainer/EditPageInfo/';
  readonly urlTrainerGetCheckPageExist = this.host + 'api/Trainer/ExistPage/';
  readonly urlTrainerGetPage = this.host + 'api/Trainer/GetPage/';
  readonly urlTrainerAddPhotos = this.host + 'api/Trainer/SendPhotos/';
  readonly urlTrainerDeletePhotos = this.host + 'api/Trainer/DeletePhotos';

  readonly urlEmailConfirmation =
    this.host + 'api/Autentificare/EmailConfirmation';
  readonly urlRegister = this.host + 'api/Autentificare/Register';
  readonly urlLogin = this.host + 'api/Autentificare/Login';

  readonly urlProfile = this.host + 'api/Profile';

  readonly urlProfilePassword = this.host + 'api/Profile/UpdatePassword';
  readonly urlProfileName = this.host + 'api/Profile/UpdateName';

  //Public
  readonly urlOwnerGetGym = this.host + 'api/Public/GetGym/';
  readonly urlOwnerGetGyms = this.host + 'api/Public/GetAllGyms';
  readonly urlTrainerGetTrainer = this.host + 'api/Public/GetTrainer/';
  readonly urlTrainerGetTrainers = this.host + 'api/Public/GetAllTrainers';

  //Contact
  readonly urlContactForm = this.host + 'api/Contact/SaveContact';

  //GeoLocation
  readonly urlGeoGetCountries = this.host + 'api/GeoLocation/GetCountries';
  readonly urlGeoGetCitiesByCountry =
    'https://countriesnow.space/api/v0.1/countries/cities';
}
