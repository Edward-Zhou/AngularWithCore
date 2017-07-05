import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import{ BrowserAnimationsModule}from '@angular/platform-browser/animations';

import { AppComponent } from './app.component';
import {DialogWindowComponent} from '../component/dialog/dialogWindow';
import {DialogButtonComponent} from '../component/dialog/dialog.button'
import { MaterialModule } from "@angular/material";
import { CalendarModule} from 'primeng/primeng';


@NgModule({
  declarations: [
    AppComponent,
    DialogWindowComponent,
    DialogButtonComponent,
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    BrowserAnimationsModule,
    MaterialModule,
    CalendarModule
  ],
  entryComponents:[DialogWindowComponent],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
