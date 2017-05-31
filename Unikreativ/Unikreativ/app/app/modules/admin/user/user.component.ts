import { FormGroup, FormControl, Validators } from '@angular/forms'
import { Component, OnInit } from '@angular/core'
import { UserService } from '../../../services/index'
import { Observable } from 'rxjs/Observable'

@Component({
    selector: 'user',
    templateUrl: 'partial/usermanage',
    providers: [UserService]
})

export class UserComponent implements OnInit {
    teamMembers: any[]
    clients: any[]
    

    // dual binding data
    client: any[]
    constructor(private userService: UserService) {
    }

    ngOnInit() {
       
        let teamMembersAPI = this.userService.getTeamMembers()
        let clientsAPI = this.userService.getClients()

        Observable.forkJoin([teamMembersAPI, clientsAPI]).subscribe(result => {
            this.teamMembers = result[0]
            this.clients = result[1]
            console.log(this.clients)
        })
    }

    selectClient(client: any[]) {
        this.client = client
    }
}