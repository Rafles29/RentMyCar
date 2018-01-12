import { Price } from './price';
import { Equipment } from './equipment';
import { Performance } from './performance';
import { Rent } from './rent';

export interface Car {
    carId: number;
    manufactor: string;
    model: string;
    year: number;
    avatarImage: string;
    performance: Performance;
    equipment: Equipment;
    price: Price;
    userName: string;
    rents: Rent[];
}