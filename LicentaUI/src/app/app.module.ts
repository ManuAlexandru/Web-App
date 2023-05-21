import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AboutComponent } from './about/about.component';
import { AdminComponent } from './admin/admin.component';
import { AuthComponent } from './auth/auth.component';
import { ContactComponent } from './contact/contact.component';
import { DialogUserComponent } from './shared/dialogs/dialog-user/dialog-user.component';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { NavbarComponent } from './navbar/navbar.component';
import { OwnerPageComponent } from './owner-components/owner-page/owner-page.component';
import { ProfileComponent } from './profile/profile.component';
import { RegisterComponent } from './register/register.component';
import { TrainerPageComponent } from './trainer-components/trainer-page/trainer-page.component';
import { FormsModule } from '@angular/forms';
import { MatIconModule } from '@angular/material/icon';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatDialogModule } from '@angular/material/dialog';
import { HttpClientModule } from '@angular/common/http';
import { MatRadioModule } from '@angular/material/radio';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatTableModule } from '@angular/material/table';
import { MatSortModule } from '@angular/material/sort';
import { MatPaginatorModule } from '@angular/material/paginator';
import { JwtModule } from '@auth0/angular-jwt';
import { MatInputModule } from '@angular/material/input';
import { DialogDeleteComponent } from './shared/dialogs/dialog-delete/dialog-delete.component';
import { ReactiveFormsModule } from '@angular/forms';
import { NgxPubSubModule } from '@pscoped/ngx-pub-sub';
import { RoleModelComponent } from './module/models/roleModels/role-model.component';
import { DialogLogoutComponent } from './shared/dialogs/dialog-logout/dialog-logout.component';
import { EmailConfirmationComponent } from './email-confirmation/email-confirmation.component';
import { MatStepperModule } from '@angular/material/stepper';
import { SimpleNotificationsModule } from 'angular2-notifications';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { OwnerPageEditComponent } from './owner-components/owner-page-edit/owner-page-edit.component';
import { TrainerPageEditComponent } from './trainer-components/trainer-page-edit/trainer-page-edit.component';
import { MatTabsModule } from '@angular/material/tabs';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatSelectModule } from '@angular/material/select';
import { OwnerPageInformationComponent } from './owner-components/owner-page-information/owner-page-information.component';
import { OwnerPageImagesComponent } from './owner-components/owner-page-images/owner-page-images.component';
import { OwnerPageHomeComponent } from './owner-components/owner-page-home/owner-page-home.component';
import { OwnerPageTrainersComponent } from './owner-components/owner-page-trainers/owner-page-trainers.component';
import { MaterialFileInputModule } from 'ngx-material-file-input';
import { MatChipsModule } from '@angular/material/chips';
import { TrainerPageImagesComponent } from './trainer-components/trainer-page-images/trainer-page-images.component';
import { TrainerPageInformationComponent } from './trainer-components/trainer-page-information/trainer-page-information.component';
import { DialogConfirmationComponent } from './shared/dialogs/dialog-confirmation/dialog-confirmation.component';
import { TrainerProgramComponent } from './trainer-components/trainer-program/trainer-program.component';
import { TrainerHomeComponent } from './trainer-components/trainer-home/trainer-home.component';
import { GymListComponent } from './public-components/gyms/gym-list.component';
import { GymDetailsComponent } from './public-components/gyms/details/gym-details.component';
import { TrainerListComponent } from './public-components/trainers/trainer-list.component';
import { TrainerDetailsComponent } from './public-components/trainers/details/trainer-details.component';
import { MatCardModule } from '@angular/material/card';
import { SearchPipe } from './shared/pipes/search.pipe';

export function tokenGetter() {
  return localStorage.getItem('token');
}
@NgModule({
  declarations: [
    AppComponent,
    AboutComponent,
    AdminComponent,
    AuthComponent,
    ContactComponent,
    DialogUserComponent,
    HomeComponent,
    LoginComponent,
    NavbarComponent,
    OwnerPageComponent,
    ProfileComponent,
    RegisterComponent,
    TrainerPageComponent,
    DialogDeleteComponent,
    RoleModelComponent,
    DialogLogoutComponent,
    DialogConfirmationComponent,
    EmailConfirmationComponent,
    OwnerPageEditComponent,
    TrainerPageEditComponent,
    OwnerPageInformationComponent,
    OwnerPageImagesComponent,
    OwnerPageHomeComponent,
    OwnerPageTrainersComponent,
    TrainerPageComponent,
    TrainerPageImagesComponent,
    TrainerPageInformationComponent,
    TrainerProgramComponent,
    TrainerHomeComponent,
    GymListComponent,
    GymDetailsComponent,
    TrainerListComponent,
    TrainerDetailsComponent,
    SearchPipe,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    MatButtonModule,
    HttpClientModule,
    FormsModule,
    MatToolbarModule,
    MatIconModule,
    BrowserAnimationsModule,
    MatDialogModule,
    MatFormFieldModule,
    MatTableModule,
    MatCardModule,
    MatSortModule,
    MatPaginatorModule,
    MatRadioModule,
    MatInputModule,
    ReactiveFormsModule,
    NgxPubSubModule,
    MatStepperModule,
    MatCheckboxModule,
    MatTabsModule,
    MatSidenavModule,
    MatSelectModule,
    MaterialFileInputModule,
    MatChipsModule,
    SimpleNotificationsModule.forRoot(),
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter,
        allowedDomains: ['localhost:7041'],
        disallowedRoutes: [],
      },
    }),
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
