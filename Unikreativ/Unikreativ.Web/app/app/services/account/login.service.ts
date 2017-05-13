import { Injectable } from '@angular/core'
import { Observable } from 'rxjs/Observable'
import { Http, Response, Headers, RequestOptions } from '@angular/http'

@Injectable()
export class LoginService {
    constructor(private http: Http) {}

    loginUser(username:string, password:string) {
        let headers = new Headers({'Content-Type':'application/json'})
        let options = new RequestOptions({headers:headers})
        let loginInfo = {Username:username,Password:password}

        return this.http.post('/Account/Login',JSON.stringify(loginInfo),options)
        .do(resp => {
            console.log(resp)
        }).catch(error => {
            return Observable.of(false)
        })
    }

    logout() {
        let headers = new Headers({ 'Content-Type': 'application/json'})
        let options = new RequestOptions({headers: headers})
        
        return this.http.post('/Account/logout', JSON.stringify({}), options)
  }
}