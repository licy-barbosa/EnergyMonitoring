import { Observable } from 'rxjs';
import { Injectable, inject } from '@angular/core';
import { SolarPlant } from '@domain/solar-plant/models/solar-plant.model';
import { GetSolarPlantsUseCase } from '../use-cases/get-solar-plants.usecase';
import { CreateSolarPlantUseCase } from '@application/solar-plant/use-cases/create-solar-plant.usecase';
import { GetSolarPlantByIdUseCase } from '@application/solar-plant/use-cases/get-solar-plant-by-id.usecase';
import { UpdateSolarPlantUseCase } from '@application/solar-plant/use-cases/update-solar-plant.usecase';

@Injectable({ providedIn: 'root' })
export class SolarPlantFacade {
    private getAllUC = inject(GetSolarPlantsUseCase);
    private createUC = inject(CreateSolarPlantUseCase);
    private getByIdUC = inject(GetSolarPlantByIdUseCase);
    private updateUC = inject(UpdateSolarPlantUseCase);

    loadPlants(): Observable<SolarPlant[]> {
        return this.getAllUC.execute();
    }

    getPlantById(id: string): Observable<SolarPlant> {
        return this.getByIdUC.execute(id);
    }

    createPlant(plant: SolarPlant): Observable<SolarPlant> {
        return this.createUC.execute(plant);
    }

    updatePlant(id: string, plant: SolarPlant): Observable<SolarPlant> {
        return this.updateUC.execute(id, plant);
    }
}