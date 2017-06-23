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

@Component({selector: 'new-member', templateUrl: 'partial/newmember', providers: [UserService]})

export class NewMemberComponent implements OnInit {
    ngOnInit() {}
}