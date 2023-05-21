import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { DeletePhotoModel } from '../../models/deletePhotoModel';
import { EndpointModel } from '../../models/endpointModel';
import { OwnerPageModel } from '../../models/ownerPageModel';

@Injectable({
  providedIn: 'root',
})
export class OwnerGymServices {
  constructor(private http: HttpClient, private endpoint: EndpointModel) {}

  getPhotosRoutes(id: string): Observable<any> {
    var tokenHeader = new HttpHeaders({
      Authorization: 'Bearer ' + localStorage.getItem('token'),
    });
    return this.http.get(this.endpoint.urlOwnerGetPhotos + id, {
      headers: tokenHeader,
    });
  }
  deleteOwnerPage(id: string): Observable<any> {
    var tokenHeader = new HttpHeaders({
      Authorization: 'Bearer ' + localStorage.getItem('token'),
    });

    return this.http.delete(this.endpoint.urlOwnerDeletePage + id, {
      headers: tokenHeader,
    });
  }
  getCheckIfPageExist(id: string): Observable<any> {
    var tokenHeader = new HttpHeaders({
      Authorization: 'Bearer ' + localStorage.getItem('token'),
    });
    return this.http.get(this.endpoint.urlOwnerGetCheckPageExist + id, {
      headers: tokenHeader,
    });
  }

  postCreatePage(ownerPage: OwnerPageModel): Observable<any> {
    var tokenHeader = new HttpHeaders({
      Authorization: 'Bearer ' + localStorage.getItem('token'),
    });
    return this.http.post(this.endpoint.urlOwnerCreatePage, ownerPage, {
      headers: tokenHeader,
    });
  }

  getPage(id: string): Observable<any> {
    var tokenHeader = new HttpHeaders({
      Authorization: 'Bearer ' + localStorage.getItem('token'),
    });
    return this.http.get(this.endpoint.urlOwnerGetPage + id, {
      headers: tokenHeader,
    });
  }

  getGym(id: string): Observable<any> {
    var tokenHeader = new HttpHeaders({
      Authorization: 'Bearer ' + localStorage.getItem('token'),
    });
    return this.http.get(this.endpoint.urlOwnerGetGym + id, {
      headers: tokenHeader,
    });
  }

  getGyms(): Observable<any> {
    var tokenHeader = new HttpHeaders({
      Authorization: 'Bearer ' + localStorage.getItem('token'),
    });
    return this.http.get(this.endpoint.urlOwnerGetGyms, {
      headers: tokenHeader,
    });
  }

  updatePageInfo(page: OwnerPageModel, id?: string): Observable<any> {
    var tokenHeader = new HttpHeaders({
      Authorization: 'Bearer ' + localStorage.getItem('token'),
    });

    return this.http.put(this.endpoint.urlOwnerEditPageInfo + id, page, {
      headers: tokenHeader,
    });
  }
  addPagePhotos(photos: FormData, id: string): Observable<any> {
    var tokenHeader = new HttpHeaders({
      Authorization: 'Bearer ' + localStorage.getItem('token'),
    });
    console.log(photos);
    return this.http.put(this.endpoint.urlOwnerAddPhotos + id, photos, {
      headers: tokenHeader,
    });
  }
  deletePagePhotos(photos: DeletePhotoModel): Observable<any> {
    var tokenHeader = new HttpHeaders({
      Authorization: 'Bearer ' + localStorage.getItem('token'),
    });

    return this.http.put(this.endpoint.urlOwnerDeletePhotos, photos, {
      headers: tokenHeader,
    });
  }
}
