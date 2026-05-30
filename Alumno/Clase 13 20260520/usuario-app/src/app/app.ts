import { CommonModule } from '@angular/common';
import { Component, inject, OnInit, signal } from '@angular/core';
import { UsuarioService } from './services/usuario.services';
import { Usuario } from './models/usuario';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App implements OnInit {

   private service = inject(UsuarioService);

   usuarios = signal<Usuario[]>([]);
   cargando = signal(true);
   error = signal('');

  ngOnInit(): void {
      this.service.obtenerUsuarios().subscribe({
        next: (data) => {
          this.usuarios.set(data);
          this.cargando.set(false);
        },
        error: (err) => {
          this.error.set('Error al cargar los usuarios');
          this.cargando.set(false);
        }
      });
    }
}
