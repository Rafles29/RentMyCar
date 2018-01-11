import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.css']
})
export class LoginComponent {

    constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {        
        
    }
}
