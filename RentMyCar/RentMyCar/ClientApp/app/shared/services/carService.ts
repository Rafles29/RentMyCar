import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';

import { Car } from '../models/car';
import { BearerService } from './bearer.service'; 


@Injectable()
export class CarService {
    constructor(
        private http: HttpClient,
        @Inject('BASE_URL') private baseUrl: string,
        private bearerService: BearerService) { }

    public getCars(): Observable<Car[]> {
        return this.http.get<Car[]>(this.baseUrl + "api/Cars/");
    }

    public getMyCars(): Observable<Car[]> {
        return this.http.get<Car[]>(this.baseUrl + "api/Cars/", {
            headers: new HttpHeaders().set('Authorization', this.bearerService.getAuthHeader()),
        });
    }

    public getCar(id: any): Observable<Car> {
        return this.http.get<Car>(this.baseUrl + "api/Cars/" + id);
    }

    public postCar(car: Car) {
        return this.http.post(this.baseUrl + "api/Cars/", car);
    }

    public putCar(car: Car) {
        return this.http.put(this.baseUrl + "api/Cars/" + car.carId, car);
    }

    public deleteCar(id: number) {
        return this.http.delete(this.baseUrl + "api/Cars/" + id);
    }
}