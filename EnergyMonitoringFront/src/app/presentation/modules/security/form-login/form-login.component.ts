import { MatIconModule } from '@angular/material/icon';
import { MatCardModule } from '@angular/material/card';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field'
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { Component, EventEmitter, inject, Input, Output } from '@angular/core';
import { MatProgressSpinnerModule } from "@angular/material/progress-spinner";
import { ShowErroresComponent } from "../../../template/show-errores/show-errores.component";
import { CredentialsUserDto } from '@core/auth';

@Component({
    selector: 'app-form-login',
    standalone: true,
    imports: [ShowErroresComponent, ReactiveFormsModule, MatFormFieldModule, MatButtonModule, MatInputModule, MatIconModule, MatCardModule, MatProgressSpinnerModule],
    templateUrl: './form-login.component.html',
    styleUrl: './form-login.component.css'
})

export class FormLoginComponent {
    private formBuilder = inject(FormBuilder);

    loading = false;
    hide = true; 
    @Input({required: true})
    title!: string;

    @Input()
    errores : string[] = [];

    @Output()
    submitForm = new EventEmitter<CredentialsUserDto>();

    form = this.formBuilder.group({
        email: ['', {validators : [
            Validators.required,
            Validators.email
        ]}],
        password: ['', {validators : [
            Validators.required,
            Validators.minLength(6)
        ]}]
    })

    getMessageErrorEmail(): string {
        let field = this.form.controls.email;

        if (field.hasError('required')) {
            console.log(field.hasError('required'));
            return 'Email es requerido';
        } else if (field.hasError('email')) {
            console.log(field.hasError('email'));
            return 'Email no es válido';
        }

        return '';
    }

    getMessageErrorPassword(): string {
        let field = this.form.controls.password;

        if (field.hasError('required')) {
            return 'Contraseña es requerida';
        } else if (field.hasError('minlength')) {
            return 'Contraseña debe tener al menos 6 caracteres';
        }

        return '';
    }

    saveChanges(): void {
        if (this.form.invalid) {
            return; 
        }
        console.log("Form submitted with: ", this.form.value);
        this.submitForm.emit(this.form.value as CredentialsUserDto);
    }
}