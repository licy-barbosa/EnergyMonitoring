import { CommonModule } from '@angular/common';
import { LucideAngularModule, X } from 'lucide-angular';
import { Component, EventEmitter,  Input, Output } from '@angular/core';
import { FormArray, FormGroup, ReactiveFormsModule } from '@angular/forms';

@Component({
    selector: 'app-solar-system-modal',
    standalone: true,
    imports: [CommonModule, LucideAngularModule, ReactiveFormsModule],
    templateUrl: './solar-system-modal.component.html',
    styleUrl: './solar-system-modal.component.css'
})

export class SolarSystemModalComponent {
    readonly X = X;

    @Input() isModalOpen = false;
    @Input() isEditMode = false;
    @Input() systemForm!: FormGroup;
    @Input() totalPowerKw!: number;
    @Input() panels!: FormArray;

    @Output() closeModal = new EventEmitter<void>();
    @Output() submitForm = new EventEmitter<void>();
    @Output() addPanel = new EventEmitter<void>();
    @Output() removePanel = new EventEmitter<number>();
}