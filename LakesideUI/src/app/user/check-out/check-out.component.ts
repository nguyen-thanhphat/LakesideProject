import { HttpClient } from '@angular/common/http';
import { ConstantPool } from '@angular/compiler';
import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { environment } from 'src/environment/environment';

@Component({
  selector: 'app-check-out',
  templateUrl: './check-out.component.html',
  styleUrls: ['./check-out.component.css'],
})
export class CheckOutComponent {

  formData: any;
  days: number = 0;
  totalPrice: number = 0;
  giaPhong: number = 0;
  loaiPhong: string = '';
  methodArray: any[] = [];
  constructor(private http: HttpClient, private route: ActivatedRoute) {
    this.getMethods();
  }

  ngOnInit() {
    this.formData = JSON.parse(this.route.snapshot.queryParamMap.get('formData') || '{}');
    this.days = parseInt(this.route.snapshot.queryParamMap.get('days') || '0', 10);
    this.totalPrice = parseInt(this.route.snapshot.queryParamMap.get('totalPrice') || '0', 10);
    this.giaPhong = parseInt(this.route.snapshot.queryParamMap.get('giaPhong') || '0', 10);
    this.loaiPhong = this.route.snapshot.queryParamMap.get('loaiPhong') || '';
    console.log(this.formData); // Sử dụng dữ liệu formData ở đây
    console.log(this.days); // Giá trị của biến days
    console.log(this.totalPrice); // Giá trị của biến totalPrice
    console.log(this.giaPhong);
    console.log(this.loaiPhong);
  }

  getMethods() {
    this.http
      .get(`${environment.apiUrl}methods/getlist`)
      .subscribe((res: any) => {
        this.methodArray = res;
        console.log(this.methodArray);
      });
  }
}
