import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';

import { BearerService } from './bearer.service';
import { Rent } from '../models/rent';
import { Car } from '../models/car';

@Injectable()
export class RentService {

    constructor(
        private http: HttpClient,
        @Inject('BASE_URL') private baseUrl: string,
        private bearerService: BearerService) { }

    private _selectedCar: number;

    get selectedCar(): number {
        return this._selectedCar;
    }
    set selectedRent(car: number) {
        this._selectedCar = car;
    }

    public getMyRents(): Observable<Rent[]> {
        return this.http.get<Rent[]>(this.baseUrl + "api/Rents/", {
            headers: new HttpHeaders().set('Authorization', this.bearerService.getAuthHeader()),
        });
    }

    public getMyRent(id: any): Observable<Rent> {
        return this.http.get<Rent>(this.baseUrl + "api/Rents/" + id, {
            headers: new HttpHeaders().set('Authorization', this.bearerService.getAuthHeader()),
        });
    }

    public postRent(rent: Rent) {
        return this.http.post(this.baseUrl + "api/Rents/", rent, {
            headers: new HttpHeaders().set('Authorization', this.bearerService.getAuthHeader()),
        });
    }

}
