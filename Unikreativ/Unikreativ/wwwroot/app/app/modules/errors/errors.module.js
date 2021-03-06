"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
const index_1 = require("../index");
const errors_routing_1 = require("./errors.routing");
const core_1 = require("@angular/core");
let ErrorsModule = class ErrorsModule {
};
ErrorsModule = __decorate([
    core_1.NgModule({
        imports: [
            errors_routing_1.ErrorsRoutingModule
        ],
        declarations: [
            index_1.Error404Component,
            index_1.Error500Component
        ]
    })
], ErrorsModule);
exports.ErrorsModule = ErrorsModule;
//# sourceMappingURL=errors.module.js.map