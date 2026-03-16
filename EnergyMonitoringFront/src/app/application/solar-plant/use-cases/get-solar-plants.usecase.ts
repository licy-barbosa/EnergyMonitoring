import { inject, Injectable } from '@angular/core';
import { SOLAR_PLANT_REPOSITORY } from '@domain/solar-plant/repositories/solar-plant.repository';

@Injectable({ providedIn: 'root' })
export class GetSolarPlantsUseCase {
  private repo = inject(SOLAR_PLANT_REPOSITORY);

  execute() {
    return this.repo.getAll();
  }
}