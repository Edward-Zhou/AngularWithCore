import{ Component} from '@angular/core';
import {CalendarModule, ConfirmDialogModule,ConfirmationService} from 'primeng/primeng';

@Component({
    selector:'control-component',
    templateUrl:'./control.component.html',
    styleUrls:['./control.component.css'],
    providers:[ConfirmationService]
})

export class ControlComponent{
    message:string='';

    constructor(private confirmationSvc:ConfirmationService){

    }

    confirm(){
        this.confirmationSvc.confirm({
            message: 'Are you sure that you want to perform this action?',
            accept: () => {
                //Actual logic to perform a confirmation
                this.message="Deleted";
            },
            reject: () => {
                this.message = "Reject";
            }
        });
    }
}