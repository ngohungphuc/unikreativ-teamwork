"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
const platform_browser_1 = require("@angular/platform-browser");
const core_1 = require("@angular/core");
const header_component_1 = require("./header.component");
const sidebar_component_1 = require("./sidebar.component");
const router_1 = require("@angular/router");
let NavModule = class NavModule {
};
NavModule = __decorate([
    core_1.NgModule({
        imports: [
            platform_browser_1.BrowserModule,
            router_1.RouterModule
        ],
        exports: [
            header_component_1.HeaderComponent,
            sidebar_component_1.SidebarComponent
        ],
        declarations: [
            header_component_1.HeaderComponent,
            sidebar_component_1.SidebarComponent
        ]
    })
], NavModule);
exports.NavModule = NavModule;
//# sourceMappingURL=nav.module.js.map