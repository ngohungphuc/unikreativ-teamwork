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
var NewClientComponent = (function () {
    function NewClientComponent(userService) {
        this.userService = userService;
    }
    NewClientComponent.prototype.ngOnInit = function () {
        this.CompanyName = new forms_1.FormControl('', forms_1.Validators.required);
        this.Country = new forms_1.FormControl('', forms_1.Validators.required);
        this.Address = new forms_1.FormControl('', forms_1.Validators.required);
        this.Email = new forms_1.FormControl('', forms_1.Validators.required);
        this.Phone = new forms_1.FormControl('', forms_1.Validators.required);
        this.Website = new forms_1.FormControl('', forms_1.Validators.required);
        this.Industry = new forms_1.FormControl('', forms_1.Validators.required);
        this.UserName = new forms_1.FormControl('', forms_1.Validators.required);
        this.PasswordHash = new forms_1.FormControl('', forms_1.Validators.required);
        this.newClientForm = new forms_1.FormGroup({
            CompanyName: this.CompanyName,
            Country: this.Country,
            Address: this.Address,
            Email: this.Email,
            Phone: this.Phone,
            Website: this.Website,
            Industry: this.Industry,
            UserName: this.UserName,
            PasswordHash: this.PasswordHash
        });
    };
    NewClientComponent.prototype.newClient = function (value) {
        console.log(value);
        this.userService.newClient(value).then(function (data) {
            console.log(data);
        }, function (error) {
            console.log(error);
        });
    };
    return NewClientComponent;
}());
NewClientComponent = __decorate([
    core_1.Component({
        selector: 'client-new',
        templateUrl: 'partial/clientnew',
        providers: [
            index_1.UserService
        ]
    }),
    __metadata("design:paramtypes", [index_1.UserService])
], NewClientComponent);
exports.NewClientComponent = NewClientComponent;
//# sourceMappingURL=client-new.component.js.map