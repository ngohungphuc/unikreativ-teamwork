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
var __param = (this && this.__param) || function (paramIndex, decorator) {
    return function (target, key) { decorator(target, key, paramIndex); }
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var router_1 = require("@angular/router");
var forms_1 = require("@angular/forms");
var login_service_1 = require("../../services/account/login.service");
var index_1 = require("./../../extensions/index");
var app_status_1 = require("../../extensions/app-status");
var LoginComponent = (function () {
    function LoginComponent(loginService, router, toastr) {
        this.loginService = loginService;
        this.router = router;
        this.toastr = toastr;
    }
    LoginComponent.prototype.ngOnInit = function () {
        this.username = new forms_1.FormControl('', forms_1.Validators.required);
        this.password = new forms_1.FormControl('', forms_1.Validators.required);
        this.loginForm = new forms_1.FormGroup({
            username: this.username,
            password: this.password
        });
    };
    LoginComponent.prototype.login = function (formValues) {
        var _this = this;
        this.loginService.loginUser(formValues.username, formValues.password).then(function (resp) {
            if (resp.State === app_status_1.AppStatusCode.LoginSuccess) {
                _this.router.navigate(['admin']);
            }
            else {
                _this.toastr.error('Invalid credential', 'Error');
            }
        });
    };
    return LoginComponent;
}());
LoginComponent = __decorate([
    core_1.Component({
        selector: 'login',
        templateUrl: 'partial/login',
        providers: [index_1.HttpClientService]
    }),
    __param(2, core_1.Inject(index_1.Toastr_Token)),
    __metadata("design:paramtypes", [login_service_1.LoginService, router_1.Router, Object])
], LoginComponent);
exports.LoginComponent = LoginComponent;
//# sourceMappingURL=login.component.js.map