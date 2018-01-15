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

const appRoutes: Routes = [
    { path: '', redirectTo: 'home', pathMatch: 'full' },
    { path: 'home', component: HomeComponent },
    { path: 'users', component: UsersComponent },
    { path: 'cars', component: CarsComponent },
    { path: 'cars/:id', component: CarDetailsComponent },
    { path: 'mycars', component: MyCarsComponent},
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