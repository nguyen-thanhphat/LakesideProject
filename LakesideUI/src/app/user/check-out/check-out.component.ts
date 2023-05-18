import { HttpClient } from '@angular/common/http';
import { ConstantPool } from '@angular/compiler';
import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { environment } from 'src/environment/environment';

@Component({
  selector: 'app-check-out',
  templateUrl: './check-out.component.html',
  styleUrls: ['./check-out.component.css'],
})
export class CheckOutComponent {
  responseData:any;
  formData: any;

  days: number = 0;
  totalPrice: number = 0;
  giaPhong: number = 0;
  methodArray: any[] = [];

  loaiPhong: string = '';
  tenPhong: string = '';

  selectedMethod: number = 0;
  constructor(private http: HttpClient, private route: ActivatedRoute, private router: Router) {
    this.getMethods();
  }

  ngOnInit() {
    this.formData = JSON.parse(this.route.snapshot.queryParamMap.get('formData') || '{}');
    this.days = parseInt(this.route.snapshot.queryParamMap.get('days') || '0', 10);
    this.totalPrice = parseInt(this.route.snapshot.queryParamMap.get('totalPrice') || '0', 10);
    this.giaPhong = parseInt(this.route.snapshot.queryParamMap.get('giaPhong') || '0', 10);
    this.loaiPhong = this.route.snapshot.queryParamMap.get('loaiPhong') || '';
    this.tenPhong = this.route.snapshot.queryParamMap.get('tenPhong') || '';
    this.responseData = JSON.parse(this.route.snapshot.queryParamMap.get('responseData') || '{}');
  }

  getMethods() {
    this.http
      .get(`${environment.apiUrl}methods/getlist`)
      .subscribe((res: any) => {
        this.methodArray = res;
        console.log(this.methodArray);
      });
  }

  createHoadon() {
    // Tạo payload cho yêu cầu POST
    const payload = {
      khachHang: this.formData.tenKhachHang,
      ngayDen: this.formData.ngayNhan,
      ngayDi: this.formData.ngayTra,
      maDatPhong: this.responseData.maDatPhong,
      tenPhong: this.tenPhong, 
      loaiPhong: this.loaiPhong,
      maPhuongThuc: this.selectedMethod,
      giaPhong: this.giaPhong,
      soNgayDat: this.days,
      tongTien: this.totalPrice
    };
  
    // Gửi yêu cầu POST đến API
    this.http.post(`${environment.apiUrl}invoices/create`, payload).subscribe(
      (response: any) => {
        console.log(response);
        this.router.navigate(['/success']);
      },
      (error) => {
        console.log(error);
      }
    );
  }
}
