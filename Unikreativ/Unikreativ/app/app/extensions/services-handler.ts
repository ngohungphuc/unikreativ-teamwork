import { Observable } from 'rxjs/Observable'
import { Injectable } from '@angular/core'
import { Response } from '@angular/http'
@Injectable()
export class DataHandlerService {
    extractData(res: Response) {
        let body = res.json()
        return body.data || {}
    }

    handleError(error: any): Promise<any> {
        console.error('An error occurred', error)
        return Promise.reject(error.message || error)
    }
}