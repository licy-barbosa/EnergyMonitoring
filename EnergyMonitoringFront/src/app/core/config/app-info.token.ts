import { InjectionToken } from '@angular/core';

export interface AppInfo {
    name: string;
    shortName?: string;
    description?: string;
    version: string;
    environment: 'dev' | 'qa' | 'prod';
}

export const APP_INFO = new InjectionToken<AppInfo>('APP_INFO');