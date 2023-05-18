import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomepageComponent } from './homepage/homepage.component';
import { MainComponent } from './main/main.component';
import { InfoBookingComponent } from './info-booking/info-booking.component';
import { CheckOutComponent } from './check-out/check-out.component';
import { SuccessComponent } from './success/success.component';

const routes: Routes = [
  { path: '', component: HomepageComponent, children: [
    {
      path:'',
      component: MainComponent
    },
    {
      path:'info-booking',
      component: InfoBookingComponent
    },
    {
      path:'check-out',
      component: CheckOutComponent
    },
    {
      path:'success',
      component: SuccessComponent
    }
  ]}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UserRoutingModule { }
