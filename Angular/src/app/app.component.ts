import { Component } from '@angular/core';



@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css',
              '../../node_modules/primeng/resources/themes/omega/theme.css',
              '../../node_modules/primeng/resources/primeng.min.css',
              '../../node_modules/font-awesome/css/font-awesome.min.css'
             
  ]
})
export class AppComponent {
  title:string='';
  dateTime?:Date;
  constructor(){
    this.title = 'My First Angular App';
    
  }
}
