import { SelectDeviceType } from "@domain/device-type/models/select-device-type.model";
import { SelectDeviceTypeDto } from "@infrastructure/device-type/dtos/select-device-type.response.dto";

export class SelectDeviceTypeMapper {
    static toDomain(dto: SelectDeviceTypeDto): SelectDeviceType {
        return dto;
    }

    static toDto(model: SelectDeviceType): SelectDeviceTypeDto {
        return model;
    }
}