import {Component} from '@angular/core';
import {MdDialogRef} from '@angular/material';

@Component({
    selector:'dialog-window',
    templateUrl:'dialogWindow.html'
})

export class DialogWindowComponent{
    constructor(public dialogRef:MdDialogRef<DialogWindowComponent>){

    }
}