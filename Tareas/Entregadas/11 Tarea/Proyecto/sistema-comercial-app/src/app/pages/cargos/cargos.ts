import { CommonModule } from '@angular/common';
import { ChangeDetectionStrategy, Component, inject, OnInit, signal } from '@angular/core';
import { Router } from '@angular/router';
import { NavbarComponent } from '../../components/navbar/navbar';
import { Cargo } from '../../models/cargo';
import { AuthService } from '../../services/auth';
import { CargoService } from '../../services/cargo.service';

@Component({
  selector: 'app-cargos',
  imports: [CommonModule, NavbarComponent],
  templateUrl: './cargos.html',
  styleUrl: './cargos.css',
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class CargosComponent implements OnInit {
  private cargoService = inject(CargoService);
  private authService = inject(AuthService);
  private router = inject(Router);

  readonly cargos = signal<Cargo[]>([]);
  readonly cargando = signal(true);
  readonly error = signal('');

  ngOnInit(): void {
    this.cargoService.listar().subscribe({
      next: (data) => {
        this.cargos.set(data);
        this.cargando.set(false);
      },
      error: () => {
        this.error.set('No se pudieron cargar los cargos.');
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
}
