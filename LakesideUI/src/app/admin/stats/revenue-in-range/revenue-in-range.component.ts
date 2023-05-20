import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { environment } from 'src/environment/environment';

@Component({
  selector: 'app-revenue-in-range',
  templateUrl: './revenue-in-range.component.html',
  styleUrls: ['./revenue-in-range.component.css']
})
export class RevenueInRangeComponent {
  startDate: string = '';
  endDate: string = '';
  value: number = 0;

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.getList();
  }

  getList(){
    this.http.get(`${environment.apiUrl}stats/revenue/${this.startDate}/${this.endDate}`)
    .subscribe((resData: any) => {
      this.value = resData;
      console.log(this.value);
    })
  }
}