import { Component, OnInit } from '@angular/core'
import { UserService } from '../../../services/index'

@Component({
    selector: 'user',
    templateUrl: 'partial/usermanage',
    providers: [UserService]
})

export class UserComponent implements OnInit {
    constructor(private userService: UserService) {

    }
    ngOnInit() {
        let teamMember = this.userService.getTeamMembers()
    }
}