import { inject, Injectable } from '@angular/core';
import { DEVICE_REPOSITORY } from '@domain/solar-panel/repositories/device.repository';

@Injectable({ providedIn: 'root' })
export class GetDevicesUseCase {
    private repo = inject(DEVICE_REPOSITORY);

    execute(id: string) {
        return this.repo.getAll(id);
    }
}