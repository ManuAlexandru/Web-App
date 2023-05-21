import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
//import { UserModel } from '../models/userModel';
import { BehaviorSubject, Observable } from 'rxjs';
import { JwtHelperService } from '@auth0/angular-jwt';
import jwt_decode from 'jwt-decode';
import { ActivatedRouteSnapshot } from '@angular/router';
import { RoleModelComponent } from '../../models/roleModels/role-model.component';

@Injectable({
  providedIn: 'root',
})
export class AuthUser {
  constructor(private jwtHelper: JwtHelperService) {}

  isUserAuthenticated() {
    var token = localStorage.getItem('token');

    if (token && !this.jwtHelper.isTokenExpired(token)) return true;
    return false;
  }
  getRole() {
    var token = localStorage.getItem('token');
    if (token) {
      var payload = this.getDecodedAccessToken(token);

      return payload.Role;
    }
    return 'No token!';
  }
  getId() {
    var token = localStorage.getItem('token');
    if (token) {
      var payload = this.getDecodedAccessToken(token);

      return payload.Id;
    }
    return 'No token!';
  }
  getDecodedAccessToken(token: string): any {
    try {
      return jwt_decode(token);
    } catch (Error) {
      //need to be changed
      return null;
    }
  }
  checkAdmin() {
    if (this.getRole() == 'No token!') return false;
    return this.checkRole(this.getRole(), RoleModelComponent.AdminPage);
  }
  checkOwner() {
    if (this.getRole() == 'No token!') return false;
    return this.checkRole(this.getRole(), RoleModelComponent.OwnerPage);
  }
  checkTrainer() {
    if (this.getRole() == 'No token!') return false;
    return this.checkRole(this.getRole(), RoleModelComponent.TrainerPage);
  }
  checkUser() {
    if (this.getRole() == 'No token!') return false;
    return this.checkRole(this.getRole(), RoleModelComponent.UserPage);
  }
  isAuthorized(route: ActivatedRouteSnapshot): boolean {
    return this.checkRole(this.getRole(), route.data.expectedRoles);
  }
  checkRole(userRole: string, roles: string[]) {
    const roleMatches = roles.indexOf(userRole);
    if (roleMatches < 0) return false;
    return true;
  }
}
