import { inject } from '@angular/core';
import { SecurityService, UserDto } from '@core/auth';
import { clearAuthSession, setAuthSession } from './auth.state';

export function restoreSession(): Promise<void> {
  const securityService = inject(SecurityService);
  const token = securityService.getToken();

  if (!token) {
    clearAuthSession();
    return Promise.resolve();
  }

  const expiration = localStorage.getItem('token-expiration');
  const expirationDate = expiration ? new Date(expiration) : null;

  if (!expirationDate || expirationDate <= new Date()) {
    securityService.logout();
    return Promise.resolve();
  }

  const user: UserDto = {
    userId: securityService.getClaimValue('uid') || securityService.getClaimValue('sub'),
    email: securityService.getClaimValue('email'),
    roles:
      securityService.getClaimValue('isadmin') === 'true'
        ? ['admin']
        : ['user']
  };

  setAuthSession(user, token);

  return Promise.resolve();
}