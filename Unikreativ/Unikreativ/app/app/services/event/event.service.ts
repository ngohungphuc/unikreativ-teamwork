import { AuthHttpServices } from '../index'
import { DataHandlerService, HttpClientService } from '../../extensions/index'
import { Headers, Http, RequestOptions, Response } from '@angular/http'
import { Injectable } from '@angular/core'

@Injectable()
export class EventService {

    constructor(
        private http: Http,
        private httpClientService: HttpClientService,
        private dataHandlerService: DataHandlerService,
        private authHttpService: AuthHttpServices) {
    }
    
    getAllEvents() {
        let url = 'Event/GetAllEvents'
        return this.authHttpService.authGet(url)
    }
}
