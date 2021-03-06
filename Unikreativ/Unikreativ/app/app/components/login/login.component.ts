﻿import { AppStatusCode } from '../../extensions/app-status'
import { Component, Inject, OnInit } from '@angular/core'
import { FormControl, FormGroup, Validators } from '@angular/forms'
import { HttpClientService, Toastr, Toastr_Token } from './../../extensions/index'
import { LoginService } from '../../services/account/login.service'
import { Router } from '@angular/router'

@Component({ selector: 'login', templateUrl: 'partial/login', providers: [HttpClientService] })
export class LoginComponent implements OnInit {
    loginForm: FormGroup
    username: FormControl
    password: FormControl

    constructor(private loginService: LoginService, private router: Router, @Inject(Toastr_Token) private toastr: Toastr) {
        if (sessionStorage.getItem('currentUser') !== null)
            this.router.navigate(['admin'])
    }

    ngOnInit() {
        this.username = new FormControl('', Validators.required)
        this.password = new FormControl('', Validators.required)
        this.loginForm = new FormGroup({ username: this.username, password: this.password })
    }

    async login(formValues) {
        await this
            .loginService
            .loginUser(formValues.username, formValues.password)
            .then(resp => {
                if (resp.State === AppStatusCode.LoginSuccess) {
                    this.router.navigate(['admin'])
                } else {
                    this.toastr.error(resp.Msg, 'Error')
                }
            })
    }
}