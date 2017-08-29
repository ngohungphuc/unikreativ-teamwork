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
const forms_1 = require("@angular/forms");
const toastr_1 = require("../../../extensions/toastr");
const index_1 = require("../../../services/index");
let ClientEditComponent = class ClientEditComponent {
    constructor(userService, toastr) {
        this.userService = userService;
        this.toastr = toastr;
    }
    ngOnInit() {
        this.CompanyName = new forms_1.FormControl('', forms_1.Validators.required);
        this.Country = new forms_1.FormControl('', forms_1.Validators.required);
        this.Address = new forms_1.FormControl('', forms_1.Validators.required);
        this.Email = new forms_1.FormControl('', forms_1.Validators.required);
        this.PhoneNumber = new forms_1.FormControl('', forms_1.Validators.required);
        this.Website = new forms_1.FormControl('', forms_1.Validators.required);
        this.Industry = new forms_1.FormControl('', forms_1.Validators.required);
        this.editClientInfoForm = new forms_1.FormGroup({
            CompanyName: this.CompanyName,
            Country: this.Country,
            Address: this.Address,
            Email: this.Email,
            PhoneNumber: this.PhoneNumber,
            Website: this.Website,
            Industry: this.Industry
        });
    }
    editClientInfo(value) {
        return __awaiter(this, void 0, void 0, function* () {
            let client = {
                Id: this.clientId.nativeElement.value,
                CompanyName: value.CompanyName,
                Country: value.Country,
                Address: value.Address,
                Email: value.Email,
                PhoneNumber: value.PhoneNumber,
                Website: value.Website,
                Industry: value.Industry
            };
            yield this
                .userService
                .updateClient(client)
                .then(result => this.toastr.success(result.msg, 'Success'))
                .catch(error => this.toastr.error(error.msg, 'Error'));
        });
    }
};
__decorate([
    core_1.Input(),
    __metadata("design:type", Array)
], ClientEditComponent.prototype, "client", void 0);
__decorate([
    core_1.ViewChild('clientId'),
    __metadata("design:type", core_1.ElementRef)
], ClientEditComponent.prototype, "clientId", void 0);
ClientEditComponent = __decorate([
    core_1.Component({ selector: 'uni-edit-client', templateUrl: 'partial/clientedit', providers: [index_1.UserService] }),
    __param(1, core_1.Inject(toastr_1.Toastr_Token)),
    __metadata("design:paramtypes", [index_1.UserService, Object])
], ClientEditComponent);
exports.ClientEditComponent = ClientEditComponent;
//# sourceMappingURL=client-edit.component.js.map