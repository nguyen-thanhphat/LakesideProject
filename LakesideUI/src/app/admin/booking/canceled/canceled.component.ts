import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { environment } from 'src/environment/environment';

@Component({
  selector: 'app-canceled',
  templateUrl: './canceled.component.html',
  styleUrls: ['./canceled.component.css']
})
export class CanceledComponent {
  bookingList: any[] = [];

  currentPage: number = 1;
  itemsPerPage: number = 10;
  totalItems: number = 0;
  totalPages: number = 0;

  currentBookingID = '';
  trangThai = '';
  ngayDat = '';
  tenKhachHang = '';
  soDienThoai = '';
  isUpdateFormActive = false;
  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.getListBooking();
  }

  getListBooking(){
    this.http.get(`${environment.apiUrl}manage/get-states/%C4%90%C3%A3%20hu%E1%BB%B7`).subscribe((resData: any) =>{
      this.bookingList = resData;
      console.log(this.bookingList);
    } )
  }

  setUpdate(data:any) {
    this.trangThai = data.trangThai;
    this.ngayDat = data.ngayDat;
    this.tenKhachHang = data.tenKhachHang;
    this.soDienThoai = data.soDienThoai;
    this.currentBookingID = data.maDatphong;
    this.isUpdateFormActive = true;
  }

  updateState(){
    const bodyData = {
      trangThai: this.trangThai
    };
    this.http.put(`${environment.apiUrl}manage/edit-state/` + this.currentBookingID, bodyData, { responseType: 'text' })
      .subscribe((resData: any) => {
        console.log(resData);
        alert('Cập nhật trạng thái thành công');
        this.getListBooking();
        this.isUpdateFormActive = false;
      })
  }

  save(){
    this.updateState();
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
  
  // getPagesArray(): number[] {
  //   const totalPages = Math.ceil(this.totalItems / this.itemsPerPage);
  //   return Array(totalPages).fill(0).map((_, index) => index + 1);
  // }

  getPagesArray(): number[] {
     this.totalPages = Math.ceil(this.totalItems / this.itemsPerPage);
    return Array(this.totalPages).fill(0).map((_, index) => index + 1);
  }

  onPageChange(page: number): void {
    this.currentPage = page;
  }

  getPaginatedData(): any[] {
    const startIndex = (this.currentPage - 1) * this.itemsPerPage;
    return this.bookingList.slice(startIndex, startIndex + this.itemsPerPage);
  }

}