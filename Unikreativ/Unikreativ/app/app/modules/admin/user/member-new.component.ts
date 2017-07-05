import {
    Component,
    EventEmitter,
    Inject,
    Input,
    OnInit,
    Output
} from '@angular/core'
import { FormControl, FormGroup, Validators } from '@angular/forms'
import { Toastr, Toastr_Token } from '../../../extensions/index'
import { UserService } from '../../../services/index'

@Component({
    selector: 'new-member',
    templateUrl: 'partial/newmember',
    providers: [UserService]
})

export class NewMemberComponent implements OnInit {
    @Output() newMemberCreated = new EventEmitter()
    newMemberForm: FormGroup
    CompanyName: FormControl
    Email: FormControl
    PhoneNumber: FormControl
    UserName: FormControl
    JobTitle: FormControl
    Role: FormControl
    NormalizedUserName: FormControl
    ChargeRate: FormControl
    constructor(
        private userService: UserService,
        @Inject(Toastr_Token) private toastr: Toastr) { }

    ngOnInit() {
        this.CompanyName = new FormControl('')
        this.JobTitle = new FormControl('', Validators.required)
        this.Email = new FormControl('', Validators.required)
        this.PhoneNumber = new FormControl('')
        this.UserName = new FormControl('', Validators.required)
        this.ChargeRate = new FormControl('', Validators.required)
        this.NormalizedUserName = new FormControl('', Validators.required)
        this.Role = new FormControl('', Validators.required)

        this.newMemberForm = new FormGroup({
            CompanyName: this.CompanyName,
            JobTitle: this.JobTitle,
            ChargeRate: this.ChargeRate,
            Email: this.Email,
            PhoneNumber: this.PhoneNumber,
            NormalizedUserName: this.NormalizedUserName,
            Role: this.Role,
            UserName: this.UserName
        })
    }

    async newMember(value: any) {
        let newMember = {
            CompanyName: value.CompanyName,
            Email: value.Email,
            PhoneNumber: value.PhoneNumber,
            UserName: value.UserName,
            JobTitle: value.JobTitle,
            ChargeRate: value.ChargeRate,
            NormalizedUserName: value.NormalizedUserName,
            Role: value.Role
        }

        await this
            .userService
            .newMember(newMember)
            .then(res => {
                if (res.result) {
                    this.toastr.success(res.msg, 'Success')
                    this.newMemberCreated.emit(newMember)
                } else
                    this.toastr.error(res.msg, 'Error')
            })
    }
}