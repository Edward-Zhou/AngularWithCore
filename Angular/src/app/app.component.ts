import { Component } from '@angular/core';

import {MenuItem} from 'primeng/components/common/api';
import{ConfirmationService} from'primeng/primeng';



@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'             
  ],
  providers:[ConfirmationService]
})
export class AppComponent {
  title:string='';
  dateTime?:Date;
  constructor(private confirmationService: ConfirmationService){
    this.title = 'My First Angular App';   
  }

  confirm() {
        this.confirmationService.confirm({
            message: 'Are you sure that you want to perform this action?',
            accept: () => {
                //Actual logic to perform a confirmation
                this.title="Deleted";
            },
            reject: () => {
                this.title = "Reject";
            }
        });
    }
}
