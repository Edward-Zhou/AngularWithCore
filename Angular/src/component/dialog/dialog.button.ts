import { Component, OnInit } from '@angular/core';
import{ MdDialog,MdDialogRef} from '@angular/material';
import { DialogWindowComponent } from "./dialogWindow";

@Component({
    selector:'dialog-button',
    templateUrl:'dialog.button.html'
})

export class DialogButtonComponent implements OnInit{
    ngOnInit(): void {
    }
    selectedOption: string;
    dialogRef:MdDialogRef<DialogWindowComponent>;
    constructor(public dialog:MdDialog){

    }

    openDialog(){
        let dialogRef=this.dialog.open(DialogWindowComponent);
        dialogRef.afterClosed().subscribe(result=>{
            this.selectedOption=result;
        });
    }
}