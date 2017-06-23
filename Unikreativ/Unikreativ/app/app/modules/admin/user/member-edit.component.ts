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
import { ViewChild, ElementRef } from '@angular/core'

@Component({
    selector: 'edit-member',
    templateUrl: 'partial/editmember',
    providers: [UserService]
})

export class EditMemberComponent implements OnInit {
    @Input() member: any[]
    @ViewChild('memberId') memberId: ElementRef

    editMemberInfoForm: FormGroup
    CompanyName: FormControl
    Email: FormControl
    Phone: FormControl
    JobTitle: FormControl
    Role: FormControl

    constructor(
        private userService: UserService,
        @Inject(Toastr_Token)private toastr: Toastr) {}

    ngOnInit() {
        this.CompanyName = new FormControl('', Validators.required)
        this.Phone = new FormControl('', Validators.required)
        this.Email = new FormControl('', Validators.required)
        this.JobTitle = new FormControl('', Validators.required)
        this.Role = new FormControl('', Validators.required)

        this.editMemberInfoForm = new FormGroup({
            CompanyName: this.CompanyName,
            Phone: this.Phone,
            Email: this.Email,
            JobTitle: this.JobTitle,
            Role: this.Role})
    }

    async editMemberInfo(value: any) {
         let member = {
            Id: this.memberId.nativeElement.value,
            CompanyName: value.CompanyName,
            Email: value.Email,
            Phone: value.Phone,
            JobTitle: value.JobTitle,
            Role: value.Role
        }

        await this.userService.updateMember(member)
            .then(result => this.toastr.success(result.msg, 'Success'))
            .catch(error => this.toastr.error(error.msg, 'Error'))
    }
}