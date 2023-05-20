import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { RoomTypeService } from 'src/app/user/services/room-type.service';
import { environment } from 'src/environment/environment';

@Component({
  selector: 'app-available-by-type',
  templateUrl: './available-by-type.component.html',
  styleUrls: ['./available-by-type.component.css']
})
export class AvailableByTypeComponent {
  roomResults: any[] = [];
  checkIn: string = '';
  checkOut: string = '';
  type: string = '';
  TypeRoomArray: any[] = [];
  constructor(private http: HttpClient,
    private typeService: RoomTypeService,) {}

  ngOnInit(): void {
    this.getAvailableRoom();
    this.getListType();
  }

  getAvailableRoom(){
    this.http.get(`${environment.apiUrl}searchs/listroom-by/${this.checkIn}/${this.checkOut}/${this.type}`)
    .subscribe((resData: any) => {
      this.roomResults = resData;
      console.log(this.roomResults);
    })
  }

  getListType(){
    this.typeService.getList().subscribe((resultData:any) => {
      console.log(resultData);
      this.TypeRoomArray = resultData;
    })
  }
}
