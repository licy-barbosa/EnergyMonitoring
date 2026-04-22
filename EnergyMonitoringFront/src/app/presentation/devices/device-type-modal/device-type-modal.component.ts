import { CommonModule } from '@angular/common';
import { LucideAngularModule, X } from 'lucide-angular';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { Component, EventEmitter, Input, Output, inject } from '@angular/core';

@Component({
  selector: 'app-device-type-modal',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, LucideAngularModule],
  templateUrl: './device-type-modal.component.html',
  styleUrl: './device-type-modal.component.css'
})
export class DeviceTypeModalComponent {
    readonly X = X;
    private fb = inject(FormBuilder);

    @Input() isModalOpen = false;
    @Output() closeModal = new EventEmitter<void>();
    @Output() submitForm = new EventEmitter<{
        name: string;
        minVoltage: number;
        maxVoltage: number;
        minCurrent: number;
        maxCurrent: number;
        minPowerWatts: number;
        maxPowerWatts: number;
    }>();

    @Input() set editData(data: any) {
        if (data) {
            this.isEditMode = true;
            this.deviceTypeForm.patchValue(data);
        } else {
            this.isEditMode = false;
            this.deviceTypeForm.reset({
                name: '', minVoltage: 0, maxVoltage: 0, minCurrent: 0, maxCurrent: 0, minPowerWatts: 0, maxPowerWatts: 0
            });
        }
    }

    isEditMode = false;

    deviceTypeForm = this.fb.nonNullable.group({
        name: ['', Validators.required],
        minVoltage: [0, [Validators.required, Validators.min(0)]],
        maxVoltage: [0, [Validators.required, Validators.min(0)]],
        minCurrent: [0, [Validators.required, Validators.min(0)]],
        maxCurrent: [0, [Validators.required, Validators.min(0)]],
        minPowerWatts: [0, [Validators.required, Validators.min(0)]],
        maxPowerWatts: [0, [Validators.required, Validators.min(0)]]
    });

    onSubmit() {
        if (this.deviceTypeForm.valid) {
            this.submitForm.emit(this.deviceTypeForm.getRawValue());
            this.deviceTypeForm.reset({
                name: '', minVoltage: 0, maxVoltage: 0, minCurrent: 0, maxCurrent: 0, minPowerWatts: 0, maxPowerWatts: 0
            });
            this.closeModal.emit();
        }
    }
}