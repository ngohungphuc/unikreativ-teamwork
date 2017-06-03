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
var forms_1 = require("@angular/forms");
var core_1 = require("@angular/core");
var index_1 = require("../../../services/index");
var ClientEditComponent = (function () {
    function ClientEditComponent(userService, loginService) {
        this.userService = userService;
        this.loginService = loginService;
    }
    ClientEditComponent.prototype.ngOnInit = function () {
        this.companyName = new forms_1.FormControl('', forms_1.Validators.required);
        this.country = new forms_1.FormControl('', forms_1.Validators.required);
        this.address = new forms_1.FormControl('', forms_1.Validators.required);
        this.email = new forms_1.FormControl('', forms_1.Validators.required);
        this.phoneNumber = new forms_1.FormControl('', forms_1.Validators.required);
        this.website = new forms_1.FormControl('', forms_1.Validators.required);
        this.editClientInfoForm = new forms_1.FormGroup({
            companyName: this.companyName,
            country: this.country,
            address: this.address,
            email: this.email,
            phoneNumber: this.phoneNumber,
            website: this.website
        });
    };
    ClientEditComponent.prototype.editClientInfo = function (value) {
        console.log(value);
        this.userService.updateClient(value).then(function (resp) {
            console.log(resp);
        });
    };
    return ClientEditComponent;
}());
__decorate([
    core_1.Input(),
    __metadata("design:type", Array)
], ClientEditComponent.prototype, "client", void 0);
ClientEditComponent = __decorate([
    core_1.Component({
        selector: 'client-edit',
        templateUrl: 'partial/clientedit',
        providers: [
            index_1.UserService,
            index_1.LoginService
        ]
    }),
    __metadata("design:paramtypes", [index_1.UserService,
        index_1.LoginService])
], ClientEditComponent);
exports.ClientEditComponent = ClientEditComponent;
//# sourceMappingURL=client-edit.component.js.map