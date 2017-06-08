import { Observable } from 'rxjs/Observable'
import { Injectable } from '@angular/core'
import { Response } from '@angular/http'
@Injectable()
export class DataHandlerService {
    extractData(res: Response) {
        let body = res.json()
        return body.data || {}
    }

    handleError(error: Response | any) {
        console.error(error.message || error)
        return Promise.reject(error.message || error)
    }

}