import { Component, Inject, OnInit } from '@angular/core';

import { UserService } from '../../shared/services/userService';
import { User } from '../../shared/models/user';

@Component({
    selector: 'users',
    providers: [
        UserService
    ],
    templateUrl: './users.component.html'
})
export class UsersComponent implements OnInit{
    users: User[];

    constructor(private userService: UserService) {
    }

    public getUsers(): void {
        this.userService.getUsers().subscribe(users => this.users = users);
    }

    ngOnInit() {
        this.getUsers();
    }
}