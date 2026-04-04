import { Observable } from 'rxjs';
import { InjectionToken } from '@angular/core';
import { Device } from '@domain/device/models/device.model';

export interface DeviceRepository {
    
    getAll(id: string): Observable<Device[]>;
    getById(id: string): Observable<Device>;
    create(device: Device): Observable<Device>;
    update(id: string, device: Device): Observable<Device>;
}

export const DEVICE_REPOSITORY =
  new InjectionToken<DeviceRepository>('DEVICE_REPOSITORY');