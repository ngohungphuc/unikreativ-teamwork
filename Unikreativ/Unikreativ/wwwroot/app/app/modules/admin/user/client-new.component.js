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
var __generator = (this && this.__generator) || function (thisArg, body) {
    var _ = { label: 0, sent: function() { if (t[0] & 1) throw t[1]; return t[1]; }, trys: [], ops: [] }, f, y, t, g;
    return g = { next: verb(0), "throw": verb(1), "return": verb(2) }, typeof Symbol === "function" && (g[Symbol.iterator] = function() { return this; }), g;
    function verb(n) { return function (v) { return step([n, v]); }; }
    function step(op) {
        if (f) throw new TypeError("Generator is already executing.");
        while (_) try {
            if (f = 1, y && (t = y[op[0] & 2 ? "return" : op[0] ? "throw" : "next"]) && !(t = t.call(y, op[1])).done) return t;
            if (y = 0, t) op = [0, t.value];
            switch (op[0]) {
                case 0: case 1: t = op; break;
                case 4: _.label++; return { value: op[1], done: false };
                case 5: _.label++; y = op[1]; op = [0]; continue;
                case 7: op = _.ops.pop(); _.trys.pop(); continue;
                default:
                    if (!(t = _.trys, t = t.length > 0 && t[t.length - 1]) && (op[0] === 6 || op[0] === 2)) { _ = 0; continue; }
                    if (op[0] === 3 && (!t || (op[1] > t[0] && op[1] < t[3]))) { _.label = op[1]; break; }
                    if (op[0] === 6 && _.label < t[1]) { _.label = t[1]; t = op; break; }
                    if (t && _.label < t[2]) { _.label = t[2]; _.ops.push(op); break; }
                    if (t[2]) _.ops.pop();
                    _.trys.pop(); continue;
            }
            op = body.call(thisArg, _);
        } catch (e) { op = [6, e]; y = 0; } finally { f = t = 0; }
        if (op[0] & 5) throw op[1]; return { value: op[0] ? op[1] : void 0, done: true };
    }
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var forms_1 = require("@angular/forms");
var index_1 = require("../../../extensions/index");
var index_2 = require("../../../services/index");
var NewClientComponent = (function () {
    function NewClientComponent(userService, toastr) {
        this.userService = userService;
        this.toastr = toastr;
        this.newClientCreated = new core_1.EventEmitter();
    }
    NewClientComponent.prototype.ngOnInit = function () {
        this.CompanyName = new forms_1.FormControl('', forms_1.Validators.required);
        this.Country = new forms_1.FormControl('', forms_1.Validators.required);
        this.Address = new forms_1.FormControl('', forms_1.Validators.required);
        this.Email = new forms_1.FormControl('', forms_1.Validators.required);
        this.PhoneNumber = new forms_1.FormControl('', forms_1.Validators.required);
        this.Website = new forms_1.FormControl('', forms_1.Validators.required);
        this.Industry = new forms_1.FormControl('', forms_1.Validators.required);
        this.UserName = new forms_1.FormControl('', forms_1.Validators.required);
        this.PasswordHash = new forms_1.FormControl('', forms_1.Validators.required);
        this.newClientForm = new forms_1.FormGroup({
            CompanyName: this.CompanyName,
            Country: this.Country,
            Address: this.Address,
            Email: this.Email,
            PhoneNumber: this.PhoneNumber,
            Website: this.Website,
            Industry: this.Industry,
            UserName: this.UserName,
            PasswordHash: this.PasswordHash
        });
    };
    NewClientComponent.prototype.newClient = function (value) {
        return __awaiter(this, void 0, void 0, function () {
            var _this = this;
            var newClient;
            return __generator(this, function (_a) {
                switch (_a.label) {
                    case 0:
                        newClient = {
                            CompanyName: value.CompanyName,
                            Country: value.Country,
                            Address: value.Address,
                            Email: value.Email,
                            PhoneNumber: value.PhoneNumber,
                            Website: value.Website,
                            Industry: value.Industry,
                            UserName: value.UserName,
                            PasswordHash: value.PasswordHash
                        };
                        return [4, this.userService.newClient(newClient).then(function (res) {
                                if (res.result) {
                                    _this.toastr.success(res.msg, 'Success');
                                    _this.newClientCreated.emit(newClient);
                                }
                                else
                                    _this.toastr.error(res.msg, 'Error');
                            })];
                    case 1:
                        _a.sent();
                        return [2];
                }
            });
        });
    };
    return NewClientComponent;
}());
__decorate([
    core_1.Output(),
    __metadata("design:type", Object)
], NewClientComponent.prototype, "newClientCreated", void 0);
NewClientComponent = __decorate([
    core_1.Component({
        selector: 'client-new',
        templateUrl: 'partial/clientnew',
        providers: [
            index_2.UserService
        ]
    }),
    __param(1, core_1.Inject(index_1.Toastr_Token)),
    __metadata("design:paramtypes", [index_2.UserService, Object])
], NewClientComponent);
exports.NewClientComponent = NewClientComponent;
//# sourceMappingURL=client-new.component.js.map