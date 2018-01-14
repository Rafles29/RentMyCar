import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map'

@Injectable()
export class AuthenticationService {

    constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

    login(username: string, password: string) {
        return this.http.post<any>('api/account/authenticate', { username: username, password: password })
            .map(token => {
                // login successful if there's a jwt token in the response
                if (token && token.token) {
                    // store user details and jwt token in local storage to keep user logged in between page refreshes
                    localStorage.setItem('Token', token.token);
                }
                return token;
            });
    }

    logout() {
        // remove user from local storage to log user out
        localStorage.removeItem('Token');
    }
}
