import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AboutComponent } from './about/about.component';
import { AdminComponent } from './admin/admin.component';
import { AuthComponent } from './auth/auth.component';
import { ContactComponent } from './contact/contact.component';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';

import { OwnerPageComponent } from './owner-components/owner-page/owner-page.component';
import { ProfileComponent } from './profile/profile.component';
import { RegisterComponent } from './register/register.component';
import { TrainerPageComponent } from './trainer-components/trainer-page/trainer-page.component';
import { RoleGuardGuard } from './module/guards/role-guard.guard';
import { AuthGuardGuard } from './module/guards/auth-guard.guard';
import { RoleModelComponent } from './module/models/roleModels/role-model.component';
import { EmailConfirmationComponent } from './email-confirmation/email-confirmation.component';
import { OwnerPageEditComponent } from './owner-components/owner-page-edit/owner-page-edit.component';
import { TrainerPageEditComponent } from './trainer-components/trainer-page-edit/trainer-page-edit.component';
import { OwnerPageInformationComponent } from './owner-components/owner-page-information/owner-page-information.component';
import { OwnerPageImagesComponent } from './owner-components/owner-page-images/owner-page-images.component';
import { OwnerPageTrainersComponent } from './owner-components/owner-page-trainers/owner-page-trainers.component';
import { OwnerPageHomeComponent } from './owner-components/owner-page-home/owner-page-home.component';
import { GymListComponent } from './public-components/gyms/gym-list.component';
import { TrainerListComponent } from './public-components/trainers/trainer-list.component';
import { GymDetailsComponent } from './public-components/gyms/details/gym-details.component';
import { TrainerDetailsComponent } from './public-components/trainers/details/trainer-details.component';
const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'Gyms', component: GymListComponent },
  { path: 'Gyms/:id', component: GymDetailsComponent },

  { path: 'Trainers', component: TrainerListComponent },
  { path: 'Trainers/:id', component: TrainerDetailsComponent },

  {
    path: 'admin',
    component: AdminComponent,
    canActivate: [AuthGuardGuard, RoleGuardGuard],
    data: {
      expectedRoles: RoleModelComponent.AdminPage,
    },
  },
  { path: 'auth', component: AuthComponent },
  {
    path: 'ownerPage',
    component: OwnerPageComponent,
    canActivate: [AuthGuardGuard, RoleGuardGuard],
    data: {
      expectedRoles: RoleModelComponent.OwnerPage,
    },
  },
  {
    path: 'ownerPageEdit',
    component: OwnerPageEditComponent,
    canActivate: [AuthGuardGuard, RoleGuardGuard],
    data: {
      expectedRoles: RoleModelComponent.OwnerPage,
    },
  },
  {
    path: 'ownerPageEdit/information',
    component: OwnerPageInformationComponent,
    canActivate: [AuthGuardGuard, RoleGuardGuard],
    data: {
      expectedRoles: RoleModelComponent.OwnerPage,
    },
  },
  {
    path: 'ownerPageEdit/images',
    component: OwnerPageImagesComponent,
    canActivate: [AuthGuardGuard, RoleGuardGuard],
    data: {
      expectedRoles: RoleModelComponent.OwnerPage,
    },
  },
  {
    path: 'ownerPageEdit/trainers',
    component: OwnerPageTrainersComponent,
    canActivate: [AuthGuardGuard, RoleGuardGuard],
    data: {
      expectedRoles: RoleModelComponent.OwnerPage,
    },
  },
  {
    path: 'ownerpageEdit/home',
    component: OwnerPageHomeComponent,
    canActivate: [AuthGuardGuard, RoleGuardGuard],
    data: {
      expectedRoles: RoleModelComponent.OwnerPage,
    },
  },
  {
    path: 'trainerPage',
    component: TrainerPageComponent,
    canActivate: [AuthGuardGuard, RoleGuardGuard],
    data: {
      expectedRoles: RoleModelComponent.TrainerPage,
    },
  },
  {
    path: 'trainerPageEdit',
    component: TrainerPageEditComponent,
    canActivate: [AuthGuardGuard, RoleGuardGuard],
    data: {
      expectedRoles: RoleModelComponent.TrainerPage,
    },
  },

  {
    path: 'profile',
    component: ProfileComponent,
    canActivate: [AuthGuardGuard],
  },
  { path: 'contact', component: ContactComponent },
  { path: 'about', component: AboutComponent },
  { path: 'auth/register', component: RegisterComponent },
  { path: 'auth/login', component: LoginComponent },
  { path: 'emailConfirmation', component: EmailConfirmationComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
