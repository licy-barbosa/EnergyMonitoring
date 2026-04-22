import { Observable } from 'rxjs';
import { InjectionToken } from '@angular/core';
import { DeviceType } from '../models/device-type.model';
import { SelectDeviceType } from '../models/select-device-type.model';
import { CreateDeviceType } from '../models/create-device-type.model';

export interface DeviceTypeRepository {
    getAll(): Observable<SelectDeviceType[]>;
    getById(id: number): Observable<DeviceType>;
    create(type: CreateDeviceType): Observable<DeviceType>;
    update(id: number, type: DeviceType): Observable<DeviceType>;
    delete(id: number): Observable<void>;
}

 export const DEVICE_TYPES_REPOSITORY =
   new InjectionToken<DeviceTypeRepository>('DEVICE_TYPES_REPOSITORY');