import { Provider } from '@angular/core';
import { SOLAR_PLANT_REPOSITORY } from '@domain/solar-plant/repositories/solar-plant.repository';
import { SolarPlantRepositoryImpl } from '@infrastructure/solar-plant/solar-plant.repository.impl';

export const SOLAR_PLANT_PROVIDERS: Provider[] = [
  {
    provide: SOLAR_PLANT_REPOSITORY,
    useClass: SolarPlantRepositoryImpl
  }
];