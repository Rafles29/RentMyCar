import { Component } from '@angular/core';
import { BearerService } from '../../shared/services/bearer.service';

@Component({
    selector: 'home',
    providers: [
        BearerService
    ],
    templateUrl: './home.component.html'
})
export class HomeComponent {

    constructor(private bearerService: BearerService) {
    }

    getLocalUser(): void {
        try {
            alert(this.bearerService.getAuthHeader());
        } catch (e) {
            alert(e);
        }
    }
}
