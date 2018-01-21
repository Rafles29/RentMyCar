import { Component, Inject, OnInit } from '@angular/core';

import { CarService } from '../../shared/services/carService';
import { Car } from '../../shared/models/car';
import { Router } from '@angular/router';
import { RentService } from '../../shared/services/rent.service';

@Component({
    selector: 'cars',
    providers: [
        CarService
    ],
    templateUrl: './cars.component.html'
})
export class CarsComponent implements OnInit{
    public cars: Car[];

    constructor(private carService: CarService, private router: Router, private rentService: RentService) {
    }

    public getCars(): void {
        this.carService.getCars().subscribe(cars => this.cars = cars);
    }

    ngOnInit() {
        this.getCars();
    }

    public rent(car: Car): void {
        this.rentService.selectedCar = car;
        this.router.navigate(["/rents/create"]);
    }
}