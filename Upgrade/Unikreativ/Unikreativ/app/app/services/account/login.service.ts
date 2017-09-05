import { AppStatusCode } from '../../extensions/app-status'
import { DataHandlerService, HttpClientService } from '../../extensions/index'
import {
    Headers,
    Http,
    RequestOptions,
    Response
} from '@angular/http'
import { Injectable } from '@angular/core'
import { Observable } from 'rxjs/Observable'
import { RequestResult } from '../../model/RequestResult'
import 'rxjs/add/operator/toPromise'


@Injectable()
export class LoginService {
    private tokenKey = 'token'
    private token: string
    constructor(private http: Http,
        private httpClientService: HttpClientService,
        private dataHandlerService: DataHandlerService) {
    }

    loginUser(username: string, password: string): Promise<RequestResult> {
        let headers = new Headers({ 'Content-Type': 'application/json' })
        let options = new RequestOptions({ headers: headers })
        let loginInfo = { Username: username, Password: password }

        return this.httpClientService.post('Auth/GetAuthToken', loginInfo, options)
            .toPromise()
            .then(response => {
                let result = response.json() as RequestResult
                if (result.State === AppStatusCode.LoginSuccess) {
                    let json = result.Data as any
                    this.token = json.accessToken
                    sessionStorage.setItem(
                        'currentUser',
                        JSON.stringify({ username: username, token: json.accessToken }))
                }

                return result
            })
            .catch(this.dataHandlerService.handleError)
    }

    checkLogin(): boolean {
        let token = sessionStorage.getItem(this.tokenKey)
        return token != null
    }

    logout() {
        this.token = null
        sessionStorage.removeItem('currentUser')
    }
}