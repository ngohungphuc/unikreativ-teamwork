import { AuthHttpServices } from '../index'
import { DataHandlerService, HttpClientService } from '../../extensions/index'
import { Headers, Http, RequestOptions, Response } from '@angular/http'
import { Injectable } from '@angular/core'

@Injectable()
export class ProjectService {

    constructor(
        private http: Http,
        private httpClientService: HttpClientService,
        private dataHandlerService: DataHandlerService,
        private authHttpService: AuthHttpServices) {
    }

    getProjectList() {
        let url = 'Project/GetProjectList'
        return this.authHttpService.authGet(url)
    }

    getProjectByName(name){
        let url = `Project/GetProjectByName?ProjectName=${name}`;
        return this.authHttpService.authGet(url)
    }

    newProject(client: any) {
        let url = 'Project/NewProject'
        return this.authHttpService.authPost(url, client)
    }


}
