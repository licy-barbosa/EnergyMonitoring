import { inject } from '@angular/core';
import { isLoggedIn } from '../state/auth.state';
import { CanActivateFn, Router } from '@angular/router';

export const authGuard: CanActivateFn = () => {
  const router = inject(Router);

  return isLoggedIn()
    ? true
    : router.createUrlTree(['/auth/login']);
};