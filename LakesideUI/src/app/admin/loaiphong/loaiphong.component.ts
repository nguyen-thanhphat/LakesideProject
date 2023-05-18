import { Component, OnInit } from '@angular/core';
import { LoaiphongService } from '../services/loaiphong.service';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environment/environment';

@Component({
  selector: 'app-loaiphong',
  templateUrl: './loaiphong.component.html',
  styleUrls: ['./loaiphong.component.css']
})
export class LoaiphongComponent implements OnInit {
  roomTypes: any[] = [];
  isResultLoaded = false;
  isUpdateFormActive = false;

  tenLoaiPhong = '';
  tienIch = '';
  nhinRa = '';
  kichCo = '';
  giaPhong = 0;
  urlImage = '';
  sucChua = 0;
  phuThu = 0;

  currentTypeID = '';

  constructor(private loaiPhongService: LoaiphongService,
    private http: HttpClient) {}

  ngOnInit(): void {
    this.getRoomTypes();
  }

  getRoomTypes() {
    this.loaiPhongService.getRoomTypes().subscribe(
      (data: any[]) => {
        this.isResultLoaded = true;
        console.log(data);
        this.roomTypes = data;
      },
      error => {
        console.log('Error:', error);
      }
    );
  }

  register(){
    const bodyData = {
      tenLoaiPhong: this.tenLoaiPhong,
      tienIch: this.tienIch,
      nhinRa: this.nhinRa,
      kichCo: this.kichCo,
      giaPhong: this.giaPhong,
      urlImage: this.urlImage,
      sucChua: this.sucChua,
      phuThu: this.phuThu
    };

    this.loaiPhongService.createRoomType(bodyData)
      .subscribe((resData: any) => {
        console.log(resData);
        alert('Thêm loại phòng thành công!');
        this.getRoomTypes();
        this.resetForm();
      },
      error => {
        console.log('Error:', error);
      });
  }

  setUpdate(data: any) {
    this.tenLoaiPhong = data.tenLoaiPhong;
    this.tienIch = data.tienIch;
    this.nhinRa = data.nhinRa;
    this.kichCo = data.kichCo;
    this.giaPhong = data.giaPhong;
    this.urlImage = data.urlImage;
    this.sucChua = data.sucChua;
    this.phuThu = data.phuThu;
    this.currentTypeID = data.maLoaiPhong;
    this.isUpdateFormActive = true;
  }

  updateTypes(){
    const bodyData = {
      maLoaiPhong: this.currentTypeID,
      tenLoaiPhong: this.tenLoaiPhong,
      tienIch: this.tienIch,
      nhinRa: this.nhinRa,
      kichCo: this.kichCo,
      giaPhong: this.giaPhong,
      urlImage: this.urlImage,
      sucChua: this.sucChua,
      phuThu: this.phuThu
    };

    this.http.put(`${environment.apiUrl}roomtypes/editby/` + this.currentTypeID, bodyData)
    .subscribe((resData:any) => {
      console.log(resData);
      alert('Cập nhật loại phòng thành công!');
      this.getRoomTypes();
      this.resetForm()
      this.isUpdateFormActive = false;
    })
  }

  save(){
    if(this.isUpdateFormActive){
      this.updateTypes();
    } else{
      this.register();
    }
  }

  setDelete(data: any){
    // this.http.delete(`${environment.apiUrl}roomtypes/delby/` + data.maLoaiPhong)
    this.http.delete(`${environment.apiUrl}roomtypes/` + data.maLoaiPhong)
    .subscribe((resData: any) => {
      console.log(resData);
      alert('Đã xoá loại phòng');
      this.getRoomTypes();
    },
    error => {
      alert('Loại phòng này có phòng kèm theo không thể xoá!!!')
      console.log('Error:', error);
    })
  }

  resetForm(){
    this.tenLoaiPhong = '';
    this.tienIch = '';
    this.nhinRa = '';
    this.kichCo = '';
    this.giaPhong = 0;
    this.urlImage = '';
    this.sucChua = 0;
    this.phuThu = 0;
    this.currentTypeID = '';
    this.isUpdateFormActive = false;
  }
}
