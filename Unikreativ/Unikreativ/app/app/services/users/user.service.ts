import {AuthHttpServices} from '../index'
import {DataHandlerService, HttpClientService} from '../../extensions/index'
import {Headers, Http, RequestOptions, Response} from '@angular/http'
import {Injectable} from '@angular/core'

@Injectable()
export class UserService {

    constructor(private http : Http, private httpClientService : HttpClientService, private dataHandlerService : DataHandlerService, private authHttpService : AuthHttpServices) {
        // set token if save in local storage
        let currentUser = JSON.parse(localStorage.getItem('currentUser'));
    }

    getTeamMembers() {
        let url = 'Data/GetTeamMembers'
        let headers = new Headers({'Content-Type': 'application/json'})

        return this
            .httpClientService
            .get(url, {headers: headers})
            .map(res => res.json())
            .catch(this.dataHandlerService.handleError)
    }

    getClients() {
        let url = 'Data/GetClients'
        let headers = new Headers({'Content-Type': 'application/json'})

        return this
            .httpClientService
            .get(url, {headers: headers})
            .map(res => res.json())
            .catch(this.dataHandlerService.handleError)
    }

    newClient(client : any) {
        let url = 'Admin/NewClient'
        return this
            .authHttpService
            .authPost(url, client)
    }

    updateClient(client : any) {
        let url = 'Admin/UpdateClientInfo'
        return this
            .authHttpService
            .authPut(url, client)
    }

    updateMember(member : any) {
        let url = 'Admin/UpdateMemberInfo'
        return this
            .authHttpService
            .authPut(url, member)
    }

    deleteAccount(id : any) {
        let url = `Admin/DeleteAccount/${id}`
        return this
            .authHttpService
            .authDelete(url)
    }
}
