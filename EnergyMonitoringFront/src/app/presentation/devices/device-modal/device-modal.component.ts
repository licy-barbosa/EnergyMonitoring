import { CommonModule } from '@angular/common';
import { LucideAngularModule, X } from 'lucide-angular';
import { FormGroup, ReactiveFormsModule } from '@angular/forms';
import { Component, EventEmitter,  Input, Output } from '@angular/core';

@Component({
    selector: 'app-device-modal',
    standalone: true,
    imports: [CommonModule, LucideAngularModule, ReactiveFormsModule],
    templateUrl: './device-modal.component.html',
    styleUrl: './device-modal.component.css'
})

export class DeviceModalComponent {
    readonly X = X;

    @Input() isModalOpen = false;
    @Input() isEditMode = false;
    @Input() deviceForm!: FormGroup;

    @Output() closeModal = new EventEmitter<void>();
    @Output() submitForm = new EventEmitter<void>();
}