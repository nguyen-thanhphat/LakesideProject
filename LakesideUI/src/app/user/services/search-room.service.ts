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
}
