import { Component, Inject, OnInit } from '@angular/core';

import { CarService } from '../../shared/services/carService';
import { Car } from '../../shared/models/car';

@Component({
    selector: 'cars',
    providers: [
        CarService
    ],
    templateUrl: './cars.component.html'
})
export class CarsComponent implements OnInit{
    public cars: Car[];

    constructor(private carService: CarService) {
    }

    public getCars(): void {
        this.carService.getCars().subscribe(cars => this.cars = cars);
    }

    ngOnInit() {
        this.getCars();
    }
}