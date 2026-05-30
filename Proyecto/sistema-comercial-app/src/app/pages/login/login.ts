import { CommonModule } from '@angular/common';
import { Component, inject, signal } from '@angular/core';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { NavbarComponent } from '../../components/navbar/navbar';
import { AuthService } from '../../services/auth';

@Component({
  selector: 'app-login',
  imports: [CommonModule, ReactiveFormsModule, NavbarComponent],
  templateUrl: './login.html',
  styleUrl: './login.css'
})
export class LoginComponent {
  private fb = inject(FormBuilder);
  private authService = inject(AuthService);
  private router = inject(Router);

  readonly cargando = signal(false);
  readonly error = signal('');

  readonly form = this.fb.nonNullable.group({
    CorreoEmpresarial: ['', [Validators.required, Validators.email]],
    Clave: ['', [Validators.required]]
  });

  onSubmit() {
    if (this.form.invalid) {
      this.form.markAllAsTouched();
      return;
    }

    this.cargando.set(true);
    this.error.set('');

    this.authService.login(this.form.getRawValue()).subscribe({
      next: () => {
        this.cargando.set(false);
        this.router.navigate(['/cargos']);
      },
      error: () => {
        this.error.set('Credenciales invalidas.');
        this.cargando.set(false);
      }
    });
  }
}
