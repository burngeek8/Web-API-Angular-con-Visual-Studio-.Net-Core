import { Routes } from '@angular/router';
import { authGuard } from './guards/auth.guard';

export const routes: Routes = [

    {
        path : 'login',
        loadComponent : () => import('./pages/login/login').then(m => m.LoginComponent)
    },                                
    {
        path : 'usuarios',
        loadComponent : () => import('./pages/usuarios/usuarios').then(m => m.UsuariosComponent),
        canActivate: [authGuard]
    },
    {
        path : '',
        redirectTo : 'login',
        pathMatch: 'full'
    },
    {
        path : '**',
        redirectTo : 'login'
    },

];
