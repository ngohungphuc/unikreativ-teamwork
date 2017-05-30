"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
var platform_browser_1 = require("@angular/platform-browser");
var core_1 = require("@angular/core");
var nav_module_1 = require("./../template/nav.module");
var admin_routing_1 = require("./admin.routing");
var auth_guard_1 = require("./../../extensions/guard/auth.guard");
var index_1 = require("../index");
var index_2 = require("../../services/index");
var AdminModule = (function () {
    function AdminModule() {
    }
    return AdminModule;
}());
AdminModule = __decorate([
    core_1.NgModule({
        imports: [
            platform_browser_1.BrowserModule,
            nav_module_1.NavModule,
            admin_routing_1.AdminRoutingModule
        ],
        declarations: [
            index_1.AdminComponent,
            index_1.UserComponent
        ],
        providers: [
            auth_guard_1.AuthGuard,
            index_2.UserService
        ],
    })
], AdminModule);
exports.AdminModule = AdminModule;
//# sourceMappingURL=admin.module.js.map