import { Routes } from '@angular/router';
import { authGuard } from './guards/auth.guard';

export const routes: Routes = [
  {
    path: 'laboratorio',
    loadComponent: () =>
      import('./pages/laboratorio/laboratorio').then((m) => m.LaboratorioComponent)
  },
  {
    path: 'login',
    loadComponent: () =>
      import('./pages/login/login').then((m) => m.LoginComponent)
  },
  {
    path: 'cargos',
    loadComponent: () =>
      import('./pages/cargos/cargos').then((m) => m.CargosComponent),
    canActivate: [authGuard]
  },
  {
    path: '',
    redirectTo: 'laboratorio',
    pathMatch: 'full'
  },
  {
    path: '**',
    redirectTo: 'laboratorio'
  }
];
