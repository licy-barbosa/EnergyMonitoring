import { Observable } from 'rxjs';
import { CommonModule } from '@angular/common';
import { ActivatedRoute, Router } from '@angular/router';
import { Component, inject, OnInit } from '@angular/core';
import { LucideAngularModule, Cpu, Plus, Edit2, MapPin, Zap, X } from 'lucide-angular';
import { FormBuilder, FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { DeviceFacade } from '@application/devices/facades/device.facade';
import { Device } from '@domain/device/models/device.model';
import { DeviceModalComponent } from '../device-modal/device-modal.component';
import { DeviceTypeFacade } from '@application/device-types/facades/device-type.facede';
import { SelectDeviceType } from '@domain/device-type/models/select-device-type.model';

type DeviceFormGroup = FormGroup<{
    id: FormControl<string | null>;
    name: FormControl<string>;
    description: FormControl<string | null>;
    deviceTypeId: FormControl<number | null>;
    ratedPowerWatts: FormControl<number | null>;
}>;

@Component({
    selector: 'app-devices',
    standalone: true,
    imports: [CommonModule, LucideAngularModule, ReactiveFormsModule, DeviceModalComponent],
    templateUrl: './devices.component.html',
    styleUrl: './devices.component.css'
})

export class DevicesComponent implements OnInit {
    constructor(private route: ActivatedRoute) {}
    private fb = inject(FormBuilder);
    private facade = inject(DeviceFacade);
    private deviceTypeService = inject(DeviceTypeFacade);
    private router = inject(Router);

    readonly Cpu = Cpu;
    readonly Plus = Plus;
    readonly Edit2 = Edit2;
    readonly MapPin = MapPin;
    readonly Zap = Zap;
    readonly X = X;

    // STATE
    isModalOpen = false;
    isEditMode = false;
    selectedId: string | null = null;
    devices$!: Observable<Device[]>;
    plantId: string | null = null;
    deviceTypes:  SelectDeviceType[] = [];

    deviceForm!: FormGroup<{
        name: FormControl<string>;
        description: FormControl<string | null>;
        ratedPowerWatts: FormControl<number | null>;
        deviceTypeId: FormControl<number | null>;
        isActive: FormControl<boolean>;
    }>;

    ngOnInit(){
        this.route.paramMap.subscribe(params => {
            this.plantId = params.get('plantId');
        });

        this.buildForm();
        this.loadSystems(this.plantId!);
        this.loadTypes();
    }

    // ===============================
    // FORM BUILDER
    // ===============================
    private buildForm() {
        this.deviceForm = this.fb.group({
            name: this.fb.nonNullable.control('', Validators.required),
            description: new FormControl<string | null>(null),
            ratedPowerWatts: new FormControl<number | null>(null),
            deviceTypeId: [0, Validators.required],
            isActive: this.fb.nonNullable.control(true)
        });
    }

    // ===============================
    // MODAL CONTROL
    // ===============================
    openModal() {
        this.isEditMode = false;
        this.selectedId = null;

        this.deviceForm.reset({
            name: '',
            description: '',
            ratedPowerWatts: 0,
            deviceTypeId: 0,
            isActive: true
        });

        this.isModalOpen = true;
    }

    closeModal() {
        this.isModalOpen = false;
    }

    // ===============================
    // EDIT
    // ===============================
    editDevice(id: string) {
        this.isEditMode = true;
        this.selectedId = id;

        this.facade.getDeviceById(id).subscribe(device => {
            this.deviceForm.patchValue({
                name: device.name,
                description: device.description,
                ratedPowerWatts: device.ratedPowerWatts,
                deviceTypeId: device.deviceTypeId, 
                isActive: device.isActive
            });

            this.isModalOpen = true;
        });
    }

    onSubmit() {
        if (this.deviceForm.invalid) return;

        const form = this.deviceForm.getRawValue();

        const device: Device = {
            id: Math.random().toString(36).substr(2, 9),
            name: form.name,
            description: form.description ?? '',
            ratedPowerWatts: form.ratedPowerWatts ?? 0,
            deviceTypeId: form.deviceTypeId ?? 0,
            isActive: !!form.isActive,
            solarPlantId: this.plantId!
        };

        const request$ =
        this.isEditMode && this.selectedId
        ? this.facade.updateDevice(this.selectedId, device)
        : this.facade.createDevice(device);
    
        request$.subscribe(() => this.afterSave());
    }

    // ===============================
    // LOAD LIST
    // ===============================
    loadSystems(plantId: string) {
        this.devices$ = this.facade.loadDevices(plantId);
    }

    loadTypes() {
        this.deviceTypeService.loadDeviceTypes().subscribe(data => {
            this.deviceTypes = data;
        });
    }

    // ===============================
    // AFTER SAVE
    // ===============================
    afterSave() {
        this.closeModal();
        this.loadSystems(this.plantId!);
    }

    onTypeCreated(newType: any) {
        // 🔥 agregar al select principal
        this.deviceTypes.push(newType);

        // 🔥 seleccionar automáticamente en el form REAL
        this.deviceForm.patchValue({
            deviceTypeId: newType.id
        });
    }
}