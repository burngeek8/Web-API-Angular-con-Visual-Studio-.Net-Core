import { inject } from "@angular/core";
import { CanActivateFn, Router } from "@angular/router";
import { AuthService } from "../services/auth.services";


export const authGuard : CanActivateFn = () => {

    const auth = inject(AuthService);
    const route = inject(Router);

    return auth.isAuthenticated() ? true : route.navigate(['/login']);

}