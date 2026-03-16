import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { LucideAngularModule, Cpu, Plus, Edit2, MapPin, Zap, X } from 'lucide-angular';

export interface Device {
  id: string;
  name: string;
  location: string;
  nominalPowerW: number;
  expectedMonthlyKwh: number;
  status: 'active' | 'inactive';
}

@Component({
  selector: 'app-devices',
  standalone: true,
  imports: [CommonModule, LucideAngularModule, ReactiveFormsModule],
  templateUrl: './devices.component.html',
  styleUrl: './devices.component.css'
})
export class DevicesComponent implements OnInit {
  readonly Cpu = Cpu;
  readonly Plus = Plus;
  readonly Edit2 = Edit2;
  readonly MapPin = MapPin;
  readonly Zap = Zap;
  readonly X = X;

  devices: Device[] = [];
  isModalOpen = false;
  deviceForm: FormGroup;

  constructor(private fb: FormBuilder) {
    this.deviceForm = this.fb.group({
      name: ['', Validators.required],
      location: ['', Validators.required],
      nominalPowerW: [null, [Validators.required, Validators.min(1)]],
      expectedMonthlyKwh: [null, [Validators.required, Validators.min(1)]],
      status: ['active', Validators.required]
    });
  }

  ngOnInit() {
    this.devices = [
      { id: '1', name: 'Aire Acondicionado', location: 'Sala', nominalPowerW: 1500, expectedMonthlyKwh: 180, status: 'active' },
      { id: '2', name: 'Refrigerador', location: 'Cocina', nominalPowerW: 350, expectedMonthlyKwh: 45, status: 'active' },
      { id: '3', name: 'Lavadora', location: 'Cuarto de lavado', nominalPowerW: 500, expectedMonthlyKwh: 30, status: 'active' },
      { id: '4', name: 'Microondas', location: 'Cocina', nominalPowerW: 1200, expectedMonthlyKwh: 15, status: 'inactive' },
      { id: '5', name: 'Iluminación LED', location: 'General', nominalPowerW: 200, expectedMonthlyKwh: 60, status: 'active' },
    ];
  }

  openModal() {
    this.isModalOpen = true;
    this.deviceForm.reset({ status: 'active' });
  }

  closeModal() {
    this.isModalOpen = false;
  }

  onSubmit() {
    if (this.deviceForm.valid) {
      const formValue = this.deviceForm.value;

      const newDevice: Device = {
        id: Math.random().toString(36).substr(2, 9),
        name: formValue.name,
        location: formValue.location,
        nominalPowerW: formValue.nominalPowerW,
        expectedMonthlyKwh: formValue.expectedMonthlyKwh,
        status: formValue.status,
      };

      this.devices.push(newDevice);
      this.closeModal();
    }
  }
}
