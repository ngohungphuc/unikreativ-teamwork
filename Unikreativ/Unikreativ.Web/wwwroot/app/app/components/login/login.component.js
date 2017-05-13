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
var forms_1 = require("@angular/forms");
var login_service_1 = require("../../services/account/login.service");
var LoginComponent = (function () {
    function LoginComponent(loginService) {
        this.loginService = loginService;
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
        this.loginService.loginUser(formValues.username, formValues.password).subscribe(function (resp) {
            console.log(resp);
        });
    };
    return LoginComponent;
}());
LoginComponent = __decorate([
    core_1.Component({
        selector: 'login',
        templateUrl: 'partial/login'
    }),
    __metadata("design:paramtypes", [login_service_1.LoginService])
], LoginComponent);
exports.LoginComponent = LoginComponent;
//# sourceMappingURL=login.component.js.map