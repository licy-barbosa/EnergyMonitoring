import { CommonModule } from '@angular/common';
import { RouterOutlet } from "@angular/router";
import { Component, Input } from '@angular/core';
import { SidebarComponent } from '../../sidebar/sidebar.component';

@Component({
    selector: 'app-layout',
    standalone: true,
    imports: [ RouterOutlet, CommonModule, SidebarComponent],
    templateUrl: './private-layout.component.html',
    styleUrl: './private-layout.component.css'
})

export class PrivateLayoutComponent {
    @Input() showHeader = true;
    @Input() showFooter = true;
}