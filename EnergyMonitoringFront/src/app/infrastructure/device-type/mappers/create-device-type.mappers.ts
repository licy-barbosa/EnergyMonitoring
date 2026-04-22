import { DeviceTypeDto } from "../dtos/device-type.response.dto";
import { CreateDeviceType } from "@domain/device-type/models/create-device-type.model";

export class CreateDeviceTypeMapper {
    static toDomain(dto: DeviceTypeDto): CreateDeviceType {
        return dto;
    }

    static toDto(model: CreateDeviceType): CreateDeviceType {
        return model;
    }
}