import { Injectable } from '@angular/core'
import { Observable } from 'rxjs/Observable'
import { Http, Response, Headers, RequestOptions } from '@angular/http'
import { HttpClientService, DataHandlerService } from '../../extensions/index'
import { RequestResult } from '../../model/RequestResult'
import 'rxjs/add/operator/map'
import 'rxjs/add/operator/toPromise'

@Injectable()
export class LoginService {
    private tokenKey = 'token'
    private token: string
    constructor(private http: Http,
        private httpClientService: HttpClientService,
        private dataHandlerService: DataHandlerService) {
        // set token if save in local storage
        let currentUser = JSON.parse(localStorage.getItem('currentUser'))
        this.token = currentUser && currentUser.token
    }

    loginUser(username: string, password: string): Promise<RequestResult> {
        let headers = new Headers({ 'Content-Type': 'application/json' })
        let options = new RequestOptions({ headers: headers })
        let loginInfo = { Username: username, Password: password }

        return this.httpClientService.post('TokenAuth/GetAuthToken', loginInfo, options)
            .toPromise()
            .then(response => {
                let result = response.json() as RequestResult
                if (result.State === 1) {
                    let json = result.Data as any
                    this.token = json.accessToken
                    localStorage.setItem('currentUser', JSON.stringify({ username: username, token: json.accessToken }))
                }

                return result
            })
            .catch(this.dataHandlerService.handleError)
    }

    checkLogin(): boolean {
        let token = localStorage.getItem(this.tokenKey)
        return token != null
    }

    logout() {
        this.token = null
        localStorage.removeItem('currentUser')
    }
}