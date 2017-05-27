import { Injectable } from '@angular/core'
import { Observable } from 'rxjs/Observable'
import { Http, Response, Headers, RequestOptions } from '@angular/http'
import { HttpClientService, DataHandlerService } from '../../extensions/index'
import 'rxjs/add/operator/map'
import 'rxjs/add/operator/toPromise'

@Injectable()
export class UserService {

    constructor(private http: Http,
        private httpClientService: HttpClientService,
        private dataHandlerService: DataHandlerService) {
        // set token if save in local storage
        let currentUser = JSON.parse(localStorage.getItem('currentUser'))
    }
    getTeamMembers() {
        let url = '/Admin/GetTeamMembers'
        let headers = new Headers({ 'Content-Type': 'application/json' })

        return this.httpClientService.get(url, { headers: headers }).toPromise()
            .then(res => res.json())
            .catch(this.dataHandlerService.handleError)
    }
}