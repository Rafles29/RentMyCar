import { Component, OnInit } from '@angular/core';
import { Car } from '../../shared/models/car';
import { ActivatedRoute, Router } from '@angular/router';
import { CarService } from '../../shared/services/carService';
import { HttpErrorResponse } from '@angular/common/http';
import { AlertService } from '../../shared/services/alert.service';

@Component({
    selector: 'app-add-car',
    templateUrl: './add-car.component.html',
    styleUrls: ['./add-car.component.css']
})
export class AddCarComponent implements OnInit {
    loading = false;
    public car: Car = new Car();

    constructor(
        private router: Router,
        private carService: CarService,
        private alertService: AlertService) {
    }

    ngOnInit() {
        this.car.performance = {
            "zeroTo100": 0,
            "maxSpeed": 0,
            "millage": 0,
            "horsePower": 0
        };
        this.car.price = {
            "shortTermPrice": 0,
            "midTermPrice": 0,
            "longTermPrice": 0
        };
    }

    postCar() {
        this.loading = true;
        this.carService.postCar(this.car)
            .subscribe(
            data => {
                // set success message and pass true paramater to persist the message after redirecting to the login page
                this.alertService.success('Putted successful', true);
                console.log('Putted successful');
                this.router.navigate(['/mycars']);
            },
            (err: HttpErrorResponse) => {
                if (err.error instanceof Error) {
                    // A client-side or network error occurred. Handle it accordingly.
                    this.alertService.error('An error occurred:' + err.error.message);
                    console.log('An error occurred:', err.error.message);
                    this.loading = false;
                } else {
                    // The backend returned an unsuccessful response code.
                    // The response body may contain clues as to what went wrong,
                    this.alertService.error(`Backend returned code ${err.status}, body was: ${err.error}`);
                    console.log(`Backend returned code ${err.status}, body was: ${err.error}`);
                    this.loading = false;
                }
            });
    }
}
