import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environment/environment';

@Injectable({
  providedIn: 'root'
})
export class SearchRoomService {

  constructor(private http: HttpClient) {}

  searchRoomInfo(checkIn: string, checkOut: string, id: number){
    return this.http.get(`${environment.apiUrl}searchs/room-by/` + checkIn + '/' + checkOut + '/' + id);
  }

  searchReservations(phoneNumber: string){
    return this.http.get(`${environment.apiUrl}searchs/reservations/` + phoneNumber);
  }

  searchFilter(checkIn: string, checkOut: string, sucChua: string, maLoai: string, tienNghi: string,mucGia: string,nhinRa: string){
    return this.http.get(`${environment.apiUrl}searchs/filter/`+checkIn + '/' +checkOut + '?sucChua=' + sucChua + '&maLoaiPhong=' + maLoai + '&tienNghi=' + tienNghi + '&mucGia=' + mucGia + '&nhinRa=' + nhinRa )
  }
}
