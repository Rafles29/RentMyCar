import { Component, Inject, OnInit } from '@angular/core';

import { DataService } from '../../shared/dataService';
import { User } from '../../shared/user';

@Component({
    selector: 'users',
    providers: [
        DataService
    ],
    templateUrl: './users.component.html'
})
export class UsersComponent implements OnInit{
    users: User[];

    constructor(private data: DataService) {
    }

    public getUsers(): void {
        this.data.getUsers().subscribe(users => this.users = users);
    }

    ngOnInit() {
        this.getUsers();
    }
}