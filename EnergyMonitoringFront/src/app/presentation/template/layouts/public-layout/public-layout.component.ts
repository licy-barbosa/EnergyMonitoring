import { CommonModule } from '@angular/common';
import { RouterOutlet } from "@angular/router";
import { Component, Input } from '@angular/core';

@Component({
    selector: 'app-layout',
    standalone: true,
    imports: [ RouterOutlet, CommonModule],
    templateUrl: './public-layout.component.html',
    styleUrl: './public-layout.component.css'
})

export class PublicLayoutComponent {
    @Input() showHeader = true;
    @Input() showFooter = true;
}