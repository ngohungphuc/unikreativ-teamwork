import { Component, Inject, OnInit } from '@angular/core'
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
    member: any[]
    constructor(private userService: UserService,
        @Inject(Toastr_Token) private toastr: Toastr) {
    }

    ngOnInit() {

        let teamMembersAPI = this.userService.getTeamMembers()
        let clientsAPI = this.userService.getClients()

        Observable.forkJoin([teamMembersAPI, clientsAPI]).subscribe(result => {
            this.teamMembers = result[0]
            this.clients = result[1]
            console.log(result[0])
        })
    }

    selectClient(client: any[]) {
        this.client = client
    }

    selectMember(member: any[]) {
        this.member = member
    }

    async deleteClient(clientId: any) {
        if (confirm('Are you sure to delete')) {
            for (let i = 0; i < this.clients.length; i++) {
                let clientToRemove = this.clients[i]
                if (clientToRemove.Id === clientId) {
                    this.clients.splice(i, 1)
                    await this.userService.deleteAccount(clientId).then(
                        res => {
                            if (res.result) {
                                this.toastr.success(res.msg, 'Success')
                            }
                            else this.toastr.error(res.msg, 'Error')
                        }
                    )
                    break
                }
            }

        }

    }

    // when create new client,it will push new client to table
    newClientCreated(newClient) {
        this.clients.push(newClient)
    }
}
