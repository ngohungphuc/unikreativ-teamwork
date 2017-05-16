import { HttpClientService } from './../../extensions/http-extensions'
import { Component, OnInit } from '@angular/core'
import { FormControl, FormGroup, Validators } from '@angular/forms'
import { LoginService } from '../../services/account/login.service'
import { Router } from '@angular/router'
@Component({
    selector: 'login',
    templateUrl: 'partial/login',
    providers: [HttpClientService]
})
export class LoginComponent implements OnInit {
    loginForm: FormGroup
    username: FormControl
    password: FormControl
    constructor(private loginService: LoginService, private router: Router) {
    }

    ngOnInit() {
        this.username = new FormControl('', Validators.required)
        this.password = new FormControl('', Validators.required)

        this.loginForm = new FormGroup({
            username: this.username,
            password: this.password
        })
    }

    login(formValues) {
        this.loginService.loginUser(formValues.username, formValues.password).subscribe(
            resp => {
                if (resp === 200) {
                    this.router.navigate(['dashboard'])
                }
            },
            err => {
                if (err === 400) {
                    // toastr.error('Invalid credential', 'Error')
                    alert('Invalid credentials')
                }
            })
    }
}