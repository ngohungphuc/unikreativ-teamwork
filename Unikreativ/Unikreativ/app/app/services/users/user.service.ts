import { Injectable } from '@angular/core'
import { Http, Response, Headers, RequestOptions } from '@angular/http'
import { HttpClientService, DataHandlerService } from '../../extensions/index'
import { LoginService } from '../index'

@Injectable()
export class UserService {

    constructor(private http: Http,
        private httpClientService: HttpClientService,
        private dataHandlerService: DataHandlerService,
        private loginService: LoginService) {
        // set token if save in local storage
        let currentUser = JSON.parse(localStorage.getItem('currentUser'))
    }

    getTeamMembers() {
        let url = '/Data/GetTeamMembers'
        let headers = new Headers({ 'Content-Type': 'application/json' })

        return this.httpClientService.get(url, { headers: headers })
            .map(res => res.json())
            .catch(this.dataHandlerService.handleError)
    }

    getClients() {
        let url = '/Data/GetClients'
        let headers = new Headers({ 'Content-Type': 'application/json' })

        return this.httpClientService.get(url, { headers: headers })
            .map(res => res.json())
            .catch(this.dataHandlerService.handleError)
    }

    updateClient(client: any) {
        let url = '/Data/GetClients'
        let headers = new Headers({ 'Content-Type': 'application/json' })

        return this.loginService.authPut(url, { headers: headers })
    }
}