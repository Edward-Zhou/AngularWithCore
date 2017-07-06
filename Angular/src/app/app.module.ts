import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import{ BrowserAnimationsModule}from '@angular/platform-browser/animations';

import { AppComponent } from './app.component';
import {DialogWindowComponent} from '../component/dialog/dialogWindow';
import {DialogButtonComponent} from '../component/dialog/dialog.button'
import { MaterialModule } from "@angular/material";
import { CalendarModule,ConfirmDialogModule} from 'primeng/primeng';
import { ControlComponent } from "../component/control.component/control.component";

const appRoutes:Routes=[
  {path:'app',component:AppComponent},
  {path:'control',component:ControlComponent},
  {path:'',component:AppComponent}
];

@NgModule({
  declarations: [
    AppComponent,
    DialogWindowComponent,
    DialogButtonComponent,
    ControlComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    BrowserAnimationsModule,
    MaterialModule,
    CalendarModule,
    ConfirmDialogModule,
    RouterModule.forRoot(
      appRoutes,
      {enableTracing:true}
    )
   
  ],
  entryComponents:[DialogWindowComponent],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
