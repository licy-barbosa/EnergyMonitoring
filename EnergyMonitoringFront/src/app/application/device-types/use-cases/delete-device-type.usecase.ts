import { Observable } from 'rxjs';
import { inject, Injectable } from '@angular/core';
import { DEVICE_TYPES_REPOSITORY } from '@domain/device-type/repositories/device-types.repository';

@Injectable({ providedIn: 'root' })
export class DeleteDeviceTypeUseCase {
    private repository = inject(DEVICE_TYPES_REPOSITORY);

    execute(id: number): Observable<void> {
        return this.repository.delete(id);
    }
}
