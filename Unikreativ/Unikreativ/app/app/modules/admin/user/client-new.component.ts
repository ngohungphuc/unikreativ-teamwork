import {
    Component,
    Inject,
    Input,
    OnInit
} from '@angular/core'
import { FormControl, FormGroup, Validators } from '@angular/forms'
import { Toastr, Toastr_Token } from '../../../extensions/index'
import { UserService } from '../../../services/index'
@Component({
    selector: 'client-new',
    templateUrl: 'partial/clientnew',
    providers: [
        UserService
    ]
})

export class NewClientComponent implements OnInit {
    @Input()
    client: any[]

    newClientForm: FormGroup
    CompanyName: FormControl
    Country: FormControl
    Address: FormControl
    Email: FormControl
    PhoneNumber: FormControl
    Website: FormControl
    Industry: FormControl
    UserName: FormControl
    PasswordHash: FormControl

    constructor(
        private userService: UserService,
        @Inject(Toastr_Token) private toastr: Toastr) {
    }

    ngOnInit() {
        this.CompanyName = new FormControl('', Validators.required)
        this.Country = new FormControl('', Validators.required)
        this.Address = new FormControl('', Validators.required)
        this.Email = new FormControl('', Validators.required)
        this.PhoneNumber = new FormControl('', Validators.required)
        this.Website = new FormControl('', Validators.required)
        this.Industry = new FormControl('', Validators.required)
        this.UserName = new FormControl('', Validators.required)
        this.PasswordHash = new FormControl('', Validators.required)


        this.newClientForm = new FormGroup({
            CompanyName: this.CompanyName,
            Country: this.Country,
            Address: this.Address,
            Email: this.Email,
            PhoneNumber: this.PhoneNumber,
            Website: this.Website,
            Industry: this.Industry,
            UserName: this.UserName,
            PasswordHash: this.PasswordHash
        })

    }

    async newClient(value: any) {
        console.log(value)
        await this.userService.newClient(value).then(
            res => {
                if (res.result) {
                    this.toastr.success(res.msg, 'Success')
                }
                else this.toastr.error(res.msg, 'Error')
            })
    }

}