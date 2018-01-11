import { Car } from './car';
import { Rent } from './rent';

export interface User {
    userName: string;
    email: string;
    firstName: string;
    lastName: string;
    cars: Car[];
    rents: Rent[];
}