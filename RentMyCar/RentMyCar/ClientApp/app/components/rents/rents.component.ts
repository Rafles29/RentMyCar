import { Component, OnInit } from '@angular/core';
import { Rent } from '../../shared/models/rent';
import { RentService } from '../../shared/services/rent.service';


@Component({
  selector: 'app-rents',
  templateUrl: './rents.component.html',
  styleUrls: ['./rents.component.css']
})
export class RentsComponent implements OnInit {

    public rents: Rent[];

    constructor(private rentService: RentService) {
    }

    public getRents(): void {
        this.rentService.getMyRents().subscribe(rents => this.rents = rents);
    }

    ngOnInit() {
        this.getRents();
    }

}
