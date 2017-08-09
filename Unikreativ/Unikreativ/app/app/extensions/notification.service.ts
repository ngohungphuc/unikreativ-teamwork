import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { Subject } from 'rxjs/Subject';

@Injectable()
export class PushService {
  private subject = new Subject<any>()

  sendMessage(message: string) {
    this.subject.next({ text: message })
  }

  clearMessage() {
    this.subject.next()
  }

  getMessage(): Observable<any> {
    return this.subject.asObservable()
  }

  observe(filter: (any) => boolean) {
    return this.subject.filter(filter)
  }

  notify(data: any) {
    this.subject.next(data)
  }
}
