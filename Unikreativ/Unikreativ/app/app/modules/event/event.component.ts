import { Project } from './../../model/ProjectModel'
import { PushService } from './../../extensions/notification.service'
import { Component, OnInit } from '@angular/core'
@Component({
    selector: 'event-list',
    templateUrl: 'partial/eventlist'
})

export class EventListComponent implements OnInit {

    constructor(private pushService:PushService) { }

    ngOnInit() { 
        this.pushService
            .observe(event=>event instanceof Project)
            .subscribe((val=> this.getEvent()))
    }

    getEvent(){

    }
}