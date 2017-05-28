import { Component, OnInit } from '@angular/core'
import { UserService } from '../../../services/index'
import { Observable } from 'rxjs/Observable'
import 'rxjs/add/observable/forkJoin'

@Component({
    selector: 'user',
    templateUrl: 'partial/usermanage',
    providers: [UserService]
})

export class UserComponent implements OnInit {
    teamMembers: any[]
    clients: any[]
    constructor(private userService: UserService) {

    }
    ngOnInit() {
        let teamMembersAPI = this.userService.getTeamMembers()
        let clientsAPI = this.userService.getClients()

        Observable.forkJoin([teamMembersAPI, clientsAPI]).subscribe(result => {
            console.log(result[0])
            console.log(result[1])
        })
    }
}