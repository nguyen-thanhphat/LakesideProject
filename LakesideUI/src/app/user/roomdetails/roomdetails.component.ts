import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { environment } from 'src/environment/environment';

@Component({
  selector: 'app-roomdetails',
  templateUrl: './roomdetails.component.html',
  styleUrls: ['./roomdetails.component.css']
})
export class RoomdetailsComponent {
  roomType: any;

  constructor(private route: ActivatedRoute, private http: HttpClient) {}

  ngOnInit() {
    this.route.paramMap.subscribe(params => {
      const id = params.get('id');
      if (id) {
        const roomId = parseInt(id, 10);
        this.getRoomTypeById(roomId);
      } else {
        console.error('Không tìm thấy ID trong địa chỉ URL.');
      }
    });
  }

  getRoomTypeById(id: number) {
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
}
