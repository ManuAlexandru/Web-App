import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { EndpointModel } from '../../models/endpointModel';
import { TrainerModel } from '../../models/trainerModel';
import { Observable } from 'rxjs';
import { DeletePhotoModel } from '../../models/deletePhotoModel';

@Injectable({
  providedIn: 'root',
})
export class TrainerService {
  constructor(private http: HttpClient, private endpoint: EndpointModel) {}

  getPhotosRoutes(id: string): Observable<any> {
    var tokenHeader = new HttpHeaders({
      Authorization: 'Bearer ' + localStorage.getItem('token'),
    });
    return this.http.get(this.endpoint.urlTrainerGetPhotos + id, {
      headers: tokenHeader,
    });
  }
  getCheckIfPageExist(id: string): Observable<any> {
    var tokenHeader = new HttpHeaders({
      Authorization: 'Bearer ' + localStorage.getItem('token'),
    });
    return this.http.get(this.endpoint.urlTrainerGetCheckPageExist + id, {
      headers: tokenHeader,
    });
  }

  postCreatePage(trainerModel: TrainerModel): Observable<any> {
    var tokenHeader = new HttpHeaders({
      Authorization: 'Bearer ' + localStorage.getItem('token'),
    });
    return this.http.post(this.endpoint.urlTrainerCreatePage, trainerModel, {
      headers: tokenHeader,
    });
  }

  getPage(id: string): Observable<any> {
    var tokenHeader = new HttpHeaders({
      Authorization: 'Bearer ' + localStorage.getItem('token'),
    });
    return this.http.get(this.endpoint.urlTrainerGetPage + id, {
      headers: tokenHeader,
    });
  }

  getTrainer(id: string): Observable<any> {
    var tokenHeader = new HttpHeaders({
      Authorization: 'Bearer ' + localStorage.getItem('token'),
    });
    return this.http.get(this.endpoint.urlTrainerGetTrainer + id, {
      headers: tokenHeader,
    });
  }

  getTrainers(): Observable<any> {
    var tokenHeader = new HttpHeaders({
      Authorization: 'Bearer ' + localStorage.getItem('token'),
    });
    return this.http.get(this.endpoint.urlTrainerGetTrainers, {
      headers: tokenHeader,
    });
  }

  updatePageInfo(trainerModel: TrainerModel, id?: string): Observable<any> {
    var tokenHeader = new HttpHeaders({
      Authorization: 'Bearer ' + localStorage.getItem('token'),
    });

    return this.http.put(
      this.endpoint.urlTrainerEditPageInfo + id,
      trainerModel,
      {
        headers: tokenHeader,
      }
    );
  }
  addPagePhotos(photos: FormData, id: string): Observable<any> {
    var tokenHeader = new HttpHeaders({
      Authorization: 'Bearer ' + localStorage.getItem('token'),
    });
    console.log(photos);
    return this.http.put(this.endpoint.urlTrainerAddPhotos + id, photos, {
      headers: tokenHeader,
    });
  }
  deletePagePhotos(photos: DeletePhotoModel): Observable<any> {
    var tokenHeader = new HttpHeaders({
      Authorization: 'Bearer ' + localStorage.getItem('token'),
    });

    return this.http.put(this.endpoint.urlTrainerDeletePhotos, photos, {
      headers: tokenHeader,
    });
  }
}
