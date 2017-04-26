"use strict";
var _404_component_1 = require("../app/components/errors/404.component");
var _500_component_1 = require("../app/components/errors/500.component");
var login_component_1 = require("../app/components/login/login.component");
exports.appRoutes = [
    { path: 'login', component: login_component_1.LoginComponent },
    { path: '404', component: _404_component_1.Error404Component },
    { path: '500', component: _500_component_1.Error500Component },
    { path: '', redirectTo: '/login', pathMatch: 'full' },
];
//# sourceMappingURL=routes.js.map