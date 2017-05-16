import { Injectable } from '@angular/core'
import { Observable } from 'rxjs/Observable'
import { Http, Response, Headers, RequestOptions } from '@angular/http'
import { HttpClientService } from '../../extensions/http-extensions'
import { DataHandlerService } from '../../extensions/services-handler'
import 'rxjs/add/operator/map'

@Injectable()
export class LoginService {
    constructor(private http: Http,
        private httpClientService: HttpClientService,
        private dataHandlerService: DataHandlerService) { }

    loginUser(username: string, password: string) {
        let headers = new Headers({ 'Content-Type': 'application/json' })
        let options = new RequestOptions({ headers: headers })
        let loginInfo = { Username: username, Password: password }

        return this.httpClientService.post('Account/Login', loginInfo, options)
            .map(res => res.status)
            .catch(this.dataHandlerService.handleError)
    }

    logout() {
        localStorage.removeItem('currentUser')
    }
}