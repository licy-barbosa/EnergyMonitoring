
import { Routes } from '@angular/router';

export const FRONTEND_ROUTES: Routes = [
  {
    path: '',
    loadChildren: () =>
      import('./search/search.routes.module')
        .then(r => r.SEARCH_ROUTES)
  },

  {
    path: 'property/detail/:id',
    loadChildren: () =>
      import('./property/property-detail/property-detail.module')
        .then(r => r.PROPERTY_DETAIL_ROUTES)
  }
];