import { FormGroup, FormControl, Validators } from '@angular/forms'
import { Component, OnInit, Input } from '@angular/core'
import { UserService } from '../../../services/index'


@Component({
    selector: 'client-edit',
    templateUrl: 'partial/clientedit',
    providers: [
        UserService
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
        private userService: UserService
    ) {
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

    async editClientInfo(value: any) {
        await this.userService.updateClient(value)
            .then(result => console.log(result))
            .catch(error => console.log(error))
    }

}