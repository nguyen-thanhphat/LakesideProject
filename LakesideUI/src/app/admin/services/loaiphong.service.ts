import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environment/environment';

@Injectable({
  providedIn: 'root'
})
export class LoaiphongService {

  constructor(private http: HttpClient) { }

  getRoomTypes(): Observable<any> {
    return this.http.get<any>(`${environment.apiUrl}roomtypes/getlist`);
  }

  getRoomType(id: number): Observable<any> {
    return this.http.get<any>(`${environment.apiUrl}roomtypes/getby/${id}`);
  }

  createRoomType(roomType: any): Observable<any> {
    return this.http.post<any>(`${environment.apiUrl}roomtypes/create`, roomType);
  }

  updateRoomType(id: number, roomType: any): Observable<any> {
    return this.http.put<any>(`${environment.apiUrl}roomtypes/editby/${id}`, roomType);
  }

  //Lưu ý khi xoá một loại phòng có liên kết vs phòng gây ra lỗi
  deleteRoomType(id: number): Observable<any> {
    return this.http.delete<any>(`${environment.apiUrl}roomtypes/delby/${id}`);
  }
}
