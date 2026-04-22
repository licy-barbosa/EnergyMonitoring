import { Observable } from 'rxjs';
import { Injectable, inject } from '@angular/core';
import { DeviceType } from '@domain/device-type/models/device-type.model';
import { SelectDeviceType } from '@domain/device-type/models/select-device-type.model';
import { GetDeviceTypesByIdUseCase } from '@application/device-types/use-cases/get-device-type-by-id.usecase';
import { CreateDeviceType } from '@domain/device-type/models/create-device-type.model';
import { GetDeviceTypesUseCase } from '@application/device-types/use-cases/get-device-type.usecase';
import { CreateDeviceTypeUseCase } from '@application/device-types/use-cases/create-device-type-usecase';
import { UpdateDeviceTypeUseCase } from '@application/device-types/use-cases/update-device-type.usecase';
import { DeleteDeviceTypeUseCase } from '@application/device-types/use-cases/delete-device-type.usecase';

@Injectable({ providedIn: 'root' })
export class DeviceTypeFacade {
    private getAllUC = inject(GetDeviceTypesUseCase);
    private createUC = inject(CreateDeviceTypeUseCase);
    private getByIdUC = inject(GetDeviceTypesByIdUseCase);
    private updateUC = inject(UpdateDeviceTypeUseCase);
    private deleteUC = inject(DeleteDeviceTypeUseCase);

    loadDeviceTypes(): Observable<SelectDeviceType[]> {
        return this.getAllUC.execute();
    }

    getDeviceById(id: number): Observable<DeviceType> {
        return this.getByIdUC.execute(id);
    }

    createDevice(deviceType: CreateDeviceType): Observable<DeviceType> {
        return this.createUC.execute(deviceType);
    }

    updateDevice(id: number, device: DeviceType): Observable<DeviceType> {
        return this.updateUC.execute(id, device);
    }

    deleteDevice(id: number): Observable<void> {
        return this.deleteUC.execute(id);
    }
}