import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { environment } from 'src/environment/environment';

@Component({
  selector: 'app-available-rooms',
  templateUrl: './available-rooms.component.html',
  styleUrls: ['./available-rooms.component.css']
})
export class AvailableRoomsComponent {
  roomResults: any[] = [];
  checkIn: string = '';
  checkOut: string = '';
  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.getAvailableRoom();
  }

  getAvailableRoom(){
    this.http.get(`${environment.apiUrl}searchs/available-rooms/${this.checkIn}/${this.checkOut}`)
    .subscribe((resData: any) => {
      this.roomResults = resData;
      console.log(this.roomResults);
    })
  }
}
