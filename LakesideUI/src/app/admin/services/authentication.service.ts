import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  private loggedIn = false;

  constructor() {
    this.loggedIn = localStorage.getItem('loggedIn') === 'true';
  }

  login(username: string, password: string): boolean {
    // Kiểm tra thông tin đăng nhập ở đây (giả sử thông tin đúng là 'admin' và 'password')
    if (username === 'adminpat' && password === 'thanhphat') {
      this.loggedIn = true;
      localStorage.setItem('loggedIn', 'true');
      return true;
    }
    return false;
  }

  logout(): void {
    this.loggedIn = false;
  }

  isLoggedIn(): boolean {
    return this.loggedIn;
  }
}
