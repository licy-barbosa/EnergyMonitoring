import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LucideAngularModule, DollarSign, TrendingDown, ArrowUpRight, ArrowDownRight, Zap } from 'lucide-angular';

export interface CostEstimate {
  totalConsumptionKwh: number;
  energySentToGrid: number;
  energyPurchased: number;
  estimatedCostMXN: number;
  savingsPercentage: number;
  period: string;
}

@Component({
  selector: 'app-cost',
  standalone: true,
  imports: [CommonModule, LucideAngularModule],
  templateUrl: './cost.component.html',
  styleUrl: './cost.component.css'
})
export class CostComponent implements OnInit {
  readonly DollarSign = DollarSign;
  readonly TrendingDown = TrendingDown;
  readonly ArrowUpRight = ArrowUpRight;
  readonly ArrowDownRight = ArrowDownRight;
  readonly Zap = Zap;

  est: CostEstimate = {
    totalConsumptionKwh: 0,
    energySentToGrid: 0,
    energyPurchased: 0,
    estimatedCostMXN: 0,
    savingsPercentage: 0,
    period: ''
  };

  pieData: { name: string, value: number, color: string }[] = [];

  ngOnInit() {
    this.est = {
      totalConsumptionKwh: 580,
      energySentToGrid: 210,
      energyPurchased: 370,
      estimatedCostMXN: 1245.80,
      savingsPercentage: 36.2,
      period: 'Enero - Febrero 2025',
    };

    this.pieData = [
      { name: 'Generación propia', value: this.est.energySentToGrid + (this.est.totalConsumptionKwh - this.est.energyPurchased), color: 'hsl(166, 72%, 45%)' },
      { name: 'Comprado CFE', value: this.est.energyPurchased, color: 'hsl(42, 92%, 56%)' },
    ];
  }
}
