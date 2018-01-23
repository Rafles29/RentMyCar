import { Pipe, PipeTransform } from '@angular/core';
import { Car } from '../models/car';

@Pipe({
    name: 'carsPipe',
    pure: false
})
export class CarsPipe implements PipeTransform {

    transform(items: Car[], filter: Car, pMin: number, pMax: number): Car[] {
        console.log("ej");
        if (!items || !filter) {
            console.log("nope");
            return items;
        }
        console.log("yep");
        return items.filter((item: Car) => this.applyFilter(item, filter, pMin, pMax));
    }

    applyFilter(car: Car, filter: Car, pMin: number, pMax: number): boolean {
        if (filter.carId) {
            if (car.carId !== filter.carId) {
                return false;
            }
        }
        if (filter.year) {
            if (car.year < filter.year) {
                return false;
            }
        }
        if (pMin) {
            if (car.price.shortTermPrice < pMin) {
                return false;
            }
        }
        if (pMax) {
            if (car.price.shortTermPrice > pMax) {
                return false;
            }
        }
        if (filter.manufactor) {
            if (car.manufactor.toLowerCase().indexOf(filter.manufactor.toLowerCase()) === -1) {
                return false;
            }
        }
        if (filter.model) {
            if (car.model.toLowerCase().indexOf(filter.model.toLowerCase()) === -1) {
                return false;
            }
        }
        return true;
    }

}
