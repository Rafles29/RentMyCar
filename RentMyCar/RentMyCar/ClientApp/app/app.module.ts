import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { UsersComponent } from './components/users/users.component';
import { CarsComponent } from './components/cars/cars.component';
import { LoginComponent } from './components/login/login.component';
import { CarService } from './shared/services/carService';
import { UserService } from './shared/services/userService';
import { RegisterComponent } from './components/register/register.component';
import { AlertComponent } from './components/alert/alert.component';
import { AuthenticationService } from './shared/services/authentication.service';
import { AlertService } from './shared/services/alert.service';
import { BearerService } from './shared/services/bearer.service';
import { CarDetailsComponent } from './components/car-details/car-details.component';
import { AuthGuard } from './shared/services/auth.guard.service';
import { JwtInterceptor } from './shared/services/jwt.interceptor';
import { MyCarsComponent } from './components/my-cars/my-cars.component';
import { AppRoutingModule } from './app-routing.module';

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        CarsComponent,
        UsersComponent,
        HomeComponent,
        LoginComponent,
        RegisterComponent,
        AlertComponent,
        CarDetailsComponent,
        MyCarsComponent
    ],
    imports: [
        CommonModule,
        HttpClientModule,
        FormsModule,
        AppRoutingModule
    ],
    providers: [
        CarService,
        UserService,
        AuthenticationService,
        AlertService,
        BearerService,
        AuthGuard
    ]
})
export class AppModuleShared {
}
