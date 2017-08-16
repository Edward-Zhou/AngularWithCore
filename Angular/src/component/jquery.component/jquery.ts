import { Component,OnInit } from "@angular/core";
import * as $ from 'jquery';

@Component({
    selector:'jquery-component',
    templateUrl:'jquery.html'
})

export class  JqueryComponent {
    constructor() {
        
    }
    ShowText(){
        console.log($('#textId').val());
    }
}