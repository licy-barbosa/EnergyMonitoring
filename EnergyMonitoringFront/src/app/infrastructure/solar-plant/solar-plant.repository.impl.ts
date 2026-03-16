import { map, Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';

import { SolarPlantDto } from './dtos/solar-plant.response.dto';
import { ENVIRONMENT } from '@core/config/environment.token';
import {  SolarPlant } from '@domain/solar-plant/models/solar-plant.model';
import { SolarPlantMapper } from '@infrastructure/solar-plant/mappers/solar-plant.mapper';
import { SolarPlantRepository } from '@domain/solar-plant/repositories/solar-plant.repository';

@Injectable()
export class SolarPlantRepositoryImpl implements SolarPlantRepository {
    private http = inject(HttpClient);
    private env = inject(ENVIRONMENT);
    private url = `${this.env.apiUrl}/solarplants`;

    getAll(): Observable<SolarPlant[]> {
        return this.http.get<SolarPlantDto[]>(this.url).pipe(
            map(dtos => dtos.map(SolarPlantMapper.toDomain))
        );
    }

    getById(id: string): Observable<SolarPlant> {
        return this.http.get<SolarPlantDto>(`${this.url}/${id}`).pipe(
            map(SolarPlantMapper.toDomain)
        );
    }

    create(plant: SolarPlant): Observable<SolarPlant> {
        const dto = SolarPlantMapper.toDto(plant);

        return this.http.post<SolarPlantDto>(this.url, dto).pipe(
            map(SolarPlantMapper.toDomain)
        );
    }

    update(id: string, plant: SolarPlant): Observable<SolarPlant> {
        const dto = SolarPlantMapper.toDto(plant);

        return this.http.put<SolarPlantDto>(`${this.url}/${id}`, dto).pipe(
            map(SolarPlantMapper.toDomain)
        );
    }
}