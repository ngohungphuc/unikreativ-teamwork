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
var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : new P(function (resolve) { resolve(result.value); }).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
Object.defineProperty(exports, "__esModule", { value: true });
const core_1 = require("@angular/core");
const router_1 = require("@angular/router");
const forms_1 = require("@angular/forms");
const login_service_1 = require("../../services/account/login.service");
const index_1 = require("./../../extensions/index");
const app_status_1 = require("../../extensions/app-status");
let LoginComponent = class LoginComponent {
    constructor(loginService, router, toastr) {
        this.loginService = loginService;
        this.router = router;
        this.toastr = toastr;
        if (sessionStorage.getItem('currentUser') !== null)
            this.router.navigate(['admin']);
    }
    ngOnInit() {
        this.username = new forms_1.FormControl('', forms_1.Validators.required);
        this.password = new forms_1.FormControl('', forms_1.Validators.required);
        this.loginForm = new forms_1.FormGroup({
            username: this.username,
            password: this.password
        });
    }
    login(formValues) {
        return __awaiter(this, void 0, void 0, function* () {
            yield this.loginService.loginUser(formValues.username, formValues.password).then(resp => {
                if (resp.State === app_status_1.AppStatusCode.LoginSuccess) {
                    this.router.navigate(['admin']);
                }
                else {
                    this.toastr.error('Invalid credential', 'Error');
                }
            });
        });
    }
};
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