import { Http, RequestOptions, RequestOptionsArgs,Headers } from '@angular/http';
import{ Observable} from 'rxjs/Observable';
import{ Injectable } from '@angular/core';

@Injectable()
export class HomeService{
    constructor(private http:Http){}

    get():Observable<string>{
        return this.http.get('http://localhost:7265/home/GetData',{withCredentials:true}).map(result=>{
            return result.text();
        });
    }
    save():Observable<string>{
        let options:RequestOptionsArgs={
            //headers:myHeader,
            body:'test',
            withCredentials:true
        };
        var formData=new FormData();
        formData.append("value","test");
        return this.http.post('http://localhost:7265/home/Save',formData,{withCredentials:true}).map(
            result=>{
            return result.text();
        });
    }
}