import { Routes } from '@angular/router';

export const PROPERTY_DETAIL_ROUTES: Routes = [
  {
    path: '',
    loadComponent: () =>
      import('./property-detail.component')
        .then(c => c.PropertyDetailComponent)
  }
];