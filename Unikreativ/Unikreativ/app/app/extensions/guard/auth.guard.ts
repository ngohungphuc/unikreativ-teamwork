import { Injectable } from '@angular/core'
import { CanActivate, Router } from '@angular/router'
import { Observable } from 'rxjs/Observable'
@Injectable()
export class AuthGuard implements CanActivate {
    constructor(private router: Router) {

    }

    canActivate(): Observable<boolean> | boolean {
        console.log('called')
        console.log(localStorage.getItem('currentUser'))

        if (localStorage.getItem('currentUser') !== null) {
            alert('true')
            return true
        }

        if (localStorage.getItem('currentUser') === null) {
            alert('false')
            this.router.navigate(['login'])
            return false
        }
    }
}