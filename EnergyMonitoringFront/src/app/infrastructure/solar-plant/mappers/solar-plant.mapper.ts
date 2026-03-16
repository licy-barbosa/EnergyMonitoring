import { SolarPlant } from '@domain/solar-plant/models/solar-plant.model';
import { SolarPlantDto } from '@infrastructure/solar-plant/dtos/solar-plant.response.dto';

export class SolarPlantMapper {
    static toDomain(dto: SolarPlantDto): SolarPlant {
        return dto;
    }

    static toDto(model: SolarPlant): SolarPlantDto {
        return model;
    }
}