import { Component, Inject, OnInit } from '@angular/core';

import { CarService } from '../../shared/services/carService';
import { Car } from '../../shared/models/car';
import { Router } from '@angular/router';
import { RentService } from '../../shared/services/rent.service';
import { CarsPipe } from '../../shared/pipes/cars.pipe';

@Component({
    selector: 'cars',
    providers: [
        CarService
    ],
    templateUrl: './cars.component.html'

})
export class CarsComponent implements OnInit{
    public cars: Car[];

    /**
     * @type {number} minYear The year of the oldest book in the json.
     */
    minYear: number = 1920;
    /**
     * @type {number} maxYear The year of the newest book in the json.
     */
    maxYear: number = 2018;

    /**
     * @type {number} numberOfBooks The number of books in the JSON file, used for max attribute for limit and page.
     */
    numberOfCars: number;

    /**
     * @type {number} limit The number of books per page.
     */
    limit: number;

    /**
     * @type {number} page The current page.
     */
    page: number = 1;


    filter: Car = new Car();

    constructor(private carService: CarService, private router: Router, private rentService: RentService) {
    }

    public getCars(): void {
        this.carService.getCars().subscribe(cars => {
            this.cars = cars
            this.numberOfCars = this.cars.length;
            this.limit = this.cars.length;
        });
    }

    ngOnInit() {
        this.getCars();
    }

    getFilter() {
        console.log(this.filter);
    }

    public numberofPages(): number {
        if (!this.cars) {
            return 1;
        }
        return Math.ceil(this.cars.length / this.limit);
    }

    public rent(car: Car): void {
        this.rentService.selectedCar = car;
        this.router.navigate(["/rents/create"]);
    }
}