import { Component } from '@angular/core';
import { AuthenticationService } from '../services/authentication.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
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