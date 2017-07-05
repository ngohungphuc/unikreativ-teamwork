import {
    Component,
    ElementRef,
    Inject,
    Input,
    OnInit,
    ViewChild
    } from '@angular/core'
import { FormControl, FormGroup, Validators } from '@angular/forms'
import { Toastr, Toastr_Token } from '../../../extensions/toastr'
import { UserService } from '../../../services/index'

@Component({ selector: 'edit-client', templateUrl: 'partial/clientedit', providers: [UserService] })

export class ClientEditComponent implements OnInit {
    @Input() client: any[]

    @ViewChild('clientId') clientId: ElementRef

    editClientInfoForm: FormGroup
    CompanyName: FormControl
    Country: FormControl
    Address: FormControl
    Email: FormControl
    PhoneNumber: FormControl
    Website: FormControl
    Industry: FormControl
    constructor(
        private userService: UserService, 
        @Inject(Toastr_Token) private toastr: Toastr) { }

    ngOnInit() {
        this.CompanyName = new FormControl('', Validators.required)
        this.Country = new FormControl('', Validators.required)
        this.Address = new FormControl('', Validators.required)
        this.Email = new FormControl('', Validators.required)
        this.PhoneNumber = new FormControl('', Validators.required)
        this.Website = new FormControl('', Validators.required)
        this.Industry = new FormControl('', Validators.required)

        this.editClientInfoForm = new FormGroup({
            CompanyName: this.CompanyName,
            Country: this.Country,
            Address: this.Address,
            Email: this.Email,
            PhoneNumber: this.PhoneNumber,
            Website: this.Website,
            Industry: this.Industry
        })

    }

    async editClientInfo(value: any) {
        let client = {
            Id: this.clientId.nativeElement.value,
            CompanyName: value.CompanyName,
            Country: value.Country,
            Address: value.Address,
            Email: value.Email,
            PhoneNumber: value.PhoneNumber,
            Website: value.Website,
            Industry: value.Industry
        }

        await this
            .userService
            .updateClient(client)
            .then(result => this.toastr.success(result.msg, 'Success'))
            .catch(error => this.toastr.error(error.msg, 'Error'))
    }
}
