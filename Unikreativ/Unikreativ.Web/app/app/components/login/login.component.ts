﻿import { Component, OnInit } from '@angular/core'
import { FormControl, FormGroup, Validators } from '@angular/forms'
import { LoginService } from '../../services/account/login.service'

@Component({
    selector: 'login',
    templateUrl: 'partial/login'
})
export class LoginComponent implements OnInit {
    loginForm: FormGroup
    username: FormControl
    password: FormControl
    constructor(private loginService:LoginService) {
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
        this.loginService.loginUser(formValues.username,formValues.password).subscribe(
            resp => {
                console.log(resp)
            }
        )
    }
}