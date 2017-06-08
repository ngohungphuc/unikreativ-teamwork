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
var LoginService = (function () {
    function LoginService(http, httpClientService, dataHandlerService) {
        this.http = http;
        this.httpClientService = httpClientService;
        this.dataHandlerService = dataHandlerService;
        this.tokenKey = 'token';
        var currentUser = JSON.parse(localStorage.getItem('currentUser'));
        this.token = currentUser && currentUser.token;
    }
    LoginService.prototype.loginUser = function (username, password) {
        var _this = this;
        var headers = new http_1.Headers({ 'Content-Type': 'application/json' });
        var options = new http_1.RequestOptions({ headers: headers });
        var loginInfo = { Username: username, Password: password };
        return this.httpClientService.post('TokenAuth/GetAuthToken', loginInfo, options)
            .toPromise()
            .then(function (response) {
            var result = response.json();
            if (result.State === 1) {
                var json = result.Data;
                _this.token = json.accessToken;
                localStorage.setItem('currentUser', JSON.stringify({ username: username, token: json.accessToken }));
            }
            return result;
        })
            .catch(this.dataHandlerService.handleError);
    };
    LoginService.prototype.checkLogin = function () {
        var token = localStorage.getItem(this.tokenKey);
        return token != null;
    };
    LoginService.prototype.logout = function () {
        this.token = null;
        localStorage.removeItem('currentUser');
    };
    return LoginService;
}());
LoginService = __decorate([
    core_1.Injectable(),
    __metadata("design:paramtypes", [http_1.Http,
        index_1.HttpClientService,
        index_1.DataHandlerService])
], LoginService);
exports.LoginService = LoginService;
//# sourceMappingURL=login.service.js.map