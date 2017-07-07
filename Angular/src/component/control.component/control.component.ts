import{ Component} from '@angular/core';
import {CalendarModule, ConfirmDialogModule,ConfirmationService} from 'primeng/primeng';
import { HomeService} from '../../services/home.service'

@Component({
    selector:'control-component',
    templateUrl:'./control.component.html',
    styleUrls:['./control.component.css'],
    providers:[ConfirmationService,
               HomeService]
})

export class ControlComponent{
    message:string='';

    constructor(private confirmationSvc:ConfirmationService,private homeSvc:HomeService){

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
    save(){
        this.homeSvc.save().subscribe(result=>{
            console.log(result);
        });
    }
    get(){
        this.homeSvc.get().subscribe(result=>{
            console.log(result);
        });
    }
}