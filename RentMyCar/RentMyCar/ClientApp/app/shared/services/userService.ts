import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';

import { User } from '../models/user';


@Injectable()
export class UserService {
    constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

    public getUsers(): Observable<User[]> {
        return this.http.get<User[]>(this.baseUrl + "api/users/");
    }

    public getUser(id: number): Observable<User> {
        return this.http.get<User>(this.baseUrl + "api/users/" + id);
    }

    public register(user: User) {
        return this.http.post(this.baseUrl + "api/account/register", user);
    }
}