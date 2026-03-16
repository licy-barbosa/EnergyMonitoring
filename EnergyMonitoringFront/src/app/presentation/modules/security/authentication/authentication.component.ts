import { Component, inject, Input } from '@angular/core';
import { SecurityService } from '@core/auth';
import { isLoggedIn } from '@core/auth/state/auth.state';

@Component({
  selector: 'app-authentication',
  standalone: true,
  imports: [],
  templateUrl: './authentication.component.html',
  styleUrl: './authentication.component.css'
})
export class AuthenticationComponent {
    SecurityService = inject(SecurityService);
    @Input()
    rol?: string;

    isAuthorized(): boolean {
        if (this.rol) {
            return this.SecurityService.getUserRole() === this.rol;
        }

        return isLoggedIn();
    }
}
