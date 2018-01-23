import { Component, OnInit } from '@angular/core';
import { Car } from '../../shared/models/car';
import { CarService } from '../../shared/services/carService';
import { RentService } from '../../shared/services/rent.service';
import { ActivatedRoute, ParamMap, Router } from '@angular/router';
import 'rxjs/add/operator/switchMap';

@Component({
  selector: 'app-car-details',
  templateUrl: './car-details.component.html',
  styleUrls: ['./car-details.component.css']
})
export class CarDetailsComponent implements OnInit {

    public car: Car;

    constructor(private route: ActivatedRoute, private router: Router, private carService: CarService, private rentService: RentService) {
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

    public rent(): void {
        this.rentService.selectedCar = this.car;
        this.router.navigate(["/rents/create"]);
    }

}
