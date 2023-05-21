import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { EndpointModel } from '../../models/endpointModel';
import { UserModifyModel } from '../../models/UserModifyModel';

@Injectable({
  providedIn: 'root',
})
export class AdminService {
  constructor(private httpclient: HttpClient,private endpointURL:EndpointModel) {}

  

  getAllUsers(): Observable<any> {
    return this.httpclient.get(this.endpointURL.urlAllUsers);
  }
  getUser(id: string): Observable<any> {
    return this.httpclient.get(this.endpointURL.urlEdit + id);
  }
  putModifyUser(updatedUser: UserModifyModel): Observable<any> {
    return this.httpclient.put(this.endpointURL.urlModify, updatedUser);
  }
  postDeleteUser(id: string): Observable<any> {
    return this.httpclient.delete(this.endpointURL.urlDeleteUser + id);
  }
}
