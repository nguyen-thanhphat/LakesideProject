import { Component, OnInit, ViewChild, ElementRef, AfterViewInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CategoryScale, Chart, LineController, LineElement, LinearScale, PointElement, Tooltip } from 'chart.js';
import { environment } from 'src/environment/environment';
import { tick } from '@angular/core/testing';

@Component({
  selector: 'app-growth-chart',
  templateUrl: './growth-chart.component.html',
  styleUrls: ['./growth-chart.component.css']
})
export class GrowthChartComponent implements OnInit, AfterViewInit {
  @ViewChild('growthChart', { static: false }) growthChartRef!: ElementRef;
  chart: any;
  labels: string[] = [];
  values: number[] = [];

  data: any[] = [];

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.getChartData();
    Chart.register(CategoryScale, LinearScale, PointElement, LineController, Tooltip, LineElement);
  }

  ngAfterViewInit(): void {
    if (this.labels.length > 0 && this.values.length > 0) {
      this.createChart();
    }
  }

  getChartData(): void {
    this.http.get<any>(`${environment.apiUrl}stats/revenue-by-month`).subscribe(data => {
      this.labels = data.labels; // Array of time labels (months, quarters, years)
      this.values = data.values; // Array of corresponding revenue values

      console.log(this.values);
      console.log(this.labels);      
      if (this.labels.length > 0 && this.values.length > 0) {
        this.createChart();
      }
    });
  }

  createChart(): void {
    this.chart = new Chart(this.growthChartRef.nativeElement, {
      type: 'line',
      data: {
        labels: this.labels,
        datasets: [
          {
            label: 'Doanh thu',
            data: this.values,
            borderColor: 'green',
            fill: false
          }
        ]
      },
      options: {
        responsive: true,
        scales: {
          x: {
            type: 'category', // Use 'category' scale type for x-axis
            display: true,
            title: {
              display: true,
              text: 'Thời gian'
            }
          },
          y: {
            display: true,
            title: {
              display: true,
              text: 'Doanh thu'
            }
          }
        }
      }
    });
  }
}