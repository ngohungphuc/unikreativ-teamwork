"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var platform_browser_1 = require("@angular/platform-browser");
var router_1 = require("@angular/router");
var http_1 = require("@angular/http");
var forms_1 = require("@angular/forms");
var app_component_1 = require("./app.component");
var login_component_1 = require("./app/components/login/login.component");
var index_1 = require("./app/components/errors/index");
var routes_1 = require("./routes/routes");
var index_2 = require("./app/services/index");
var admin_module_1 = require("./app/modules/admin/admin.module");
var shared_module_1 = require("./app/extensions/shared.module");
var auth_guard_1 = require("./app/extensions/guard/auth.guard");
var AppModule = (function () {
    function AppModule() {
    }
    return AppModule;
}());
AppModule = __decorate([
    core_1.NgModule({
        imports: [
            platform_browser_1.BrowserModule,
            forms_1.FormsModule,
            forms_1.ReactiveFormsModule,
            http_1.HttpModule,
            shared_module_1.ServicesModule,
            router_1.RouterModule.forRoot(routes_1.appRoutes),
            admin_module_1.AdminModule
        ],
        declarations: [
            app_component_1.AppComponent,
            login_component_1.LoginComponent,
            index_1.Error404Component,
            index_1.Error500Component
        ],
        providers: [
            index_2.LoginService,
            auth_guard_1.AuthGuard
        ],
        bootstrap: [app_component_1.AppComponent]
    })
], AppModule);
exports.AppModule = AppModule;
//# sourceMappingURL=app.module.js.map