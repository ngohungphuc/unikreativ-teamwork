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
Object.defineProperty(exports, "__esModule", { value: true });
const env_1 = require("./../config/env");
const http_1 = require("@angular/http");
const core_1 = require("@angular/core");
let HttpClientService = class HttpClientService {
    constructor(http) {
        this.http = http;
        this.urlPrefix = env_1.Environment.API_URL;
    }
    get(url, options) {
        return this.http.get(this.urlPrefix + url, options);
    }
    post(url, data, options) {
        return this.http.post(this.urlPrefix + url, data, options);
    }
    put(url, data, options) {
        return this.http.put(this.urlPrefix + url, data, options);
    }
    delete(url, options) {
        return this.http.delete(this.urlPrefix + url, options);
    }
};
HttpClientService = __decorate([
    core_1.Injectable(),
    __metadata("design:paramtypes", [http_1.Http])
], HttpClientService);
exports.HttpClientService = HttpClientService;
//# sourceMappingURL=http-extensions.js.map