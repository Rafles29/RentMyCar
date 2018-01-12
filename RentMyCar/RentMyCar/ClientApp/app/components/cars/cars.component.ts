import { Component, Inject, OnInit } from '@angular/core';

import { DataService } from '../../shared/dataService';
import { Car } from '../../shared/car';

@Component({
    selector: 'cars',
    providers: [
        DataService
    ],
    templateUrl: './cars.component.html'
})
export class CarsComponent implements OnInit{
    public cars: Car[];

    constructor(private data: DataService) {
    }

    public getCars(): void {
        this.data.getCars().subscribe(cars => this.cars = cars);
    }

    ngOnInit() {
        this.getCars();
    }
}