import { Injectable } from '@angular/core';

@Injectable()
export class BearerService {

    constructor() { }

    getAuthHeader(): string {
        let token = localStorage.getItem('Token');
        console.log(token);
        if (token) {
            return "Bearer " + token;
        }
        else {
            throw new Error("Noone is logged in");
        }
    }
}
