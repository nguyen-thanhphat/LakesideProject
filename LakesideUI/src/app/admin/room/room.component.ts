import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { environment } from 'src/environment/environment';

@Component({
  selector: 'app-room',
  templateUrl: './room.component.html',
  styleUrls: ['./room.component.css']
})
export class RoomComponent {
  roomArray: any[] = [];
  roomTypes: any[] = [];

  tenPhong = '';
  maLoaiPhong: number = 0;

  currentRoomID = '';

  isResultLoaded = false;
  isUpdateFormActive = false;

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.getAllRoom();
    this.getAllType();
  }

  getAllRoom(){
    this.http.get(`${environment.apiUrl}rooms/getlist`).subscribe(
      (resData:any) => {
        this.isResultLoaded = true;
        console.log(resData);
        this.roomArray = resData;
      }
    )
  }

  getAllType(){
    this.http.get(`${environment.apiUrl}roomtypes/getlist`).subscribe(
      (resData:any) => {
        console.log(resData);
        this.roomTypes = resData;
      }
    )
  }

  register(){
    const bodyData = {
      tenPhong: this.tenPhong,
      maLoaiPhong: this.maLoaiPhong
    };

    this.maLoaiPhong

    this.http.post(`${environment.apiUrl}rooms/create?maLoaiPhong=${this.maLoaiPhong}`,bodyData)
    .subscribe((resData: any) => {
      console.log(resData);
      alert('Thêm thành công');
      this.getAllRoom();
      this.resetForm();
    })
  }

  setUpdate(data :any){
    this.currentRoomID = data.maPhong;
    this.tenPhong = data.tenPhong;
    this.maLoaiPhong = data.maLoaiPhong;
    this.isUpdateFormActive = true;
  }

  updateRoom(){
    const bodyData = {
      maLoaiPhong: this.maLoaiPhong
    };

    // this.http.put(`${environment.apiUrl}rooms/edittypeby/` + this.currentRoomID, bodyData)
    this.http.put(`${environment.apiUrl}rooms/edittypeby/` + this.currentRoomID, bodyData, { responseType: 'text' })
    .subscribe((resData:any) => {
      console.log(resData);
      alert('Cập nhật thành công!');
      this.getAllRoom();
      this.resetForm();
      this.isUpdateFormActive = false;
    })
  }

  save(){
    if(this.isUpdateFormActive){
      this.updateRoom();
    } else{
      this.register();
    }
  }

  resetForm(){
    this.tenPhong = '';
    this.maLoaiPhong = 0; 
    this.isUpdateFormActive = false;
  }
}
