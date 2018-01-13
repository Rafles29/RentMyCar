import { Component } from '@angular/core';
import { Router } from '@angular/router';

import { UserService } from '../../shared/services/userService';
import { AlertService } from '../../shared/services/alert.service';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
    selector: 'app-register',
    providers: [
        UserService,
        AlertService
    ],
    templateUrl: './register.component.html',
    styleUrls: ['./register.component.css']
})

export class RegisterComponent {
    model: any = {};
    loading = false;

    constructor(
        private router: Router,
        private userService: UserService,
        private alertService: AlertService) { }

    register() {
        this.loading = true;
        this.userService.register(this.model)
            .subscribe(
            data => {
                // set success message and pass true paramater to persist the message after redirecting to the login page
                this.alertService.success('Registration successful', true);
                this.router.navigate(['/login']);
            },
            (err: HttpErrorResponse) => {
                if (err.error instanceof Error) {
                    // A client-side or network error occurred. Handle it accordingly.
                    this.alertService.error('An error occurred:' + err.error.message);
                    console.log('An error occurred:', err.error.message);
                    this.loading = false;
                } else {
                    // The backend returned an unsuccessful response code.
                    // The response body may contain clues as to what went wrong,
                    this.alertService.error(`Backend returned code ${err.status}, body was: ${err.error}`);
                    console.log(`Backend returned code ${err.status}, body was: ${err.error}`);
                    this.loading = false;
                }
            });
    }
}