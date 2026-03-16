import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LucideAngularModule, Zap, TrendingUp, Activity, Gauge } from 'lucide-angular';

export interface EnergyProduction {
  id: string;
  solarSystemId: string;
  date: string;
  kwhGenerated: number;
  avgVoltage: number;
  avgCurrent: number;
  efficiency: number;
}

@Component({
  selector: 'app-energy-production',
  standalone: true,
  imports: [CommonModule, LucideAngularModule],
  templateUrl: './energy-production.component.html',
  styleUrl: './energy-production.component.css'
})
export class EnergyProductionComponent implements OnInit {
  readonly Zap = Zap;
  readonly TrendingUp = TrendingUp;
  readonly Activity = Activity;
  readonly Gauge = Gauge;

  data: EnergyProduction[] = [];
  avgKwh: string = '0';
  avgEfficiency: string = '0';

  ngOnInit() {
    // Generar mock data para los últimos 14 días
    this.data = Array.from({ length: 14 }, (_, i) => ({
      id: String(i + 1),
      solarSystemId: '1',
      date: new Date(2025, 1, i + 5).toISOString().split('T')[0],
      kwhGenerated: 18 + Math.random() * 10,
      avgVoltage: 220 + Math.random() * 10,
      avgCurrent: 8 + Math.random() * 3,
      efficiency: 85 + Math.random() * 10,
    }));

    // Calcular promedios
    const totalKwh = this.data.reduce((s, d) => s + d.kwhGenerated, 0);
    this.avgKwh = (totalKwh / this.data.length).toFixed(1);

    const totalEff = this.data.reduce((s, d) => s + d.efficiency, 0);
    this.avgEfficiency = (totalEff / this.data.length).toFixed(1);
  }
}
