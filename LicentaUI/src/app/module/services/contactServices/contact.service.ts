import { HttpClient } from '@angular/common/http';
import { EndpointModel } from '../../models/endpointModel';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class ContactService {
  constructor(private _http: HttpClient, private _endpoint: EndpointModel) {}

  public postContact(contactForm: any): any {
    return this._http.post(this._endpoint.urlContactForm, contactForm);
  }
}
