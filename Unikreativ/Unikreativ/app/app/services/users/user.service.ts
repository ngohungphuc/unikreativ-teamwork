import { Injectable } from '@angular/core'
import { Http, Response, Headers, RequestOptions } from '@angular/http'
import { HttpClientService, DataHandlerService } from '../../extensions/index'
import { AuthHttpServices } from '../index'

@Injectable()
export class UserService {

    constructor(private http: Http,
        private httpClientService: HttpClientService,
        private dataHandlerService: DataHandlerService,
        private authHttpService: AuthHttpServices) {
        // set token if save in local storage
        let currentUser = JSON.parse(localStorage.getItem('currentUser'))
    }

    getTeamMembers() {
        let url = 'Data/GetTeamMembers'
        let headers = new Headers({ 'Content-Type': 'application/json' })

        return this.httpClientService.get(url, { headers: headers })
            .map(res => res.json())
            .catch(this.dataHandlerService.handleError)
    }

    getClients() {
        let url = 'Data/GetClients'
        let headers = new Headers({ 'Content-Type': 'application/json' })

        return this.httpClientService.get(url, { headers: headers })
            .map(res => res.json())
            .catch(this.dataHandlerService.handleError)
    }

    newClient(client: any) {
        let url = 'Admin/NewClient'
        return this.authHttpService.authPost(url, client)
    }

    updateClient(client: any) {
        let url = 'Admin/UpdateClientInfo'
        return this.authHttpService.authPut(url, client)
    }
}