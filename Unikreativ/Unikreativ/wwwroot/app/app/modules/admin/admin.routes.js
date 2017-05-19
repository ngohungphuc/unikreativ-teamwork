"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var index_1 = require("./index");
var auth_guard_1 = require("./../../extensions/guard/auth.guard");
exports.adminRoutes = [
    { path: 'dashboard', component: index_1.DashboardComponent, canActivate: [auth_guard_1.AuthGuard] }
];
//# sourceMappingURL=admin.routes.js.map