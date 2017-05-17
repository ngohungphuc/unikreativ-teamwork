import { Component, OnInit, Inject } from '@angular/core'
import { Router } from '@angular/router'
import { FormControl, FormGroup, Validators } from '@angular/forms'
import { LoginService } from '../../services/account/login.service'
import { HttpClientService, Toastr_Token } from './../../extensions/index'


@Component({
    selector: 'login',
    templateUrl: 'partial/login',
    providers: [HttpClientService]
})
export class LoginComponent implements OnInit {
    loginForm: FormGroup
    username: FormControl
    password: FormControl
    constructor(private loginService: LoginService, private router: Router, @Inject(Toastr_Token) private toastr: any) {
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
                if (err.status === 400) {
                    this.toastr.error('Invalid credential')
                }
            })
    }
}