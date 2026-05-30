import { CommonModule } from '@angular/common';
import { ChangeDetectionStrategy, Component, inject, OnInit, signal } from '@angular/core';
import { Router } from '@angular/router';
import { NavbarComponent } from '../../components/navbar/navbar';
import { Empleado } from '../../models/empleado';
import { AuthService } from '../../services/auth';
import { EmpleadoService } from '../../services/empleado.service';

@Component({
  selector: 'app-empleados',
  imports: [CommonModule, NavbarComponent],
  templateUrl: './empleados.html',
  styleUrl: './empleados.css',
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class EmpleadosComponent implements OnInit {
  private empleadoService = inject(EmpleadoService);
  private authService = inject(AuthService);
  private router = inject(Router);

  readonly empleados = signal<Empleado[]>([]);
  readonly cargando = signal(true);
  readonly error = signal('');

  ngOnInit(): void {
    this.empleadoService.listar().subscribe({
      next: (data) => {
        this.empleados.set(data);
        this.cargando.set(false);
      },
      error: () => {
        this.error.set('No se pudieron cargar los empleados.');
        this.cargando.set(false);
      }
    });
  }

  logout() {
    this.authService.logout();
  }

  goToLogin() {
    this.router.navigate(['/login']);
  }

  nombreCompleto(empleado: Empleado): string {
    return [empleado.nombres, empleado.apellidoPaterno, empleado.apellidoMaterno]
      .filter(Boolean)
      .join(' ');
  }
}
