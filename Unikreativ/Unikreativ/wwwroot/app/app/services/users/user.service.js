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
var core_1 = require("@angular/core");
var http_1 = require("@angular/http");
var index_1 = require("../../extensions/index");
require("rxjs/add/operator/map");
require("rxjs/add/operator/toPromise");
var UserService = (function () {
    function UserService(http, httpClientService, dataHandlerService) {
        this.http = http;
        this.httpClientService = httpClientService;
        this.dataHandlerService = dataHandlerService;
        var currentUser = JSON.parse(localStorage.getItem('currentUser'));
    }
    UserService.prototype.getTeamMembers = function () {
        var url = '/Admin/GetTeamMembers';
        var headers = new http_1.Headers({ 'Content-Type': 'application/json' });
        return this.httpClientService.get(url, { headers: headers }).toPromise()
            .then(function (res) { return res.json(); })
            .catch(this.dataHandlerService.handleError);
    };
    return UserService;
}());
UserService = __decorate([
    core_1.Injectable(),
    __metadata("design:paramtypes", [http_1.Http,
        index_1.HttpClientService,
        index_1.DataHandlerService])
], UserService);
exports.UserService = UserService;
//# sourceMappingURL=user.service.js.map