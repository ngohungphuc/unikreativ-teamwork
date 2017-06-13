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
const http_1 = require("@angular/http");
const index_1 = require("../../extensions/index");
const app_status_1 = require("../../extensions/app-status");
require("rxjs/add/operator/toPromise");
let LoginService = class LoginService {
    constructor(http, httpClientService, dataHandlerService) {
        this.http = http;
        this.httpClientService = httpClientService;
        this.dataHandlerService = dataHandlerService;
        this.tokenKey = 'token';
    }
    loginUser(username, password) {
        let headers = new http_1.Headers({ 'Content-Type': 'application/json' });
        let options = new http_1.RequestOptions({ headers: headers });
        let loginInfo = { Username: username, Password: password };
        return this.httpClientService.post('TokenAuth/GetAuthToken', loginInfo, options)
            .toPromise()
            .then(response => {
            let result = response.json();
            if (result.State === app_status_1.AppStatusCode.LoginSuccess) {
                let json = result.Data;
                this.token = json.accessToken;
                sessionStorage.setItem('currentUser', JSON.stringify({ username: username, token: json.accessToken }));
            }
            return result;
        })
            .catch(this.dataHandlerService.handleError);
    }
    checkLogin() {
        let token = sessionStorage.getItem(this.tokenKey);
        return token != null;
    }
    logout() {
        this.token = null;
        sessionStorage.removeItem('currentUser');
    }
};
LoginService = __decorate([
    core_1.Injectable(),
    __metadata("design:paramtypes", [http_1.Http,
        index_1.HttpClientService,
        index_1.DataHandlerService])
], LoginService);
exports.LoginService = LoginService;
//# sourceMappingURL=login.service.js.map