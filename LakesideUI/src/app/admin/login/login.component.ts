import { Component } from '@angular/core';
import { AuthenticationService } from '../services/authentication.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  template: `
    <h2>Login</h2>
    <form (ngSubmit)="login()">
      <div>
        <label for="username">Username:</label>
        <input type="text" id="username" [(ngModel)]="username" name="username" required>
      </div>
      <div>
        <label for="password">Password:</label>
        <input type="password" id="password" [(ngModel)]="password" name="password" required>
      </div>
      <button type="submit">Login</button>
    </form>
    <p *ngIf="loginError" class="error-message">Invalid username or password</p>
  `,
  styles: [`
    .error-message {
      color: red;
    }
  `]
})
export class LoginComponent {
  username: string = '';
  password: string = '';
  loginError: boolean = false;

  constructor(private authService: AuthenticationService,private router: Router) {}

  login(): void {
    if (this.authService.login(this.username, this.password)) {
      // Xác thực thành công, chuyển hướng đến trang sau khi đăng nhập
      this.router.navigate(['/dashboard']);
    } else {
      // Xác thực không thành công, hiển thị thông báo lỗi
      this.loginError = true;
    }
  }
}