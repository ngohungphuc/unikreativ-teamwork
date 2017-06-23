import { Environment } from './../config/env'
import { Http } from '@angular/http'
import { Injectable } from '@angular/core'

@Injectable()
export class HttpClientService {
    urlPrefix: string
    constructor(private http: Http) {
        this.urlPrefix = Environment.API_URL
    }

    get(url, options?) {
        return this.http.get(this.urlPrefix + url, options)
    }

    post(url, data, options?) {
        return this.http.post(this.urlPrefix + url, data, options)
    }

    put(url, data, options?) {
        return this.http.put(this.urlPrefix + url, data, options)
    }

    delete(url, options?) {
        return this.http.delete(this.urlPrefix + url, options)
    }
}