import { Component, inject, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router, RouterModule, NavigationEnd } from '@angular/router';
import { SecurityService } from '@core/auth/services/security.service';
import { filter } from 'rxjs/operators';
import { LucideAngularModule, Sun, LayoutDashboard, Cpu, Zap, BarChart3, DollarSign, LogOut, Menu, X, ChevronLeft } from 'lucide-angular';

@Component({
  selector: 'app-sidebar',
  standalone: true,
  imports: [CommonModule, RouterModule, LucideAngularModule],
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.css']
})
export class SidebarComponent implements OnInit {
  router = inject(Router);
  private security = inject(SecurityService);

  readonly Sun = Sun;
  readonly LayoutDashboard = LayoutDashboard;
  readonly Cpu = Cpu;
  readonly Zap = Zap;
  readonly BarChart3 = BarChart3;
  readonly DollarSign = DollarSign;
  readonly LogOut = LogOut;
  readonly Menu = Menu;
  readonly X = X;
  readonly ChevronLeft = ChevronLeft;

  navItems = [
    { to: '/', label: 'Dashboard', icon: this.LayoutDashboard },
    { to: '/solar-systems', label: 'Paneles Solares', icon: this.Sun },
    { to: '/devices', label: 'Equipos', icon: this.Cpu },
    { to: '/energy-production', label: 'Producción', icon: this.Zap },
    { to: '/readings', label: 'Lecturas', icon: this.BarChart3 },
    { to: '/cost', label: 'Costo CFE', icon: this.DollarSign },
  ];

  collapsed = false;
  mobileOpen = false;
  currentPath = '';

  get user() {
    return this.security.getUser();
  }

  ngOnInit() {
    this.currentPath = this.router.url;
    this.router.events.pipe(
      filter(event => event instanceof NavigationEnd)
    ).subscribe((event: any) => {
      this.currentPath = event.urlAfterRedirects;
    });
  }

  toggleCollapsed() {
    this.collapsed = !this.collapsed;
    this.mobileOpen = false;
  }

  closeMobile() {
    this.mobileOpen = false;
  }

  openMobile() {
    this.mobileOpen = true;
  }

  logout() {
    this.security.logout();
    this.router.navigate(['/auth/login']);
  }
}
