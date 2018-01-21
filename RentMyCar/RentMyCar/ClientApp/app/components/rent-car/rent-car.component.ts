import { Component, OnInit } from '@angular/core';
import { Rent } from '../../shared/models/rent';
import { RentService } from '../../shared/services/rent.service';
import { HttpErrorResponse } from '@angular/common/http';
import { Adress } from '../../shared/models/adress';
import { Router } from '@angular/router';


@Component({
  selector: 'app-rent-car',
  templateUrl: './rent-car.component.html',
  styleUrls: ['./rent-car.component.css']
})
export class RentCarComponent implements OnInit {
    alertService: any;

    loading = false;
    private rent: any = {};
    private adress: any = {};

    constructor(private rentService: RentService, private router: Router) { }

    ngOnInit() {

    }

    public postRent(): void {
        this.rentService.postRent(this.prepareForPost()).subscribe(
            data => {
                // set success message and pass true paramater to persist the message after redirecting to the login page
                console.log('Rented car successfully');
                this.router.navigate(['/rents']);
            },
            (err: HttpErrorResponse) => {
                if (err.error instanceof Error) {
                    // A client-side or network error occurred. Handle it accordingly.
                    console.log('An error occurred:', err.error.message);
                    this.loading = false;
                } else {
                    // The backend returned an unsuccessful response code.
                    // The response body may contain clues as to what went wrong,
                    console.log(`Backend returned code ${err.status}, body was: ${err.error}`);
                    this.loading = false;
                }
            });
    }

    private prepareForPost(): Rent {
        this.rent.startDate = this.rent.start + "T12:00:00" ;
        this.rent.endDate = this.rent.end + "T12:00:00";

        let rent: Rent = new Rent();
        rent.carId = this.rentService.selectedCar.carId;
        rent.startDate = this.rent.start + "T12:00:00";
        rent.endDate = this.rent.end + "T12:00:00";

        let adress = new Adress();
        adress.city = this.adress.city;
        adress.postalCode = this.adress.postalCode;
        adress.streetName = this.adress.streetName;
        adress.streetNumber = parseInt(this.adress.streetNumber);

        rent.adress = adress;
        return rent;
    }

}
