import { Component, inject } from '@angular/core';
import { Router, RouterLink, RouterLinkActive } from '@angular/router';
import { AuthService } from '../../services/auth';

@Component({
  selector: 'app-navbar',
  imports: [RouterLink, RouterLinkActive],
  templateUrl: './navbar.html',
  styleUrl: './navbar.css'
})
export class NavbarComponent {
  private authService = inject(AuthService);
  private router = inject(Router);

  isAuthenticated(): boolean {
    return this.authService.isAuthenticated();
  }

  goToLogin() {
    this.router.navigate(['/login']);
  }

  logout() {
    this.authService.logout();
  }
}
