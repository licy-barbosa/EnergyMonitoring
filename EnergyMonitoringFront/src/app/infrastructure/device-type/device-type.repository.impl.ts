import { map, Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';

import { ENVIRONMENT } from '@core/config/environment.token';
import { DeviceType } from '@domain/device-type/models/device-type.model';
import { SelectDeviceTypeDto } from './dtos/select-device-type.response.dto';
import { SelectDeviceType } from '@domain/device-type/models/select-device-type.model';
import { DeviceTypeDto } from '@infrastructure/device-type/dtos/device-type.response.dto';
import { DeviceTypeMapper } from '@infrastructure/device-type/mappers/device-type.mappers';
import { DeviceTypeRepository } from '@domain/device-type/repositories/device-types.repository';
import { SelectDeviceTypeMapper } from '@infrastructure/device-type/mappers/select-device-type.mappers';
import { CreateDeviceType } from '@domain/device-type/models/create-device-type.model';
import { CreateDeviceTypeMapper } from './mappers/create-device-type.mappers';

 @Injectable()
 export class DeviceTypeRepositoryImpl implements DeviceTypeRepository {
     private http = inject(HttpClient);
     private env = inject(ENVIRONMENT);
     private url = `${this.env.apiUrl}/devicetypes`;

    getAll(): Observable<SelectDeviceType[]> {
        return this.http.get<SelectDeviceTypeDto[]>(this.url).pipe(
            map(dtos => dtos.map(SelectDeviceTypeMapper.toDomain)));
    }

    getById(id: number): Observable<DeviceType> {
        return this.http.get<DeviceTypeDto>(`${this.url}/${id}`).pipe(
            map(DeviceTypeMapper.toDomain)
        );
    }

    create(device: CreateDeviceType): Observable<DeviceType> {
        const dto = CreateDeviceTypeMapper.toDto(device);

        return this.http.post<DeviceTypeDto>(this.url, dto).pipe(
            map(DeviceTypeMapper.toDomain)
        );
    }

    update(id: number, device: DeviceType): Observable<DeviceType> {
        const dto = DeviceTypeMapper.toDto(device);

        return this.http.put<DeviceTypeDto>(`${this.url}/${id}`, dto).pipe(
            map(DeviceTypeMapper.toDomain)
        );
    }

    delete(id: number): Observable<void> {
        return this.http.delete<void>(`${this.url}/${id}`);
    }
 }

export { DeviceTypeMapper };