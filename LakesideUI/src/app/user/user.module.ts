import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { UserRoutingModule } from './user-routing.module';
import { HomepageComponent } from './homepage/homepage.component';
import { MainComponent } from './main/main.component';
import { FeedbackComponent } from './feedback/feedback.component';
import { InfoNewComponent } from './info-new/info-new.component';
import { IntroduceComponent } from './introduce/introduce.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { InfoBookingComponent } from './info-booking/info-booking.component';


@NgModule({
  declarations: [
    HomepageComponent,
    MainComponent,
    FeedbackComponent,
    InfoNewComponent,
    IntroduceComponent,
    InfoBookingComponent
  ],
  imports: [
    CommonModule,
    UserRoutingModule,
    FormsModule,
    ReactiveFormsModule
  ]
})
export class UserModule { }
