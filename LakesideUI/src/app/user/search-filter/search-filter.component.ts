import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { SearchRoomService } from '../services/search-room.service';
import { environment } from 'src/environment/environment';
import { RoomTypeService } from '../services/room-type.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-search-filter',
  templateUrl: './search-filter.component.html',
  styleUrls: ['./search-filter.component.css'],
})
export class SearchFilterComponent {
  searchResult: any[] = [];
  searchForm!: FormGroup;
  TypeRoomArray: any[] = [];

  searchRoom: any[] = [];
 
  constructor(
    private searchService: SearchRoomService,
    private formBuilder: FormBuilder,
    private typeService: RoomTypeService,
    private router: Router
  ) {
    this.getListType();
  }

  ngOnInit(): void {
    this.searchForm = this.formBuilder.group({
      checkIn: [new Date().toISOString().substring(0, 10), Validators.required],
      checkOut: ['', Validators.required],
      sucChua: ['', Validators.required],
      maLoai: ['', Validators.required],
      tienNghi: ['', Validators.required],
      mucGia: ['', Validators.required],
      nhinRa: ['', Validators.required]
    });
  }

  onSubmit() {
    const checkIn = this.searchForm.value.checkIn;
    const checkOut = this.searchForm.value.checkOut;
    const sucChua = this.searchForm.value.sucChua;
    const maLoai = this.searchForm.value.maLoai;
    const tienNghi = this.searchForm.value.tienNghi;
    const mucGia = this.searchForm.value.mucGia;
    const nhinRa = this.searchForm.value.nhinRa;

    this.searchService
      .searchFilter(
        checkIn,
        checkOut,
        sucChua,
        maLoai,
        tienNghi,
        mucGia,
        nhinRa
      )
      .subscribe((data: any) => {
        this.searchRoom = data;
        console.log(this.searchRoom);
      });
      console.error();
      
  }

  onBooking(item: any){
    const checkIn = this.searchForm.value.checkIn;
    const checkOut = this.searchForm.value.checkOut;

    const days = this.calculateDays(checkIn, checkOut);
    this.router.navigate([
      '/info-booking',
      {
        //searchResult.maPhong,
        searchResult: JSON.stringify(item),
        days: days,
        checkIn: checkIn,
        checkOut: checkOut,
      },
    ]);
  }

  calculateDays(checkIn: string, checkOut: string): number {
    const diff = new Date(checkOut).getTime() - new Date(checkIn).getTime();
    return diff / (1000 * 60 * 60 * 24);
  }

  getListType() {
    this.typeService.getList().subscribe((resultData: any) => {
      console.log(resultData);
      this.TypeRoomArray = resultData;
    });
  }

  viewRoomTypeDetail(id: string) {
    this.router.navigate(['/loaiphong', id]);
  }

  getFileNameFromUrl(url: string): string {
    const parts = url.split('/');
    return parts[parts.length - 1];
  }
}
