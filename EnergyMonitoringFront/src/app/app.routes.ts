import { Routes } from '@angular/router';
import { IndexComponent } from './presentation/modules/pacientes/index/index.component';
import { AddComponent } from './presentation/modules/pacientes/add-pacientes/add-pacientes.component';
import { FiltroEstudiosComponent } from './presentation/modules/estudios/filter-estudios/filter-estudios.component';
import { EditPacientesComponent } from './presentation/modules/pacientes/edit-pacientes/edit-pacientes.component';
import { RegisterComponent } from './presentation/modules/security/register/register.component';
import { UserIndexComponent } from './presentation/modules/security/user-index/user-index.component';
import { roleGuard } from '@core/auth';
import { authGuard } from '@core/auth/guards/auth.guard';
import { guestGuard } from '@core/auth/guards/guest.guard';
import { SOLAR_PLANT_PROVIDERS } from '@infrastructure/solar-plant/solar-plant.provider';
import { SolarSystemsComponent } from '@presentation/solar-plant/solor-system-grid/solar-systems.component';

export const routes: Routes = [
    {
        path: 'auth',
        canActivate: [guestGuard],
        loadComponent: () =>
            import('@presentation/template/layouts/public-layout/public-layout.component')
                .then(m => m.PublicLayoutComponent),
        children: [
            {
                path: 'login',
                loadComponent: () =>
                    import('@presentation/auth/pages/login/login.component')
                        .then(m => m.LoginComponent)
            }
        ]
    },

    {   
        path: '',
         canActivate: [authGuard],
        loadComponent: () =>
            import('@presentation/template/layouts/private-layout/private-layout.component')
                .then(c => c.PrivateLayoutComponent),
                children: [
            {
                path: '',
                loadComponent: () => import('@presentation/dashboard/pages/dashboard/dashboard.component').then(c => c.DashboardComponent)
            },

            {
                path: 'solar-systems',
                providers: [...SOLAR_PLANT_PROVIDERS],
                loadComponent: () => SolarSystemsComponent
            },

            {
                path: 'devices',
                loadComponent: () => import('@presentation/devices/pages/devices/devices.component').then(c => c.DevicesComponent)
            },
            {
                path: 'energy-production',
                loadComponent: () => import('@presentation/energy-production/pages/energy-production/energy-production.component').then(c => c.EnergyProductionComponent)
            },
            {
                path: 'readings',
                loadComponent: () => import('@presentation/readings/pages/readings/readings.component').then(c => c.ReadingsComponent)
            },
            {
                path: 'cost',
                loadComponent: () => import('@presentation/cost/pages/cost/cost.component').then(c => c.CostComponent)
            },
            {
                path: 'register',
                loadComponent: () => import('@presentation/auth/pages/register/register.component').then(c => c.RegisterComponent)
            },
            {
                path: 'old-search',
                loadChildren: () =>
                    import('@presentation/modules/frontend/search/search.routes.module')
                        .then(r => r.SEARCH_ROUTES)
            },
            {
                path: 'auth-legacy',
                loadChildren: () =>
                    import('@presentation/auth/auth.routes')
                        .then(m => m.AUTH_ROUTES)
            },
  
        ]
    },









    // {
    //     path: '',
    //     loadChildren: () =>
    //     import('./presentation/modules/frontend/frontend.routes.module')
    //         .then(r => r.FRONTEND_ROUTES)
    // },

    {
        path: 'property/detail/:id',
        loadChildren: () =>
            import('./presentation/modules/frontend/frontend.routes.module')
                .then(r => r.FRONTEND_ROUTES)
    },

    {
        path: '**',
        loadComponent: () =>
            import('./presentation/template/not-found/not-found.component')
                .then(c => c.NotFoundComponent)
    },




];