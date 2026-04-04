import { Observable } from 'rxjs';
import { Injectable, inject } from '@angular/core';
import { Device } from '@domain/device/models/device.model';
import { GetDevicesUseCase } from '@application/devices/use-cases/get-device.usecase';
import { GetDeviceByIdUseCase } from '@application/devices/use-cases/get-device-by-id.usecase';
import { CreateDeviceUseCase } from '@application/devices/use-cases/create-device.usecase';
import { UpdateDeviceUseCase } from '@application/devices/use-cases/update-device.usecase';

@Injectable({ providedIn: 'root' })
export class DeviceFacade {
    private getAllUC = inject(GetDevicesUseCase);
    private createUC = inject(CreateDeviceUseCase);
    private getByIdUC = inject(GetDeviceByIdUseCase);
    private updateUC = inject(UpdateDeviceUseCase);

    loadDevices(id: string): Observable<Device[]> {
        return this.getAllUC.execute(id);
    }

    getDeviceById(id: string): Observable<Device> {
        return this.getByIdUC.execute(id);
    }

    createDevice(device: Device): Observable<Device> {
        return this.createUC.execute(device);
    }

    updateDevice(id: string, device: Device): Observable<Device> {
        console.log('1 Facade updateDevice called with id:', id, 'and device:', device);
        return this.updateUC.execute(id, device);
    }
}