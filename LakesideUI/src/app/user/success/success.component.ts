import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { SearchRoomService } from '../services/search-room.service';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environment/environment';

@Component({
  selector: 'app-success',
  templateUrl: './success.component.html',
  styleUrls: ['./success.component.css']
})
export class SuccessComponent {

  currentBookingID = '';
  searchResult: any = {};
  searchForm!: FormGroup;

  constructor(
    private searchService: SearchRoomService,
    private http: HttpClient,
    private formBuilder: FormBuilder,
  ){}

  ngOnInit(): void {
    this.searchForm = this.formBuilder.group({
      phoneNumber: ['', Validators.required]
    })
  }

  onSubmit(){
    const phoneNumber = this.searchForm.value.phoneNumber;

    this.searchService
      .searchReservations(phoneNumber)
      .subscribe((data: any) => {
        this.searchResult = data;
        console.log(this.searchResult);
      })
  }

  cancelBooking(){
    const state = 'Đã huỷ'

    this.http.put(`${environment.apiUrl}manage/edit-state/` + this.currentBookingID, state, { responseType: 'text' })
    .subscribe((resData: any) => {
      console.log(resData);
      alert('Cập nhật trạng thái thành công');
      this.searchResult();
    })
  }
} 
