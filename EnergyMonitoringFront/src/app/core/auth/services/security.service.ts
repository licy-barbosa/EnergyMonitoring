import { Observable, tap } from 'rxjs';
import { UserDto } from '../models/user.dto';
import { inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ENVIRONMENT } from '../../config/environment.token';
import { CredentialsUserDto } from '../models/credentials-user.dto';
import { AuthResponseDto } from '../models/auth-response.dto';
import { clearAuthSession, setAuthSession } from '../state/auth.state';
import { UserProfileDto } from '../models/user-profile.dto';

@Injectable({ providedIn: 'root' })
export class SecurityService {

    private http = inject(HttpClient);
    private env = inject(ENVIRONMENT);
    private urlBase = this.env.apiUrl + '/Auth';

    private readonly tokenKey = 'authToken';
    private readonly keyExpiration = 'token-expiration';

    // =============================
    // LOGIN / REGISTER
    // =============================

    public register(credentials: CredentialsUserDto): Observable<AuthResponseDto> {
        return this.http.post<AuthResponseDto>(`${this.urlBase}/register`, credentials)
            .pipe(tap(response => this.saveSession(response)));
    }

    public login(credentials: CredentialsUserDto): Observable<AuthResponseDto> {
        return this.http.post<AuthResponseDto>(`${this.urlBase}/login`, credentials)
            .pipe(tap(response => this.saveSession(response)));
    }

    public logout(): void {
        localStorage.removeItem(this.tokenKey);
        localStorage.removeItem(this.keyExpiration);
        clearAuthSession();
    }

    getProfile(): Observable<UserProfileDto> {
        return this.http.get<UserProfileDto>(`${this.urlBase}/me`);
    }

    // =============================
    // RESTORE SESSION (APP_INITIALIZER)
    // =============================

    public async restoreSession(): Promise<void> {
        const token = this.getToken();
        const expiration = localStorage.getItem(this.keyExpiration);

        if (!token || !expiration) {
            this.logout();
            return;
        }

        const isExpired = new Date(expiration) <= new Date();

        if (isExpired) {
            this.logout();
            return;
        }

        // reconstruimos usuario desde claims
        const user: UserDto = {
            userId: this.getClaimValue('nameidentifier'),
            email: this.getClaimValue('email'),
            name: this.getClaimValue('name'),
            roles: this.getClaimValue('isadmin') === 'true' ? ['admin'] : ['user']
        };

        setAuthSession(user, token);
    }

    // =============================
    // TOKEN
    // =============================

    getToken(): string | null {
        return localStorage.getItem(this.tokenKey);
    }

    private saveSession(response: AuthResponseDto): void {
        localStorage.setItem(this.tokenKey, response.token);
        localStorage.setItem(this.keyExpiration, response.expiration);

        const user: UserDto = {
            userId: this.getClaimValue('nameidentifier'),
            email: this.getClaimValue('email'),
            name: this.getClaimValue('name'),
            roles: this.getClaimValue('isadmin') === 'true' ? ['admin'] : ['user']
        };

        setAuthSession(user, response.token);
    }

    // =============================
    // CLAIMS
    // =============================

    getClaimValue(claimSearch: string): string {
        const token = localStorage.getItem(this.tokenKey);
        if (!token) return '';

        const base64Url = token.split('.')[1];
        const base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');

        try {
            const payload = JSON.parse(atob(base64));

            const claimKey = Object.keys(payload).find(k =>
                k.toLowerCase().includes(claimSearch.toLowerCase())
            );

            if (!claimKey) return '';

            const value = payload[claimKey];

            return Array.isArray(value) ? value[0].toString() : value.toString();
        }
        catch {
            return '';
        }
    }

    // =============================
    // HELPERS
    // =============================

    getUserRole(): string {
        return this.getClaimValue('isadmin') === 'true' ? 'admin' : 'user';
    }

    public getUser() {
        return {
            name: this.getClaimValue('name'),
            email: this.getClaimValue('email')
        };
    }
}