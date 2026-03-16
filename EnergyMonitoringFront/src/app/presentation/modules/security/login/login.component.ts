import { Router } from '@angular/router';
import { Component, inject } from '@angular/core';
import { CredentialsUserDto, SecurityService } from '@core/auth';
import { getErrorsIdentity } from '../../../share/GetErrors';
import { FormLoginComponent } from "../form-login/form-login.component";

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [FormLoginComponent],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
    securityService = inject(SecurityService);
    router = inject(Router);
    errores : string[] = [];

    login(credentials: CredentialsUserDto): void {
        console.log("Login credentials: ", credentials);
        this.securityService.login(credentials)
            .subscribe({
                next: response => {
                    this.router.navigate(['/']);
                },
                error: error => {
                    const errores = getErrorsIdentity(error);
                    this.errores = errores;
                }
            });
    }
}