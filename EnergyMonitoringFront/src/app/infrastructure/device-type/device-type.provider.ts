import { Provider } from '@angular/core';
import { DEVICE_TYPES_REPOSITORY } from '@domain/device-type/repositories/device-types.repository';
import { DeviceTypeRepositoryImpl } from '@infrastructure/device-type/device-type.repository.impl';

export const DEVICE_TYPES_PROVIDERS: Provider[] = [
  {
    provide: DEVICE_TYPES_REPOSITORY,
    useClass: DeviceTypeRepositoryImpl
  }
];