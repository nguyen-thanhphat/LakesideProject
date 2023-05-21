import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { environment } from 'src/environment/environment';
import { SearchRoomService } from '../services/search-room.service';

@Component({
  selector: 'app-roomdetails',
  templateUrl: './roomdetails.component.html',
  styleUrls: ['./roomdetails.component.css']
})
export class RoomdetailsComponent {
  searchResult: any = {};
  searchForm!: FormGroup;
  roomId: number = 0;

  roomType: any;

  constructor(
    private searchService: SearchRoomService,
    private route: ActivatedRoute, 
    private http: HttpClient,
    private formBuilder: FormBuilder,
    private router: Router) {}

  ngOnInit(): void {
    this.route.paramMap.subscribe(params => {
      const id = params.get('id');
      if (id) {
        const roomId = parseInt(id, 10);
        this.getRoomTypeById(roomId);
      } else {
        console.error('Không tìm thấy ID trong địa chỉ URL.');
      }
    });

    this.searchForm = this.formBuilder.group({
      checkIn: ['', Validators.required],
      checkOut: ['', Validators.required],
    });
  }

  onSubmit(){
    const checkIn = this.searchForm.value.checkIn;
    const checkOut = this.searchForm.value.checkOut;


    // Kiểm tra ngày checkIn phải đến trước ngày checkOut
    if (new Date(checkIn) > new Date(checkOut)) {
      alert('Ngày nhận phòng phải đến trước ngày trả phòng!');
      return;
    }

    const maLoai = this.roomId;
    const days = this.calculateDays(checkIn, checkOut);
    this.searchService
    .searchRoomInfo(checkIn, checkOut, maLoai)
    .subscribe((data: any) => {
      this.searchResult = data;
      console.log(this.searchResult);

      //Chuyển hướng đến MyBooking
      this.router.navigate([
        '/info-booking',
        {
          searchResult: JSON.stringify(this.searchResult),
          days: days,
          checkIn: checkIn,
          checkOut: checkOut,
        },
      ]);
    })
  }

  calculateDays(checkIn: string, checkOut: string): number {
    const diff = new Date(checkOut).getTime() - new Date(checkIn).getTime();
    return diff / (1000 * 60 * 60 * 24);
  }

  getRoomTypeById(id: number) {
    this.roomId = id;
    this.http.get(`${environment.apiUrl}roomtypes/getby/${id}`).subscribe(
      (resData: any) => {
        this.roomType = resData;
        console.log(this.roomType);
      },
      (error: any) => {
        console.error('Đã xảy ra lỗi khi lấy thông tin loại phòng:', error);
      }
    );
  }

  getFileNameFromUrl(url: string): string {
    const parts = url.split('/');
    return parts[parts.length - 1];
  }
}
