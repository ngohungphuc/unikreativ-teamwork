import { Injectable } from '@angular/core'
import { Observable } from 'rxjs/Observable'
import { Http, Response, Headers, RequestOptions } from '@angular/http'
import { HttpClientService } from '../../extensions/http-extensions'
import 'rxjs/add/operator/map'

@Injectable()
export class LoginService {
    constructor(private http: Http, private httpClientService: HttpClientService) { }

    loginUser(username: string, password: string) {
        let headers = new Headers({ 'Content-Type': 'application/json' })
        let options = new RequestOptions({ headers: headers })
        let loginInfo = { Username: username, Password: password }

        return this.httpClientService.post('Account/Login', loginInfo, options)
            .map((res: Response) => {
                let user = res.json()
                if (user) {
                    localStorage.setItem('currentUser', JSON.stringify(user));
                }
            })
    }

    logout() {
        localStorage.removeItem('currentUser');
    }
}