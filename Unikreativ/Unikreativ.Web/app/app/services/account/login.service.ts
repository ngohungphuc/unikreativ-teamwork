import { Injectable } from '@angular/core'
import { Observable } from 'rxjs/Observable'
import { Http, Response, Headers, RequestOptions } from '@angular/http'

@Injectable()
export class LoginService {
    constructor(private http: Http) { }

    loginUser(username: string, password: string) {
        let headers = new Headers({ 'Content-Type': 'application/json' })
        let options = new RequestOptions({ headers: headers })
        let loginInfo = { Username: username, Password: password }

        //return this.http.post('http://localhost:53746/api/Account/Login', JSON.stringify(loginInfo), options)
        //    .map((res: Response) => res.json())
        //    .catch((error: any) => Observable.throw(error.json().error || 'Server error'))
        return this.http.get('http://localhost:53746/api/Account/GetSomething').map((res: Response) => res.json())
    }

    logout() {
        let headers = new Headers({ 'Content-Type': 'application/json' })
        let options = new RequestOptions({ headers: headers })

        return this.http.post('/Account/logout', JSON.stringify({}), options)
    }
}