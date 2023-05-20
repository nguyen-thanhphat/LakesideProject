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
import { GrowthChartComponent } from './growth-chart/growth-chart.component';
import { RevenueInRangeComponent } from './stats/revenue-in-range/revenue-in-range.component';
import { RevenueInMonthComponent } from './stats/revenue-in-month/revenue-in-month.component';
import { LowDemandRoomComponent } from './stats/low-demand-room/low-demand-room.component';
import { LowDemandRoomMonthComponent } from './stats/low-demand-room-month/low-demand-room-month.component';
import { PaidComponent } from './booking/paid/paid.component';
import { BookedComponent } from './booking/booked/booked.component';
import { CanceledComponent } from './booking/canceled/canceled.component';
import { RefusedComponent } from './booking/refused/refused.component';
import { AvailableRoomsComponent } from './room/available-rooms/available-rooms.component';
import { AvailableByTypeComponent } from './room/available-by-type/available-by-type.component';


@NgModule({
  declarations: [
    DashboardComponent,
    StatsComponent,
    LoaiphongComponent,
    RoomComponent,
    ReceiptComponent,
    BookingComponent,
    LoginComponent,
    GrowthChartComponent,
    RevenueInRangeComponent,
    RevenueInMonthComponent,
    LowDemandRoomComponent,
    LowDemandRoomMonthComponent,
    PaidComponent,
    BookedComponent,
    CanceledComponent,
    RefusedComponent,
    AvailableRoomsComponent,
    AvailableByTypeComponent
  ],
  imports: [
    CommonModule,
    HttpClientModule,
    FormsModule,
    AdminRoutingModule
  ]
})
export class AdminModule { }
