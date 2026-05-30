import { inject, OnInit, Component, ChangeDetectionStrategy, signal } from '@angular/core';
import { UsuarioService } from "../../services/usuario.services";
import { AuthService } from "../../services/auth.services";
import { Router } from "@angular/router";
import { CommonModule } from '@angular/common';
import { Usuario } from '../../models/usuario';

@Component({
    selector : 'app-usuarios',
    templateUrl : './usuarios.html',
    imports : [CommonModule],
    changeDetection : ChangeDetectionStrategy.OnPush
})


export class UsuariosComponent implements OnInit {

    private usuariosServices = inject(UsuarioService);
    private authServices = inject(AuthService);
    private router = inject(Router);

    usuarios = signal<Usuario[]>([]);
    cargando  = signal(false);
    error = signal('');

    ngOnInit(): void {
        this.usuariosServices.obtenerUsuarios().subscribe({
            next: (usuarios) => {
                this.usuarios.set(usuarios);
                this.cargando.set(false);
            },
            error: () => {
                this.error.set('Error al cargar los usuarios');
                this.cargando.set(false);
            }
        });
    }

    logout() {
        this.authServices.logout();
    }

    goToLogin() {
        this.router.navigate(['/login']);
    }

}
