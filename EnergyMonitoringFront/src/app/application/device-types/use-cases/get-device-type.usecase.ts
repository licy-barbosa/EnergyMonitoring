import { inject, Injectable } from '@angular/core';
import { DEVICE_TYPES_REPOSITORY } from '@domain/device-type/repositories/device-types.repository';

@Injectable({ providedIn: 'root' })
export class GetDeviceTypesUseCase {
     private repo = inject(DEVICE_TYPES_REPOSITORY);

    execute() {
        return this.repo.getAll();
    }
}