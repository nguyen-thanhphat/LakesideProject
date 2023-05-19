import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { environment } from 'src/environment/environment';
import { SearchRoomService } from '../services/search-room.service';
import { Router } from '@angular/router';
import { RoomTypeService } from '../services/room-type.service';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.css']
})
export class MainComponent implements OnInit {
  searchResult: any = {};
  searchForm!: FormGroup;

  TypeRoomArray: any[] = [];
  currentPage = 1;
  itemsPerPage = 3;
  totalItems = 0;

  constructor(
    private searchService: SearchRoomService,
    private typeService: RoomTypeService,
    private formBuilder: FormBuilder,
    private router: Router,
    private http: HttpClient
  ) {
    this.getListType();
  }

  ngOnInit(): void {
    this.searchForm = this.formBuilder.group({
      checkIn: ['', Validators.required],
      checkOut: ['', Validators.required],
      maLoai: ['', Validators.required],
    });
  }

  onSubmit() {
    const checkIn = this.searchForm.value.checkIn;
    const checkOut = this.searchForm.value.checkOut;

    // Kiểm tra ngày checkIn phải đến trước ngày checkOut
    if (new Date(checkIn) > new Date(checkOut)) {
      alert('Ngày nhận phòng phải đến trước ngày trả phòng!');
      return;
    }

    const maLoai = this.searchForm.value.maLoai;
    const days = this.calculateDays(checkIn, checkOut);
    this.searchService
      .searchRoomInfo(checkIn, checkOut, maLoai)
      .subscribe((data: any) => {
        this.searchResult = data;
        console.log(this.searchResult);

        //Chuyển hướng đến MyBooking
        this.router.navigate([
          '/info-booking',
          {
            searchResult: JSON.stringify(this.searchResult),
            days: days,
            checkIn: checkIn,
            checkOut: checkOut,
          },
        ]);
      });
  }

  calculateDays(checkIn: string, checkOut: string): number {
    const diff = new Date(checkOut).getTime() - new Date(checkIn).getTime();
    return diff / (1000 * 60 * 60 * 24);
  }

  getListType(){
    this.typeService.getList().subscribe((resultData:any) => {
      console.log(resultData);
      this.TypeRoomArray = resultData;
      this.totalItems = this.TypeRoomArray.length;
    })
  }

  //#region pagination

  get pagedItems() {
    const startIndex = (this.currentPage - 1) * this.itemsPerPage;
    const endIndex = startIndex + this.itemsPerPage;
    return this.TypeRoomArray.slice(startIndex, endIndex);
  }
  
  get totalPages() {
    return Math.ceil(this.totalItems / this.itemsPerPage);
  }

  goToPage(page: number) {
    if (page >= 1 && page <= this.totalPages) {
      this.currentPage = page;
    }
  }
  
  goToPreviousPage() {
    if (this.currentPage > 1) {
      this.currentPage--;
    }
  }
  
  goToNextPage() {
    if (this.currentPage < this.totalPages) {
      this.currentPage++;
    }
  }  

  get totalPagesArray() {
    return Array.from({ length: this.totalPages }, (_, index) => index + 1);
  }
  //#endregion
  
  viewRoomTypeDetail(id: string) {
    this.router.navigate(['/loaiphong', id]);
  }
}