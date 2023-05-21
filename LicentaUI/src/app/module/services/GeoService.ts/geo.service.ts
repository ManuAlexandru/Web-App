import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { EndpointModel } from '../../models/endpointModel';

@Injectable({
  providedIn: 'root',
})
export class GeoService {
  constructor(private _http: HttpClient, private _endpoint: EndpointModel) {}
  headers: HttpHeaders = new HttpHeaders({
    Authorization: 'Bearer ' + localStorage.getItem('token'),
  });

  public getCountries(countryFiltered: string): Observable<any> {
    return this._http.post(this._endpoint.urlGeoGetCountries, {
      headers: this.headers,
    });
  }
  public getCitiesByCountry(countryName: string): Observable<any> {
    return this._http.post(this._endpoint.urlGeoGetCitiesByCountry, {
      country: countryName,
    });
  }
}
