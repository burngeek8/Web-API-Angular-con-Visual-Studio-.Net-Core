import { CommonModule } from '@angular/common';
import { ChangeDetectionStrategy, Component, inject, OnInit, signal } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { NavbarComponent } from '../../components/navbar/navbar';
import { Cargo } from '../../models/cargo';
import { AuthService } from '../../services/auth';
import { CargoService } from '../../services/cargo.service';

@Component({
  selector: 'app-cargos',
  imports: [CommonModule, FormsModule, NavbarComponent],
  templateUrl: './cargos.html',
  styleUrl: './cargos.css',
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class CargosComponent implements OnInit {
  private cargoService = inject(CargoService);
  private authService = inject(AuthService);
  private router = inject(Router);
  private route = inject(ActivatedRoute);
  private searchTimeout: ReturnType<typeof setTimeout> | null = null;

  readonly cargos = signal<Cargo[]>([]);
  readonly cargando = signal(true);
  readonly error = signal('');
  readonly q = signal('');

  ngOnInit(): void {
    this.route.queryParamMap.subscribe((params) => {
      const q = params.get('q') ?? '';
      this.q.set(q);
      this.cargarCargos();
    });
  }

  buscar() {
    this.router.navigate([], {
      relativeTo: this.route,
      queryParams: this.q().trim() ? { q: this.q().trim() } : {},
      queryParamsHandling: ''
    });
  }

  onSearchChange(value: string) {
    this.q.set(value);

    if (this.searchTimeout) {
      clearTimeout(this.searchTimeout);
    }

    this.searchTimeout = setTimeout(() => {
      this.buscar();
    }, 300);
  }

  limpiarFiltro() {
    this.router.navigate([], {
      relativeTo: this.route,
      queryParams: {},
      queryParamsHandling: ''
    });
  }

  private cargarCargos() {
    this.cargando.set(true);
    this.error.set('');

    this.cargoService.listar(this.q()).subscribe({
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
