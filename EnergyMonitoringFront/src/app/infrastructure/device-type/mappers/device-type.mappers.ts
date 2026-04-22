import { DeviceType } from "@domain/device-type/models/device-type.model";
import { DeviceTypeDto } from "../dtos/device-type.response.dto";

export class DeviceTypeMapper {
    static toDomain(dto: DeviceTypeDto): DeviceType {
        return dto;
    }

    static toDto(model: DeviceType): DeviceTypeDto {
        return model;
    }
}