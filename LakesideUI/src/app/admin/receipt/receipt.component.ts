import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { environment } from 'src/environment/environment';

@Component({
  selector: 'app-receipt',
  templateUrl: './receipt.component.html',
  styleUrls: ['./receipt.component.css']
})
export class ReceiptComponent {
  invoicesList : any[] = [];

  currentPage: number = 1;
  itemsPerPage: number = 10;
  totalItems: number = 0;
  totalPages: number = 0;
  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.getListInvoices();
  }

  getListInvoices(){
    this.http.get(`${environment.apiUrl}invoices/getlist`).subscribe((resData: any) => {
      this.invoicesList = resData;
      console.log(this.invoicesList);
    });
  }

  getPagesArray(): number[] {
    this.totalPages = Math.ceil(this.totalItems / this.itemsPerPage);
   return Array(this.totalPages).fill(0).map((_, index) => index + 1);
 }

 onPageChange(page: number): void {
   this.currentPage = page;
 }

 getPaginatedData(): any[] {
   const startIndex = (this.currentPage - 1) * this.itemsPerPage;
   return this.invoicesList.slice(startIndex, startIndex + this.itemsPerPage);
 }
}
