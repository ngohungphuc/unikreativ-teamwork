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
const index_1 = require("../../../extensions/index");
const index_2 = require("../../../services/index");
const RequestState_1 = require("../../../model/RequestState");
let NewMemberComponent = class NewMemberComponent {
    constructor(userService, toastr) {
        this.userService = userService;
        this.toastr = toastr;
        this.newMemberCreated = new core_1.EventEmitter();
    }
    ngOnInit() {
        this.CompanyName = new forms_1.FormControl('');
        this.JobTitle = new forms_1.FormControl('', forms_1.Validators.required);
        this.Email = new forms_1.FormControl('', forms_1.Validators.required);
        this.PhoneNumber = new forms_1.FormControl('');
        this.UserName = new forms_1.FormControl('', forms_1.Validators.required);
        this.ChargeRate = new forms_1.FormControl('', forms_1.Validators.required);
        this.NormalizedUserName = new forms_1.FormControl('', forms_1.Validators.required);
        this.Role = new forms_1.FormControl('', forms_1.Validators.required);
        this.newMemberForm = new forms_1.FormGroup({
            CompanyName: this.CompanyName,
            JobTitle: this.JobTitle,
            ChargeRate: this.ChargeRate,
            Email: this.Email,
            PhoneNumber: this.PhoneNumber,
            NormalizedUserName: this.NormalizedUserName,
            Role: this.Role,
            UserName: this.UserName
        });
    }
    newMember(value) {
        return __awaiter(this, void 0, void 0, function* () {
            let newMember = {
                CompanyName: value.CompanyName,
                Email: value.Email,
                PhoneNumber: value.PhoneNumber,
                UserName: value.UserName,
                JobTitle: value.JobTitle,
                ChargeRate: value.ChargeRate,
                NormalizedUserName: value.NormalizedUserName,
                Role: value.Role
            };
            yield this
                .userService
                .newMember(newMember)
                .then(res => {
                console.log(res);
                if (res.State === RequestState_1.RequestState.Success) {
                    this.toastr.success(res.Msg, 'Success');
                    this.newMemberCreated.emit(newMember);
                }
                else
                    this.toastr.error(res.Msg, 'Error');
            });
        });
    }
};
__decorate([
    core_1.Output(),
    __metadata("design:type", Object)
], NewMemberComponent.prototype, "newMemberCreated", void 0);
NewMemberComponent = __decorate([
    core_1.Component({
        selector: 'uni-new-member',
        templateUrl: 'partial/newmember',
        providers: [index_2.UserService]
    }),
    __param(1, core_1.Inject(index_1.Toastr_Token)),
    __metadata("design:paramtypes", [index_2.UserService, Object])
], NewMemberComponent);
exports.NewMemberComponent = NewMemberComponent;
//# sourceMappingURL=member-new.component.js.map