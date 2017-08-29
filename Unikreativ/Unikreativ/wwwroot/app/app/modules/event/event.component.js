"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
Object.defineProperty(exports, "__esModule", { value: true });
const core_1 = require("@angular/core");
const index_1 = require("../../services/index");
const ProjectModel_1 = require("./../../model/ProjectModel");
const notification_service_1 = require("./../../extensions/notification.service");
let EventListComponent = class EventListComponent {
    constructor(pushService, eventServices) {
        this.pushService = pushService;
        this.eventServices = eventServices;
    }
    ngOnInit() {
        this.getEvent();
        this.pushService
            .observe(event => event instanceof ProjectModel_1.Project)
            .subscribe(val => this.populateEvent(val));
    }
    getEvent() {
        this.eventServices.getAllEvents().then(res => {
            this.eventList = res;
        });
    }
    populateEvent(eventData) {
        this.eventList = [...this.eventList, eventData];
    }
};
EventListComponent = __decorate([
    core_1.Component({
        selector: 'event-list',
        templateUrl: 'partial/eventlist'
    }),
    __metadata("design:paramtypes", [notification_service_1.PushService,
        index_1.EventService])
], EventListComponent);
exports.EventListComponent = EventListComponent;
//# sourceMappingURL=event.component.js.map