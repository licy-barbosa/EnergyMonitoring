import { Observable } from 'rxjs';
import { inject, Injectable } from '@angular/core';
import { DEVICE_REPOSITORY } from '@domain/solar-panel/repositories/device.repository';
import { Device } from '@domain/device/models/device.model';

@Injectable({ providedIn: 'root' })
export class CreateDeviceUseCase {
    private repo = inject(DEVICE_REPOSITORY);

    execute(device: Device) : Observable<Device>  {
        return this.repo.create(device);
    }
}