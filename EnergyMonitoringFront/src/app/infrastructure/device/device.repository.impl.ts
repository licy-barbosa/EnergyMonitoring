import { map, Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { DeviceMapper } from './mappers/device.mapper';
import { ENVIRONMENT } from '@core/config/environment.token';
import { Device } from '@domain/device/models/device.model';
import { DeviceDto } from '@infrastructure/device/dtos/device.response.dto';
import { DeviceRepository } from '@domain/solar-panel/repositories/device.repository';

@Injectable()
export class DeviceRepositoryImpl implements DeviceRepository {
    private http = inject(HttpClient);
    private env = inject(ENVIRONMENT);
    private url = `${this.env.apiUrl}/devices`;

    getAll(id: string): Observable<Device[]> {
        return this.http.get<DeviceDto[]>(`${this.url}/bySolarPlant/${id}`).pipe(
            map(dtos => dtos.map(DeviceMapper.toDomain))
        );
    }

    getById(id: string): Observable<Device> {
        return this.http.get<DeviceDto>(`${this.url}/${id}`).pipe(
            map(DeviceMapper.toDomain)
        );
    }

    create(device: Device): Observable<Device> {
        const dto = DeviceMapper.toDto(device);

        return this.http.post<DeviceDto>(this.url, dto).pipe(
            map(DeviceMapper.toDomain)
        );
    }

    update(id: string, device: Device): Observable<Device> {
        const dto = DeviceMapper.toDto(device);

        return this.http.put<DeviceDto>(`${this.url}/${id}`, dto).pipe(
            map(DeviceMapper.toDomain)
        );
    }
}