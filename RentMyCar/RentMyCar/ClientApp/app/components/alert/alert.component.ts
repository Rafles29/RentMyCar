import { Component, OnInit } from '@angular/core';
import { AlertService } from '../../shared/services/alert.service';

@Component({
    selector: 'app-alert',
    providers: [
        AlertService
    ],
    templateUrl: './alert.component.html',
    styleUrls: ['./alert.component.css']
})

export class AlertComponent implements OnInit{
    message: any;

    constructor(private alertService: AlertService) { }

    ngOnInit() {
        this.alertService.getMessage().subscribe(message => { this.message = message; });
    }
}
