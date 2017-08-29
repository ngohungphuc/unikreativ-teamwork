import { Component, OnInit } from '@angular/core'
import { EventService } from '../../services/index'
import { Project } from './../../model/ProjectModel'
import { PushService } from './../../extensions/notification.service'

@Component({
  selector: 'event-list',
  templateUrl: 'partial/eventlist'
})

export class EventListComponent implements OnInit {
  eventList: any

  constructor(
        private pushService: PushService,
        private eventServices: EventService) {}

  ngOnInit() {
    this.getEvent()

    this.pushService
      .observe(event => event instanceof Project)
      .subscribe(val => this.populateEvent(val))
  }

  getEvent() {
      this.eventServices.getAllEvents().then( res=> {
        this.eventList = res
      })
  }

  populateEvent(eventData) {
    this.eventList = [...this.eventList, eventData]
  }

}
