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
var AuthHttpServices = (function () {
    function AuthHttpServices(http, httpClientService, dataHandlerService) {
        this.http = http;
        this.httpClientService = httpClientService;
        this.dataHandlerService = dataHandlerService;
        this.tokenKey = 'token';
        var currentUser = JSON.parse(sessionStorage.getItem('currentUser'));
        this.token = currentUser && currentUser.token;
    }
    AuthHttpServices.prototype.authGet = function (url) {
        var headers = this.initAuthHeaders();
        return this.httpClientService.get(url, { headers: headers })
            .toPromise()
            .then(function (res) { return res.json(); })
            .catch(this.dataHandlerService.handleError);
    };
    AuthHttpServices.prototype.authPost = function (url, body) {
        var headers = this.initAuthHeaders();
        var options = new http_1.RequestOptions({ headers: headers });
        return this.httpClientService.post(url, body, options)
            .toPromise()
            .then(function (response) { return response.json(); })
            .catch(this.dataHandlerService.handleError);
    };
    AuthHttpServices.prototype.authPut = function (url, body) {
        var headers = this.initAuthHeaders();
        return this.httpClientService.put(url, body, { headers: headers })
            .toPromise()
            .then(function (response) { return response.json(); })
            .catch(this.dataHandlerService.handleError);
    };
    AuthHttpServices.prototype.getLocalToken = function () {
        if (!this.token) {
            this.token = sessionStorage.getItem(this.tokenKey);
        }
        return this.token;
    };
    AuthHttpServices.prototype.initAuthHeaders = function () {
        var token = this.getLocalToken();
        if (token === null)
            throw 'No token';
        var headers = new http_1.Headers();
        headers.append('Authorization', 'Bearer ' + token);
        return headers;
    };
    return AuthHttpServices;
}());
AuthHttpServices = __decorate([
    core_1.Injectable(),
    __metadata("design:paramtypes", [http_1.Http,
        index_1.HttpClientService,
        index_1.DataHandlerService])
], AuthHttpServices);
exports.AuthHttpServices = AuthHttpServices;
//# sourceMappingURL=auth-http.service.js.map