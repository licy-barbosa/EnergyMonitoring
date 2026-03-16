import { Observable } from "rxjs";
import { inject, Injectable } from "@angular/core";
import { SolarPlant } from "@domain/solar-plant/models/solar-plant.model";
import { SOLAR_PLANT_REPOSITORY } from "@domain/solar-plant/repositories/solar-plant.repository";

@Injectable({ providedIn: 'root' })
export class UpdateSolarPlantUseCase {
    private repo = inject(SOLAR_PLANT_REPOSITORY);

    execute(id: string, plant: SolarPlant): Observable<SolarPlant> {
        return this.repo.update(id, plant);
    }
}