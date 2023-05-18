import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from './dashboard/dashboard.component';
import { StatsComponent } from './stats/stats.component';
import { RoomComponent } from './room/room.component';
import { LoaiphongComponent } from './loaiphong/loaiphong.component';
import { ReceiptComponent } from './receipt/receipt.component';
import { BookingComponent } from './booking/booking.component';

const routes: Routes = [
  {
    path: '',
    component: DashboardComponent,
    children: [
      {
        path:'',
        component: StatsComponent
      },
      {
        path:'room',
        component: RoomComponent
      },
      {
        path:'type-room',
        component: LoaiphongComponent
      },
      {
        path:'receipt',
        component: ReceiptComponent
      },
      {
        path:'booking',
        component: BookingComponent
      }
    ]}
  ];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule { }
