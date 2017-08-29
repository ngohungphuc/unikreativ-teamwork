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
const core_2 = require("@angular/core");
let EditMemberComponent = class EditMemberComponent {
    constructor(userService, toastr) {
        this.userService = userService;
        this.toastr = toastr;
    }
    ngOnInit() {
        this.CompanyName = new forms_1.FormControl('');
        this.PhoneNumber = new forms_1.FormControl('');
        this.Email = new forms_1.FormControl('', forms_1.Validators.required);
        this.JobTitle = new forms_1.FormControl('', forms_1.Validators.required);
        this.Role = new forms_1.FormControl('', forms_1.Validators.required);
        this.ChargeRate = new forms_1.FormControl('', forms_1.Validators.required);
        this.NormalizedUserName = new forms_1.FormControl('', forms_1.Validators.required);
        this.editMemberInfoForm = new forms_1.FormGroup({
            CompanyName: this.CompanyName,
            PhoneNumber: this.PhoneNumber,
            Email: this.Email,
            JobTitle: this.JobTitle,
            Role: this.Role,
            ChargeRate: this.ChargeRate,
            NormalizedUserName: this.NormalizedUserName
        });
    }
    editMemberInfo(value) {
        return __awaiter(this, void 0, void 0, function* () {
            let member = {
                Id: this.memberId.nativeElement.value,
                CompanyName: value.CompanyName,
                Email: value.Email,
                PhoneNumber: value.PhoneNumber,
                JobTitle: value.JobTitle,
                Role: value.Role,
                ChargeRate: value.ChargeRate,
                NormalizedUserName: value.NormalizedUserName
            };
            yield this
                .userService
                .updateMember(member)
                .then(result => this.toastr.success(result.msg, 'Success'))
                .catch(error => this.toastr.error(error.msg, 'Error'));
        });
    }
};
__decorate([
    core_1.Input(),
    __metadata("design:type", Array)
], EditMemberComponent.prototype, "member", void 0);
__decorate([
    core_2.ViewChild('memberId'),
    __metadata("design:type", core_2.ElementRef)
], EditMemberComponent.prototype, "memberId", void 0);
EditMemberComponent = __decorate([
    core_1.Component({ selector: 'uni-edit-member', templateUrl: 'partial/editmember', providers: [index_2.UserService] }),
    __param(1, core_1.Inject(index_1.Toastr_Token)),
    __metadata("design:paramtypes", [index_2.UserService, Object])
], EditMemberComponent);
exports.EditMemberComponent = EditMemberComponent;
//# sourceMappingURL=member-edit.component.js.map