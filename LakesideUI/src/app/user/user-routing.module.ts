import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomepageComponent } from './homepage/homepage.component';
import { MainComponent } from './main/main.component';
import { InfoBookingComponent } from './info-booking/info-booking.component';
import { CheckOutComponent } from './check-out/check-out.component';
import { SuccessComponent } from './success/success.component';
import { RoomdetailsComponent } from './roomdetails/roomdetails.component';
import { InfoNewComponent } from './info-new/info-new.component';
import { FeedbackComponent } from './feedback/feedback.component';
import { SearchFilterComponent } from './search-filter/search-filter.component';

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
    },
    {
      path:'loaiphong/:id',
      component: RoomdetailsComponent
    },
    {
      path:'new',
      component: InfoNewComponent
    },
    {
      path:'feedback',
      component: FeedbackComponent
    },
    {
      path:'search',
      component: SearchFilterComponent
    }
  ]}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UserRoutingModule { }
