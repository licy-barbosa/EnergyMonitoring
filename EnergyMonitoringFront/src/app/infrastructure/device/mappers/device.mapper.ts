import { Device } from "@domain/device/models/device.model";
import { DeviceDto } from "@infrastructure/device/dtos/device.response.dto";

export class DeviceMapper {
    static toDomain(dto: DeviceDto): Device {
        return dto;
    }

    static toDto(model: Device): DeviceDto {
        return model;
    }
}