import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { UsersComponent } from './components/users/users.component';
import { MyCarsComponent } from './components/my-cars/my-cars.component';
import { CarsComponent } from './components/cars/cars.component';
import { RegisterComponent } from './components/register/register.component';
import { CarDetailsComponent } from './components/car-details/car-details.component';
import { LoginComponent } from './components/login/login.component';
import { AuthGuard } from './shared/services/auth.guard.service';
import { EditCarComponent } from './components/edit-car/edit-car.component';
import { AddCarComponent } from './components/add-car/add-car.component';
import { RentsComponent } from './components/rents/rents.component';

const appRoutes: Routes = [
    { path: '', redirectTo: 'home', pathMatch: 'full' },
    { path: 'home', component: HomeComponent },
    { path: 'users', component: UsersComponent },
    { path: 'cars', component: CarsComponent },
    { path: 'cars/create', component: AddCarComponent },
    { path: 'cars/:id', component: CarDetailsComponent },
    { path: 'cars/:id/edit', component: EditCarComponent, canActivate: [AuthGuard] },
    { path: 'mycars', component: MyCarsComponent, canActivate: [AuthGuard] },
    { path: 'rents', component: RentsComponent, canActivate: [AuthGuard] },
    { path: 'login', component: LoginComponent },
    { path: 'register', component: RegisterComponent },
    { path: '**', redirectTo: 'home' }
];

@NgModule({
    imports: [
        RouterModule.forRoot(
            appRoutes
        )
    ],
    providers: [
        AuthGuard
    ],
    exports: [
        RouterModule
    ]
})
export class AppRoutingModule { }