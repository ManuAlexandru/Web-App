import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { Observable } from 'rxjs';
import { EndpointModel } from '../../models/endpointModel';
import { UserModel } from '../../models/userModel';
import { ProfilePasswordModel } from '../../models/ProfileModels/ProfilePasswordModel';
import { ProfileNameModel } from '../../models/ProfileModels/ProfileNameModel';

@Injectable({
  providedIn: 'root',
})
export class UserModelService {
  invalidLogin: boolean;
  constructor(private http: HttpClient, private endpoint: EndpointModel) {}

  public formData: UserModel = new UserModel();

  postUserRegister(formData: UserModel): Observable<any> {
    return this.http.post(this.endpoint.urlRegister, formData);
  }

  postUserLogin(formData: UserModel): Observable<any> {
    return this.http.post(this.endpoint.urlLogin, formData);
  }

  getUserProfile(): Observable<any> {
    var tokenHeader = new HttpHeaders({
      Authorization: 'Bearer ' + localStorage.getItem('token'),
    });
    return this.http.get(this.endpoint.urlProfile, { headers: tokenHeader });
  }

  postUserName(userName: ProfileNameModel): Observable<any> {
    var tokenHeader = new HttpHeaders({
      Authorization: 'Bearer ' + localStorage.getItem('token'),
    });
    return this.http.post(this.endpoint.urlProfileName, userName, {
      headers: tokenHeader,
    });
  }

  postUserPassword(userPassword: ProfilePasswordModel): Observable<any> {
    var tokenHeader = new HttpHeaders({
      Authorization: 'Bearer ' + localStorage.getItem('token'),
    });
    return this.http.post(this.endpoint.urlProfilePassword, userPassword, {
      headers: tokenHeader,
    });
  }

  getEmailConfirmation(Email: string, Token: string): Observable<any> {
    return this.http.get(this.endpoint.urlEmailConfirmation);
  }

  putEmailConfirmation(email: string, token: string): Observable<any> {
    var body = { email, token };
    return this.http.put(this.endpoint.urlEmailConfirmation, body);
  }
}
