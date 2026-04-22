import { CommonModule } from '@angular/common';
import { LucideAngularModule, X, Plus, Pencil, Trash2 } from 'lucide-angular';
import { FormGroup, ReactiveFormsModule } from '@angular/forms';
import { Component, EventEmitter,  inject,  Input, Output } from '@angular/core';
import { CreateDeviceType } from '@domain/device-type/models/create-device-type.model';
import { DeviceTypeFacade } from '@application/device-types/facades/device-type.facede';
import { DeviceTypeModalComponent } from '../device-type-modal/device-type-modal.component';

@Component({
    selector: 'app-device-modal',
    standalone: true,
    imports: [CommonModule, LucideAngularModule, ReactiveFormsModule, DeviceTypeModalComponent],
    templateUrl: './device-modal.component.html',
    styleUrl: './device-modal.component.css'
})

export class DeviceModalComponent {
    readonly X = X;
    readonly Plus = Plus;
    readonly Pencil = Pencil;
    readonly Trash2 = Trash2;

    @Input() isModalOpen = false;
    @Input() isEditMode = false;
    @Input() deviceForm!: FormGroup;
    @Input() deviceTypes: any[] = [];

    @Output() closeModal = new EventEmitter<void>();
    @Output() submitForm = new EventEmitter<void>();
    @Output() deviceTypeCreated = new EventEmitter<any>();

    private deviceTypeService = inject(DeviceTypeFacade);

    isDeviceTypeModalOpen = false;

    deviceTypeToEdit: any = null;

    openDeviceTypeModal() {
        this.deviceTypeToEdit = null;
        this.isDeviceTypeModalOpen = true;
    }

    editSelectedDeviceType() {
        const typeId = this.deviceForm.get('deviceTypeId')?.value;
        if (!typeId) return;
        
        this.deviceTypeService.getDeviceById(typeId).subscribe(data => {
            this.deviceTypeToEdit = data;
            this.isDeviceTypeModalOpen = true;
        });
    }

    deleteSelectedDeviceType() {
        const typeId = this.deviceForm.get('deviceTypeId')?.value;
        if (!typeId) return;

        if (confirm('¿Estás seguro de que deseas eliminar este tipo de dispositivo?')) {
            this.deviceTypeService.deleteDevice(typeId).subscribe(() => {
                // Emit event to notify parent
                this.deviceTypeCreated.emit();
                this.deviceForm.get('deviceTypeId')?.setValue(0);
            });
        }
    }

    closeDeviceTypeModal() {
        this.isDeviceTypeModalOpen = false;
        this.deviceTypeToEdit = null;
    }

    onDeviceTypeSubmit(data: CreateDeviceType) {
        if (this.deviceTypeToEdit) {
            this.deviceTypeService.updateDevice(this.deviceTypeToEdit.id, { id: this.deviceTypeToEdit.id, ...data } as any).subscribe((res) => {
                const updatedType = { id: res.id, name: res.name };
                this.deviceTypeCreated.emit(updatedType);
                this.closeDeviceTypeModal();
            });
        } else {
            this.deviceTypeService.createDevice(data).subscribe((res) => {
                const newType = { id: res.id, name: res.name };
                this.deviceTypeCreated.emit(newType);
                this.closeDeviceTypeModal();
            });
        }
    }
}