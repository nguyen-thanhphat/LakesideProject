import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NotFoundComponent } from './not-found/not-found.component';
import { SearchRoomService } from './user/services/search-room.service';
import { RoomTypeService } from './user/services/room-type.service';
import { LoaiphongService } from './admin/services/loaiphong.service';
import { AuthenticationService } from './admin/services/authentication.service';

@NgModule({
  declarations: [
    AppComponent,
    NotFoundComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [SearchRoomService, RoomTypeService, LoaiphongService, AuthenticationService],
  bootstrap: [AppComponent]
})
export class AppModule { }
