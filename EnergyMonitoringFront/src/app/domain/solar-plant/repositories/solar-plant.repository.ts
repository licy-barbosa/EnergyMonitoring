import { Observable } from 'rxjs';
import { InjectionToken } from '@angular/core';
import {  SolarPlant } from '../models/solar-plant.model';

export interface SolarPlantRepository {
    getAll(): Observable<SolarPlant[]>;
    getById(id: string): Observable<SolarPlant>;
    create(plant: SolarPlant): Observable<SolarPlant>;
    update(id: string, plant: SolarPlant): Observable<SolarPlant>;
}

export const SOLAR_PLANT_REPOSITORY =
  new InjectionToken<SolarPlantRepository>('SOLAR_PLANT_REPOSITORY');