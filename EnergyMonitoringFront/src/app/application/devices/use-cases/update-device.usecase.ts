import { Observable } from "rxjs";
import { inject, Injectable } from "@angular/core";
import { DEVICE_REPOSITORY } from "@domain/solar-panel/repositories/device.repository";
import { Device } from "@domain/device/models/device.model";

@Injectable({ providedIn: 'root' })
export class UpdateDeviceUseCase {
    private repo = inject(DEVICE_REPOSITORY);

    execute(id: string, device: Device): Observable<Device> {
        return this.repo.update(id, device);
    }
}