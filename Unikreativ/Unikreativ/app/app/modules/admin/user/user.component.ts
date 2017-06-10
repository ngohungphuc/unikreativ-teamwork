import { Component, Inject, OnInit } from '@angular/core'
import { FormControl, FormGroup, Validators } from '@angular/forms'
import { Observable } from 'rxjs/Observable'
import { Toastr, Toastr_Token } from '../../../extensions/index'
import { UserService } from '../../../services/index'
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
    constructor(private userService: UserService,
        @Inject(Toastr_Token) private toastr: Toastr) {
    }

    ngOnInit() {

        let teamMembersAPI = this.userService.getTeamMembers()
        let clientsAPI = this.userService.getClients()

        Observable.forkJoin([teamMembersAPI, clientsAPI]).subscribe(result => {
            this.teamMembers = result[0]
            this.clients = result[1]
        })
    }

    selectClient(client: any[]) {
        this.client = client
    }

    async deleteClient(clientId: any) {
        if (confirm('Are you sure to delete')) {
            await this.userService.deleteClient(clientId).then(
                res => {
                    if (res.result) {
                        this.toastr.success(res.msg, 'Success')
                    }
                    else this.toastr.error(res.msg, 'Error')
                }
            )
        }

    }
}