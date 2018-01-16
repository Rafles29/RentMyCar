import { Component, OnInit } from '@angular/core';
import { Car } from '../../shared/models/car';
import { CarService } from '../../shared/services/carService';
import { HttpErrorResponse } from '@angular/common/http';
import { Router } from '@angular/router';
import { AlertService } from '../../shared/services/alert.service';

@Component({
  selector: 'app-my-cars',
  templateUrl: './my-cars.component.html',
  styleUrls: ['./my-cars.component.css']
})
export class MyCarsComponent implements OnInit {
    private selectedCar: number;
    public cars: Car[];

    constructor(
        private router: Router,
        private carService: CarService,
        private alertService: AlertService) { }

    public getMyCars(): void {
        this.carService.getMyCars().subscribe(cars => this.cars = cars);
    }
    public selectCar(id: number): void {
        this.selectedCar = id;
        console.log(id);
    }
    public deleteCar(): void {
        this.carService.deleteCar(this.selectedCar).subscribe(
            data => {
                // set success message and pass true paramater to persist the message after redirecting to the login page
                this.alertService.success('You deleted a car', true);
                this.getMyCars();
            },
            (err: HttpErrorResponse) => {
                if (err.error instanceof Error) {
                    // A client-side or network error occurred. Handle it accordingly.
                    this.alertService.error('An error occurred:' + err.error.message);
                    console.log('An error occurred:', err.error.message);
                } else {
                    // The backend returned an unsuccessful response code.
                    // The response body may contain clues as to what went wrong,
                    this.alertService.error(`Backend returned code ${err.status}, body was: ${err.error}`);
                    console.log(`Backend returned code ${err.status}, body was: ${err.error}`);
                }
            });
    }

    ngOnInit() {
        this.getMyCars();
    }
}