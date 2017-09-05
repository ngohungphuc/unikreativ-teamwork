import { Component, OnInit } from '@angular/core'
@Component({
    selector: 'uni-sidebar',
    templateUrl: 'partial/sidebar'
})
export class SidebarComponent implements OnInit {
    user: string

    ngOnInit() {
        let data = JSON.parse(sessionStorage.getItem('currentUser'))
        this.user = data['username']
    }
}