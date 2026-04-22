import { routes } from './app.routes';
import { APP_INFO } from '@core/config/app-info.token';
import { ENVIRONMENT } from '@core/config/environment.token';
import { MAT_FAB_DEFAULT_OPTIONS } from '@angular/material/button';
import { provideRouter, withComponentInputBinding } from '@angular/router';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { provideHttpClient, withFetch, withInterceptors } from '@angular/common/http';
import { authInterceptor } from './core/auth/interceptors/auth.interceptor';
import { provideReadingsFeature } from './application/readings/readings.providers';
import { SecurityService } from '@core/auth/services/security.service';
import { SOLAR_PLANT_PROVIDERS } from '@infrastructure/solar-plant/solar-plant.provider';
import { DeviceRepositoryImpl } from '@infrastructure/device/device.repository.impl';
import { DEVICE_REPOSITORY } from '@domain/solar-panel/repositories/device.repository';

import {
  ApplicationConfig,
  provideZoneChangeDetection,
  APP_INITIALIZER,
} from '@angular/core';
import { DeviceTypeRepositoryImpl } from '@infrastructure/device-type/device-type.repository.impl';
import { DEVICE_TYPES_REPOSITORY } from '@domain/device-type/repositories/device-types.repository';

export const appConfig: ApplicationConfig = {
    providers: [
        provideZoneChangeDetection({ eventCoalescing: true }),
        provideRouter(routes, withComponentInputBinding()),
        provideAnimationsAsync(),

        provideHttpClient(withFetch(), withInterceptors([authInterceptor])),

        { provide: MAT_FAB_DEFAULT_OPTIONS, useValue: { subscriptSizing: 'dynamic' } },

        {
        provide: APP_INITIALIZER,
        useFactory: (security: SecurityService) => () => security.restoreSession(),
        deps: [SecurityService],
        multi: true
        },

        {
        provide: APP_INFO,
        useValue: {
            name: 'EnergyMonitoring',
            version: '1.0.0',
            environment: 'prod'
        }
        },

        {
        provide: ENVIRONMENT,
            useValue: {
                apiUrl: 'https://localhost:7104/api',
                production: true
            }
        },
        {
            provide: DEVICE_REPOSITORY,
            useClass: DeviceRepositoryImpl
        },

        {
            provide: DEVICE_TYPES_REPOSITORY,
            useClass: DeviceTypeRepositoryImpl
        },

        SOLAR_PLANT_PROVIDERS,
        ...provideReadingsFeature()
    ]
};