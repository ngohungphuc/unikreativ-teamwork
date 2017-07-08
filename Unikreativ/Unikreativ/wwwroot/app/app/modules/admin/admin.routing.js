"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
const admin_component_1 = require("./admin.component");
const auth_guard_1 = require("./../../extensions/guard/auth.guard");
const core_1 = require("@angular/core");
const project_component_1 = require("./project/project.component");
const router_1 = require("@angular/router");
const user_component_1 = require("./user/user.component");
exports.adminRoutes = [
    {
        path: 'admin',
        component: admin_component_1.AdminComponent,
        canActivate: [auth_guard_1.AuthGuard],
        children: [
            {
                path: 'people',
                component: user_component_1.UserComponent
            },
            {
                path: 'project',
                component: project_component_1.ProjectComponent
            }
        ]
    },
];
let AdminRoutingModule = class AdminRoutingModule {
};
AdminRoutingModule = __decorate([
    core_1.NgModule({
        imports: [router_1.RouterModule.forChild(exports.adminRoutes)],
        exports: [router_1.RouterModule]
    })
], AdminRoutingModule);
exports.AdminRoutingModule = AdminRoutingModule;
//# sourceMappingURL=admin.routing.js.map