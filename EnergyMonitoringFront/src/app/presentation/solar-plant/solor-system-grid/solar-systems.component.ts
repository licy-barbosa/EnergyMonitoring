import { 
    FormArray,
    FormBuilder, 
    FormControl, 
    FormGroup, 
    ReactiveFormsModule, 
    Validators 
} from '@angular/forms';

import { Observable } from 'rxjs';
import { CommonModule } from '@angular/common';
import { Component, inject, OnInit, HostListener } from '@angular/core';
import { Router } from '@angular/router';
import { LucideAngularModule, Sun, Plus, Edit, Calendar, Zap, X, MoreVertical, Settings, Plug, Power, Trash2 } from 'lucide-angular';
import { SolarPlant } from '@domain/solar-plant/models/solar-plant.model';
import { SolarPlantFacade } from '@application/solar-plant/facades/solar-plant.facade';
import { SolarSystemModalComponent } from '../solar-system-modal/solar-system-modal.component';
import { SolarPanel } from '@domain/solar-panel/models/solar-panel.model';

/////////////////////////////////////////////////////////
// 🔥 DECLARAR EL TIPO AQUÍ (FUERA DE LA CLASE)
/////////////////////////////////////////////////////////

type PanelFormGroup = FormGroup<{
    id: FormControl<string | null>;
    brand: FormControl<string>;
    model: FormControl<string>;
    powerWatts: FormControl<number>;
    quantity: FormControl<number>;
}>;

@Component({
    selector: 'app-solar-systems',
    standalone: true,
    imports: [CommonModule, LucideAngularModule, ReactiveFormsModule, SolarSystemModalComponent],
    templateUrl: './solar-systems.component.html',
    styleUrl: './solar-systems.component.css'
})

export class SolarSystemsComponent implements OnInit {
    private fb = inject(FormBuilder);
    private facade = inject(SolarPlantFacade);
    private router = inject(Router);

    // ICONS
    readonly Sun = Sun;
    readonly Plus = Plus;
    readonly Edit = Edit;
    readonly Calendar = Calendar;
    readonly Zap = Zap;
    readonly X = X;
    readonly MoreVertical = MoreVertical;
    readonly Settings = Settings;
    readonly Plug = Plug;
    readonly Power = Power;
    readonly Trash2 = Trash2;

    // STATE
    isEditMode = false;
    selectedId: string | null = null;
    isModalOpen = false;
    openMenuId: string | null = null;
    systems$!: Observable<SolarPlant[]>;

    systemForm!: FormGroup<{
        name: FormControl<string>;
        location: FormControl<string>;
        installationDate: FormControl<string>;
        isActive: FormControl<boolean>;
        panels: FormArray<PanelFormGroup>;
    }>;

    ngOnInit() {
        this.buildForm();
        this.loadSystems();
    }

    // ===============================
    // MENU & ACTIONS
    // ===============================
    @HostListener('document:click', ['$event'])
    onDocumentClick(event: Event) {
        this.openMenuId = null;
    }

    toggleMenu(id: string, event: Event) {
        event.stopPropagation();
        this.openMenuId = this.openMenuId === id ? null : id;
    }

    goToEquipment(id: string, event?: Event) {
        if (event) event.stopPropagation();
        this.openMenuId = null;
        this.router.navigate(['/plants', id, 'devices']);
    }

    goToConfig(id: string, event: Event) {
        event.stopPropagation();
        this.openMenuId = null;
    }

    toggleStatus(sys: SolarPlant, event: Event) {
        event.stopPropagation();
        this.openMenuId = null;
        sys.isActive = !sys.isActive;
    }

    deleteSystem(id: string, event: Event) {
        event.stopPropagation();
        this.openMenuId = null;
    }

    // ===============================
    // FORM BUILDER
    // ===============================
    private buildForm() {
        this.systemForm = this.fb.group({
            name: this.fb.nonNullable.control('', Validators.required),
            location: this.fb.nonNullable.control('', Validators.required),
            installationDate: this.fb.nonNullable.control(
                new Date().toISOString().substring(0, 10),
                Validators.required
            ),
            isActive: this.fb.nonNullable.control(true),
            panels: this.fb.array<PanelFormGroup>([])
        });
    }

    // =========================
    // GETTER PANELS
    // =========================
    get panels(): FormArray {
         return this.systemForm.get('panels') as FormArray<PanelFormGroup>;
    }

    // =========================
    // PANEL GROUP FACTORY
    // =========================
    private createPanelGroup(panel?: SolarPanel): PanelFormGroup {
        return this.fb.group({

            id: this.fb.control(panel?.id ?? null),

            brand: this.fb.nonNullable.control(
                panel?.brand ?? '',
                Validators.required
            ),

            model: this.fb.nonNullable.control(
                panel?.model ?? '',
                Validators.required
            ),

            powerWatts: this.fb.nonNullable.control(
                panel?.powerWatts ?? 0,
                [Validators.required, Validators.min(1)]
            ),

            quantity: this.fb.nonNullable.control(
                panel?.quantity ?? 1,
                [Validators.required, Validators.min(1)]
            )
        });
    }

    addPanel() {
        this.panels.push(this.createPanelGroup());
    }

    removePanel(index: number) {
        this.panels.removeAt(index);
    }

    // ===============================
    // MODAL CONTROL
    // ===============================
    openModal() {
        this.isEditMode = false;
        this.selectedId = null;

        this.systemForm.reset({
            name: '',
            location: '',
            installationDate: new Date().toISOString().substring(0, 10),
            isActive: true
        });

        this.panels.clear();

        this.isModalOpen = true;
    }

    closeModal() {
        this.isModalOpen = false;
    }

    get totalPowerKw(): number {
        const panels = this.panels.value;

        const totalWatts = panels.reduce(
            (sum: number, p: any) => sum + (p.powerWatts * p.quantity),
            0
        );

        return totalWatts / 1000;
    }

    // ===============================
    // EDIT
    // ===============================
    editSystem(id: string) {
        this.isEditMode = true;
        this.selectedId = id;

        this.facade.getPlantById(id).subscribe(system => {
            this.systemForm.patchValue({
                name: system.name,
                location: system.location,
                installationDate: system.installationDate.toString().substring(0,10),
                isActive: system.isActive
            });

            this.panels.clear();

            system.panels?.forEach(panel => {
                this.panels.push(this.createPanelGroup(panel));
            });

            this.isModalOpen = true;
        });
    }

    // ===============================
    // SUBMIT (CREATE / UPDATE)
    // ===============================
    submit() {
        if (this.systemForm.invalid) return;

        const form = this.systemForm.getRawValue();

        const plant: SolarPlant = {
            id: this.selectedId ?? '',
            name: form.name,
            location: form.location,
            installationDate : new Date(form.installationDate).toISOString(),
            isActive: !!form.isActive,
            totalPowerKw: 0, // lo calculará la API
            panels: form.panels.map(p => ({
                id: p.id ?? null,
                solarPlantId: this.selectedId ?? '',
                brand: p.brand,
                model: p.model,
                powerWatts: p.powerWatts,
                quantity: p.quantity
            }))
        };

        const request$ =
            this.isEditMode && this.selectedId
            ? this.facade.updatePlant(this.selectedId, plant)
            : this.facade.createPlant(plant);

        request$.subscribe(() => this.afterSave());
    }

    // ===============================
    // LOAD LIST
    // ===============================
    loadSystems() {
        this.systems$ = this.facade.loadPlants();
    }

    // ===============================
    // AFTER SAVE
    // ===============================
    afterSave() {
        this.closeModal();
        this.loadSystems();
    }
}