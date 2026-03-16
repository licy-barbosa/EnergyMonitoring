import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LucideAngularModule, Sun, Zap, DollarSign, TrendingUp } from 'lucide-angular';

@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [CommonModule, LucideAngularModule],
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.css'
})
export class DashboardComponent {
  readonly Sun = Sun;
  readonly Zap = Zap;
  readonly DollarSign = DollarSign;
  readonly TrendingUp = TrendingUp;

  totalProduction = 452.1;
  totalConsumption = 384.5;
  savings = 2450;
  activePanels = 12;
}
