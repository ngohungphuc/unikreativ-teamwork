import { DataHandlerService, HttpClientService } from '../../extensions/index'
import {
    Headers,
    Http,
    RequestOptions,
    Response
} from '@angular/http'
import { Injectable } from '@angular/core'
import { RequestResult } from '../../model/RequestResult'

@Injectable()
export class AuthHttpServices {
    private tokenKey = 'token'
    private token: string
    constructor(private http: Http,
        private httpClientService: HttpClientService,
        private dataHandlerService: DataHandlerService) {

        // set token if save in local storage
        let currentUser = JSON.parse(sessionStorage.getItem('currentUser'))
        this.token = currentUser && currentUser.token
    }

    authGet(url): Promise<RequestResult> {
        let headers = this.initAuthHeaders()

        return this.httpClientService.get(url, { headers: headers })
            .toPromise()
            .then(res => res.json() as RequestResult)
            .catch(this.dataHandlerService.handleError)
    }

    authPost(url: string, body: any): Promise<any> {
        let headers = this.initAuthHeaders()

        return this.httpClientService.post(url, body, { headers: headers })
            .toPromise()
            .then(response => response.json() as any)
            .catch(this.dataHandlerService.handleError)
    }

    authPut(url: string, body: any): Promise<any> {
        let headers = this.initAuthHeaders()

        return this.httpClientService.put(url, body, { headers: headers })
            .toPromise()
            .then(response => response.json() as any)
            .catch(this.dataHandlerService.handleError)
    }

    authDelete(url: string): Promise<any> {
        let headers = this.initAuthHeaders()

        return this.httpClientService.delete(url, { headers: headers })
            .toPromise()
            .then(response => response.json() as any)
            .catch(this.dataHandlerService.handleError)
    }

    private getLocalToken(): string {
        if (!this.token) {
            this.token = sessionStorage.getItem(this.tokenKey)
        }
        return this.token
    }

    private initAuthHeaders(): Headers {
        let token = this.getLocalToken()
        if (token === null) throw 'No token'

        let headers = new Headers()
        headers.append('Authorization', 'Bearer ' + token)

        return headers
    }
}