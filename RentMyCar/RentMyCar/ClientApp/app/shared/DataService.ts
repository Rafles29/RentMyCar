import { Injectable, Inject } from "@angular/core";
import 'rxjs/add/operator/map'

import { User } from './user';

@Injectable()
export class DataService {

    constructor() {
    }

    private users: User[] = [];
}
