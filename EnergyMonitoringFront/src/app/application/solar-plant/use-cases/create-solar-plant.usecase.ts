import { Observable } from 'rxjs';
import { inject, Injectable } from '@angular/core';
import { SOLAR_PLANT_REPOSITORY } from '@domain/solar-plant/repositories/solar-plant.repository';
import { SolarPlant } from '@domain/solar-plant/models/solar-plant.model';

@Injectable({ providedIn: 'root' })
export class CreateSolarPlantUseCase {
    private repo = inject(SOLAR_PLANT_REPOSITORY);

    execute(solarPlant: SolarPlant) : Observable<SolarPlant>  {
        return this.repo.create(solarPlant);
    }
}