import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { environment } from 'src/environment/environment';

@Component({
  selector: 'app-booking',
  templateUrl: './booking.component.html',
  styleUrls: ['./booking.component.css']
})
export class BookingComponent {
  bookingList: any[] = [];

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.getListBooking();
  }

  getListBooking(){
    this.http.get(`${environment.apiUrl}reservations/getlist`).subscribe((resData: any) =>{
      this.bookingList = resData;
      console.log(this.bookingList);
    } )
  }

  getTrangThaiColor(trangThai: string): string {
    if (trangThai === 'Đã đặt') {
      return 'blue'; // Màu xanh cho trạng thái 'Đã đặt'
    } else if (trangThai === 'Đã thanh toán') {
      return 'green'; // Màu xanh lá cây cho trạng thái 'Đã xác nhận'
    } else if (trangThai === 'Đã huỷ') {
      return 'red'; // Màu xanh lá cây cho trạng thái 'Đã xác nhận'
    } else {
      return 'black'; // Màu mặc định cho các trạng thái khác
    }
  }
  
}
