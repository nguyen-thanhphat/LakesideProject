import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { environment } from 'src/environment/environment';

@Component({
  selector: 'app-revenue-in-month',
  templateUrl: './revenue-in-month.component.html',
  styleUrls: ['./revenue-in-month.component.css']
})
export class RevenueInMonthComponent {
  revenue: number = 0;
  month: string = '';

  constructor(private http: HttpClient) {}

  ngOnInit(){
    this.getRevenueInMonth();
  }

  getRevenueInMonth(){
    this.http.get(`${environment.apiUrl}stats/revenue-in-month/${this.month}`)
      .subscribe((resData:any) => {
        this.revenue = resData;
      })
  }
}
