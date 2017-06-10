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
const Observable_1 = require("rxjs/Observable");
const index_1 = require("../../../extensions/index");
const index_2 = require("../../../services/index");
let UserComponent = class UserComponent {
    constructor(userService, toastr) {
        this.userService = userService;
        this.toastr = toastr;
    }
    ngOnInit() {
        let teamMembersAPI = this.userService.getTeamMembers();
        let clientsAPI = this.userService.getClients();
        Observable_1.Observable.forkJoin([teamMembersAPI, clientsAPI]).subscribe(result => {
            this.teamMembers = result[0];
            this.clients = result[1];
        });
    }
    selectClient(client) {
        this.client = client;
    }
    deleteClient(clientId) {
        return __awaiter(this, void 0, void 0, function* () {
            if (confirm('Are you sure to delete')) {
                yield this.userService.deleteClient(clientId).then(res => {
                    if (res.result) {
                        this.toastr.success(res.msg, 'Success');
                    }
                    else
                        this.toastr.error(res.msg, 'Error');
                });
            }
        });
    }
};
UserComponent = __decorate([
    core_1.Component({
        selector: 'user',
        templateUrl: 'partial/usermanage',
        providers: [index_2.UserService]
    }),
    __param(1, core_1.Inject(index_1.Toastr_Token)),
    __metadata("design:paramtypes", [index_2.UserService, Object])
], UserComponent);
exports.UserComponent = UserComponent;
//# sourceMappingURL=user.component.js.map