import { Component, OnInit } from '@angular/core';
import { LoaiphongService } from '../services/loaiphong.service';
import { HttpClient } from '@angular/common/http';
import { DomSanitizer } from '@angular/platform-browser';
import { environment } from 'src/environment/environment';

@Component({
  selector: 'app-type-room',
  templateUrl: './type-room.component.html',
  styleUrls: ['./type-room.component.css'],
})
export class TypeRoomComponent implements OnInit {
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

  currentTypeID = 0;

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.getRoomTypes();
  }

  getRoomTypes() {
    this.http.get<any[]>(`${environment.apiUrl}roomtypes/getlist`).subscribe(
      (data) => {
        this.isResultLoaded = true;
        console.log(data);
        this.roomTypes = data;
      },
      (error) => {
        console.log('Error:', error);
      }
    );
  }

  createRoomType() {
    const bodyData = {
      tenLoaiPhong: this.tenLoaiPhong,
      tienIch: this.tienIch,
      nhinRa: this.nhinRa,
      kichCo: this.kichCo,
      giaPhong: this.giaPhong,
      sucChua: this.sucChua,
      phuThu: this.phuThu,
    };

    this.http
      .post<any>(`${environment.apiUrl}roomtypes/create`, bodyData)
      .subscribe(
        (resData) => {
          console.log(resData);
          alert('Thêm loại phòng thành công!');
          this.uploadImage(resData.maLoaiPhong);
          this.getRoomTypes();
          this.resetForm();
        },
        (error) => {
          console.log('Error:', error);
          alert('Thêm loại phòng không thành công!');
        }
      );
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

  updateRoomType() {
    const bodyData = {
      maLoaiPhong: this.currentTypeID,
      tenLoaiPhong: this.tenLoaiPhong,
      tienIch: this.tienIch,
      nhinRa: this.nhinRa,
      kichCo: this.kichCo,
      giaPhong: this.giaPhong,
      sucChua: this.sucChua,
      phuThu: this.phuThu,
    };

    this.http
      .put<any>(
        `${environment.apiUrl}roomtypes/editby/` + this.currentTypeID,
        bodyData
      )
      .subscribe((resData) => {
        console.log(resData);
        alert('Cập nhật loại phòng thành công!');
        this.uploadImage(this.currentTypeID);
        this.getRoomTypes();
        this.resetForm();
        this.isUpdateFormActive = false;
      });
  }

  save() {
    if (this.isUpdateFormActive) {
      this.updateRoomType();
    } else {
      this.createRoomType();
    }
  }

  deleteRoomType(data: any) {
    this.http
      .delete<any>(`${environment.apiUrl}roomtypes` + data.maLoaiPhong)
      .subscribe(
        (resData) => {
          console.log(resData);
          alert('Đã xoá loại phòng');
          this.getRoomTypes();
        },
        (error) => {
          console.log('Error:', error);
          alert('Loại phòng này có phòng kèm theo không thể xoá!!!');
        }
      );
  }

  uploadImage(id: number) {
    const fileInput = document.getElementById('imageInput') as HTMLInputElement;
    const file = fileInput?.files?.[0];

    if (!file) {
      return;
    }

    const formData = new FormData();
    formData.append('file', file);

    this.http
      .post<any>(`${environment.apiUrl}roomtypes/upload-image/` + id, formData)
      .subscribe((resData) => {
        console.log(resData);
        //alert('Upload hình ảnh thành công.');
      });
  }

  resetForm() {
    this.tenLoaiPhong = '';
    this.tienIch = '';
    this.nhinRa = '';
    this.kichCo = '';
    this.giaPhong = 0;
    this.sucChua = 0;
    this.phuThu = 0;
    this.currentTypeID = 0;
    this.isUpdateFormActive = false;
  }

  getFileNameFromUrl(url: string): string {
    const parts = url.split('/');
    return parts[parts.length - 1];
  }
}
