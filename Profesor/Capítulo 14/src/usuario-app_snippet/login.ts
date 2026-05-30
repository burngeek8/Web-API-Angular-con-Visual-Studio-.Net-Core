import { FormBuilder, ReactiveFormsModule, Validators } from "@angular/forms";
import { AuthService } from "../../services/auth.services";
import { Router } from "@angular/router";
import { Component, inject } from "@angular/core";
import { CommonModule } from "@angular/common";


@Component({
    selector : 'app-login',
    standalone : true,
    templateUrl : './login.html',
    imports : [CommonModule, ReactiveFormsModule]
})
export class LoginComponent {

    private fb = inject(FormBuilder);
    private auth = inject(AuthService);
    private router = inject(Router);

    form = this.fb.group({
        NombreUsuario : ['', Validators.required],
        Password : ['', Validators.required]
    });

    error = '';
    cargando = false;

    onSubmit() {
        if (this.form.invalid) {
            return;
        }
        this.cargando = true;
        this.error = '';
        this.auth.login(this.form.value as { NombreUsuario: string; Password: string }).subscribe({ 
            next: () => {
                this.router.navigate(['/usuarios']);
            },
            error: () => {
                this.error = 'Error de autenticación';
                this.cargando = false;
            }

        });
    }

}