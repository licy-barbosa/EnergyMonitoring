import { signal, computed } from '@angular/core';
import { UserDto } from '../models/user.dto';

export interface AuthState {
  isAuthenticated: boolean;
  user: UserDto | null;
  token: string | null;
}

/* ===== STATE ===== */
export const authState = signal<AuthState>({
  isAuthenticated: false,
  user: null,
  token: null
});

/* ===== SELECTORS ===== */
export const isLoggedIn = computed(() => authState().isAuthenticated);
export const currentUser = computed(() => authState().user);
export const authToken = computed(() => authState().token);

/* ===== MUTATORS ===== */
export function setAuthSession(user: UserDto, token: string): void {
  authState.set({
    isAuthenticated: true,
    user,
    token,
  });
}

export function clearAuthSession(): void {
  authState.set({
    isAuthenticated: false,
    user: null,
    token: null
  });
}