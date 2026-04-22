import { Observable } from 'rxjs';
import { inject, Injectable } from '@angular/core';
import { DeviceType } from '@domain/device-type/models/device-type.model';
import { DEVICE_TYPES_REPOSITORY } from '@domain/device-type/repositories/device-types.repository';
import { CreateDeviceType } from '@domain/device-type/models/create-device-type.model';

@Injectable({ providedIn: 'root' })
export class CreateDeviceTypeUseCase {
    private repo = inject(DEVICE_TYPES_REPOSITORY);

    execute(device: CreateDeviceType) : Observable<DeviceType>  {
        return this.repo.create(device);
    }
}