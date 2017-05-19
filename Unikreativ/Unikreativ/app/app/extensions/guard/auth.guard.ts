import { Injectable } from '@angular/core'
import { CanActivate, Router } from '@angular/router'

@Injectable()
export class AuthGuard implements CanActivate {
    constructor(private router: Router) {

    }

    canActivate() {
        if (localStorage.getItem('currentUser')) {
            console.log(true)
            alert('true')
            return true
        }
        
        this.router.navigate(['/login'])
        return false

    }
}