import { Component } from '@angular/core';

import {MenuItem} from 'primeng/components/common/api';



@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'             
  ]
})
export class AppComponent {
  title:string='';
  dateTime?:Date;
  constructor(){
    this.title = 'My First Angular App';   
  }
}
