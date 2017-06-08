import { FormGroup, FormControl, Validators } from '@angular/forms'
import { Component, OnInit, Input } from '@angular/core'
import { UserService } from '../../../services/index'
import { Observable } from 'rxjs/Observable'

@Component({
    selector: 'client-new',
    templateUrl: 'partial/clientnew',
    providers: [
        UserService
    ]
})

export class NewClientComponent implements OnInit {
    newClientForm: FormGroup
    CompanyName: FormControl
    Country: FormControl
    Address: FormControl
    Email: FormControl
    Phone: FormControl
    Website: FormControl
    Industry: FormControl
    UserName: FormControl
    PasswordHash: FormControl
    constructor(
        private userService: UserService) {
    }

    ngOnInit() {
        this.CompanyName = new FormControl('', Validators.required)
        this.Country = new FormControl('', Validators.required)
        this.Address = new FormControl('', Validators.required)
        this.Email = new FormControl('', Validators.required)
        this.Phone = new FormControl('', Validators.required)
        this.Website = new FormControl('', Validators.required)
        this.Industry = new FormControl('', Validators.required)
        this.UserName = new FormControl('', Validators.required)
        this.PasswordHash = new FormControl('', Validators.required)


        this.newClientForm = new FormGroup({
            CompanyName: this.CompanyName,
            Country: this.Country,
            Address: this.Address,
            Email: this.Email,
            Phone: this.Phone,
            Website: this.Website,
            Industry: this.Industry,
            UserName: this.UserName,
            PasswordHash: this.PasswordHash
        })

    }

    newClient(value: any) {
        console.log(value)
        this.userService.newClient(value).then(
            data => {
                console.log(data)
            },
            error => {
                console.log(error)
            })
    }

}