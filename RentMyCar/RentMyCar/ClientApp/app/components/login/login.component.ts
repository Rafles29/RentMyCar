import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { AuthenticationService } from '../../shared/services/authentication.service';
import { AlertService } from '../../shared/services/alert.service';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
    selector: 'login',
    providers: [
        AuthenticationService
    ],
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit{

    model: any = {};
    loading = false;
    returnUrl: string;

    constructor(
        private route: ActivatedRoute,
        private router: Router,
        private authenticationService: AuthenticationService,
        private alertService: AlertService) { }

    ngOnInit() {
        // reset login status
        this.authenticationService.logout();

        // get return url from route parameters or default to '/'
        this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
    }

    login() {
        this.loading = true;
        this.authenticationService.login(this.model.userName, this.model.password)
            .subscribe(
            data => {
                this.router.navigate([this.returnUrl]);
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
