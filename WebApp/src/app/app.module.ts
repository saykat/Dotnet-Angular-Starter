import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import {AppRouteModule} from './app.route';
import {HomeComponent} from './home/home.component';
import {UserComponent} from './user/user.component';
import {HttpClientModule} from '@angular/common/http';
import { AttendanceComponent } from './attendance/attendance.component';
import {NgBusyModule} from 'ng-busy';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {UserRegisterComponent} from './user/register/user-register.component';
import {FooterComponent} from './widgets/footer/footer.component';
import {HeaderComponent} from './widgets/header/header.component';
import {FormsModule} from '@angular/forms';
import {ToastrModule} from 'ngx-toastr';
import {CommonModule} from '@angular/common';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    UserComponent,
    AttendanceComponent,
    UserRegisterComponent,
    FooterComponent,
    HeaderComponent
  ],
  imports: [
    CommonModule,
    BrowserModule,
    AppRouteModule,
    HttpClientModule,
    BrowserAnimationsModule,
    NgBusyModule,
    FormsModule,
    BrowserAnimationsModule, // required animations module
    ToastrModule.forRoot()
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
