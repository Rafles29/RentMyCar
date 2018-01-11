import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'cars',
    templateUrl: './cars.component.html'
})
export class CarsComponent {
    public cars: Car[];

    constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {
        
        http.get(baseUrl + 'api/cars').subscribe(result => {
            this.cars = result.json() as Car[];
        }, error => console.error(error));
        
    }
}

interface Car {
    carId: number;
    manufactor: string;
    model: string;
    year: number;
    avatarImage: string;
    performance: null;
    equipment: null;
    price: null;
    userName: string;
    rents: any[];
}