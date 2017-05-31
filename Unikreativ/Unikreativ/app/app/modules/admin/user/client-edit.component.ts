import { Component, OnInit, Input } from '@angular/core'
import { UserService } from '../../../services/index'
import { Observable } from 'rxjs/Observable'

@Component({
    selector: 'client-edit',
    templateUrl: 'partial/clientedit',
    providers: [UserService]
})

export class ClientEditComponent implements OnInit {
    @Input()
    client: any[]

    constructor(private userService: UserService) {
    }

    ngOnInit() {
        console.log(this.client)
    }


}