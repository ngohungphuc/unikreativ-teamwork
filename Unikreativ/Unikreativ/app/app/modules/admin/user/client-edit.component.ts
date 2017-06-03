import { FormGroup, FormControl, Validators } from '@angular/forms'
import { Component, OnInit, Input } from '@angular/core'
import { UserService, LoginService } from '../../../services/index'
import { Observable } from 'rxjs/Observable'

@Component({
    selector: 'client-edit',
    templateUrl: 'partial/clientedit',
    providers: [
        UserService,
        LoginService
    ]
})

export class ClientEditComponent implements OnInit {
    @Input()
    client: any[]

    editClientInfoForm: FormGroup
    companyName: FormControl
    country: FormControl
    address: FormControl
    email: FormControl
    phoneNumber: FormControl
    website: FormControl

    constructor(
        private userService: UserService,
        private loginService: LoginService) {
    }

    ngOnInit() {
        this.companyName = new FormControl('', Validators.required)
        this.country = new FormControl('', Validators.required)
        this.address = new FormControl('', Validators.required)
        this.email = new FormControl('', Validators.required)
        this.phoneNumber = new FormControl('', Validators.required)
        this.website = new FormControl('', Validators.required)


        this.editClientInfoForm = new FormGroup({
            companyName: this.companyName,
            country: this.country,
            address: this.address,
            email: this.email,
            phoneNumber: this.phoneNumber,
            website: this.website
        })

    }

    editClientInfo(value: any) {
        console.log(value)
        this.userService.updateClient(value).then(
            resp => {
                console.log(resp)
            })
    }

}