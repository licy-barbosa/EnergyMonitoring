import { Inject, Injectable } from '@angular/core';
import { Meta, Title } from '@angular/platform-browser';
import { APP_INFO, AppInfo } from '@core/config';

export interface SeoUpdate {
    title?: string;
    description?: string;
    keywords?: string;
    noIndex?: boolean;
}

@Injectable({ providedIn: 'root' })
export class SeoService {
    constructor(
        private title: Title,
        private meta: Meta,
        @Inject(APP_INFO) private appInfo: AppInfo
    ) {}

    update(config: SeoUpdate): void {
        const title = config.title
        ? `${config.title} | ${this.appInfo.name}`
        : this.appInfo.name;

        this.title.setTitle(title);

        if (config.description) {
        this.meta.updateTag({
            name: 'description',
            content: config.description
        });
        }

        if (config.keywords) {
        this.meta.updateTag({
            name: 'keywords',
            content: config.keywords
        });
        }

        if (config.noIndex) {
        this.meta.updateTag({
            name: 'robots',
            content: 'noindex, nofollow'
        });
        }
    }

    setHome(): void {
        this.update({
        title: 'Inicio',
        description: this.appInfo.description
        });
    }

    setNotFound(): void {
        this.update({
        title: 'Página no encontrada',
        description: 'La página que buscas no existe',
        noIndex: true
        });
    }
}