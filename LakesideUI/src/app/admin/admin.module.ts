import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AdminRoutingModule } from './admin-routing.module';
import { DashboardComponent } from './dashboard/dashboard.component';
import { StatsComponent } from './stats/stats.component';
import { LoaiphongComponent } from './loaiphong/loaiphong.component';
import { RoomComponent } from './room/room.component';
import { ReceiptComponent } from './receipt/receipt.component';
import { BookingComponent } from './booking/booking.component';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { LoginComponent } from './login/login.component';


@NgModule({
  declarations: [
    DashboardComponent,
    StatsComponent,
    LoaiphongComponent,
    RoomComponent,
    ReceiptComponent,
    BookingComponent,
    LoginComponent
  ],
  imports: [
    CommonModule,
    HttpClientModule,
    FormsModule,
    AdminRoutingModule
  ]
})
export class AdminModule { }
