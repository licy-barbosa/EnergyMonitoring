import { Component, inject } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from "@angular/material/card";
import { MatIconModule } from "@angular/material/icon";
import { RouterModule } from '@angular/router';
import { APP_INFO } from '../../../core/config/app-info.token';
import { SeoService } from '@core/seo/seo.service';

@Component({
    selector: 'app-not-found',
    standalone: true,
    imports: [ MatCardModule, MatButtonModule, MatIconModule, RouterModule],
    templateUrl: './not-found.component.html',
    styleUrl: './not-found.component.css'
})
export class NotFoundComponent {
    appName = inject(APP_INFO).name;

    constructor(private seo: SeoService) {
        this.seo.setNotFound();
    }
}