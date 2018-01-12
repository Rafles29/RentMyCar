import { Injectable, Inject } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map'

import { User } from '../models/user';
import { Car } from '../models/car';

@Injectable()
export class DataService {

    constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
    }

    public getUsers(): Observable<User[]> {
        return this.http.get<User[]>(this.baseUrl + "api/users");
    }

    public getCars(): Observable<Car[]> {
        return this.http.get<Car[]>(this.baseUrl + "api/cars");
    }
}
