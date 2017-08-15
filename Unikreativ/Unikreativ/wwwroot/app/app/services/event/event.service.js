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
const index_1 = require("../index");
const index_2 = require("../../extensions/index");
const http_1 = require("@angular/http");
const core_1 = require("@angular/core");
let EventService = class EventService {
    constructor(http, httpClientService, dataHandlerService, authHttpService) {
        this.http = http;
        this.httpClientService = httpClientService;
        this.dataHandlerService = dataHandlerService;
        this.authHttpService = authHttpService;
    }
    getAllEvents() {
        let url = 'Event/GetAllEvents';
        return this.authHttpService.authGet(url);
    }
};
EventService = __decorate([
    core_1.Injectable(),
    __metadata("design:paramtypes", [http_1.Http,
        index_2.HttpClientService,
        index_2.DataHandlerService,
        index_1.AuthHttpServices])
], EventService);
exports.EventService = EventService;
//# sourceMappingURL=event.service.js.map