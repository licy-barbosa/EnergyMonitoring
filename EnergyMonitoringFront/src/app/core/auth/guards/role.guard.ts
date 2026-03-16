import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { currentUser, isLoggedIn } from '../state/auth.state';

export const roleGuard = (allowedRoles: string[]): CanActivateFn => {
  return () => {
    const router = inject(Router);

    if (!isLoggedIn()) {
      router.navigate(['/auth/login']);
      return false;
    }

    const user = currentUser();

    if (!user || !user.roles?.length) {
      router.navigate(['/unauthorized']);
      return false;
    }

    const hasRole = user.roles.some(role =>
      allowedRoles.includes(role)
    );

    if (!hasRole) {
      router.navigate(['/unauthorized']);
      return false;
    }

    return true;
  };
};