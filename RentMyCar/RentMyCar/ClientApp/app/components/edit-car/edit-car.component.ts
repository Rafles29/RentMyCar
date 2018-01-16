import { Component, OnInit } from '@angular/core';
import { Car } from '../../shared/models/car';
import { ActivatedRoute, Router } from '@angular/router';
import { CarService } from '../../shared/services/carService';
import { HttpErrorResponse } from '@angular/common/http';
import { AlertService } from '../../shared/services/alert.service';

@Component({
  selector: 'app-edit-car',
  templateUrl: './edit-car.component.html',
  styleUrls: ['./edit-car.component.css']
})
export class EditCarComponent implements OnInit {
    loading = false;
    public car: Car;

    constructor(private route: ActivatedRoute,
        private router: Router,
        private carService: CarService,
        private alertService: AlertService) {
    }

    public getCar(): void {
        let id = this.route.snapshot.paramMap.get('id');
        this.carService.getCar(id).subscribe(car => {
            this.car = car;
        });
    }

    ngOnInit() {
        this.getCar();
    }

    putCar() {
        this.loading = true;
        console.log(this.car.price.shortTermPrice, this.car.price.midTermPrice, this.car.price.longTermPrice);
        console.log(this.car.performance.millage);
        this.carService.putCar(this.car)
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
