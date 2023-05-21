import { Component } from '@angular/core';
import { AuthenticationService } from '../services/authentication.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent {

  constructor(
    private authService: AuthenticationService,
    private router: Router
  ) {}

  logout(): void {
    this.authService.logout();
    localStorage.removeItem('loggedIn');
    this.router.navigate(['/']);
  }
}
