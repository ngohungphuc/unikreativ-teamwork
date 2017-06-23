"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
const index_1 = require("../index");
const admin_routing_1 = require("./admin.routing");
const auth_guard_1 = require("./../../extensions/guard/auth.guard");
const index_2 = require("../../services/index");
const platform_browser_1 = require("@angular/platform-browser");
const forms_1 = require("@angular/forms");
const nav_module_1 = require("./../template/nav.module");
const core_1 = require("@angular/core");
let AdminModule = class AdminModule {
};
AdminModule = __decorate([
    core_1.NgModule({
        imports: [
            platform_browser_1.BrowserModule, forms_1.FormsModule, forms_1.ReactiveFormsModule, nav_module_1.NavModule, admin_routing_1.AdminRoutingModule
        ],
        declarations: [
            index_1.AdminComponent,
            index_1.UserComponent,
            index_1.NewClientComponent,
            index_1.ClientEditComponent,
            index_1.NewMemberComponent,
            index_1.EditMemberComponent
        ],
        providers: [auth_guard_1.AuthGuard, index_2.UserService, index_2.AuthHttpServices]
    })
], AdminModule);
exports.AdminModule = AdminModule;
//# sourceMappingURL=admin.module.js.map