import { Observable } from "rxjs";
import { inject, Injectable } from "@angular/core";
import { DeviceType } from "@domain/device-type/models/device-type.model";
import { DEVICE_TYPES_REPOSITORY } from "@domain/device-type/repositories/device-types.repository";

@Injectable({ providedIn: 'root' })
export class UpdateDeviceTypeUseCase {
    private repo = inject(DEVICE_TYPES_REPOSITORY);

    execute(id: number, device: DeviceType): Observable<DeviceType> {
        return this.repo.update(id, device);
    }
}