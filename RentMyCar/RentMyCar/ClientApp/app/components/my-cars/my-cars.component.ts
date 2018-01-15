import { Component, OnInit } from '@angular/core';
import { Car } from '../../shared/models/car';
import { CarService } from '../../shared/services/carService';

@Component({
  selector: 'app-my-cars',
  templateUrl: './my-cars.component.html',
  styleUrls: ['./my-cars.component.css']
})
export class MyCarsComponent implements OnInit {
    public cars: Car[];

    constructor(private carService: CarService) {
    }

    public getMyCars(): void {
        this.carService.getMyCars().subscribe(cars => this.cars = cars);
    }

    ngOnInit() {
        this.getMyCars();
    }
}