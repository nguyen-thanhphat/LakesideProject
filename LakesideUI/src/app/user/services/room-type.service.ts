import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environment/environment';

@Injectable({
  providedIn: 'root'
})
export class RoomTypeService {

  constructor(private http: HttpClient) { }

  getList(): Observable<any[]>{
    return this.http.get<any[]>(`${environment.apiUrl}roomtypes/getlist`);
  }
}
