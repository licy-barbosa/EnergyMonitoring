import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { isLoggedIn } from '../state/auth.state';

export const guestGuard: CanActivateFn = () => {
  const router = inject(Router);

  if (!isLoggedIn()) {
    return true;
  }

  return router.createUrlTree(['/']);
};