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
const core_1 = require("@angular/core");
const project_service_1 = require("../../../services/project/project.service");
const $ = require("jquery");
let ProjectListComponent = class ProjectListComponent {
    constructor(projectService) {
        this.projectService = projectService;
    }
    ngOnInit() {
        this.projectService.getProjectList().then(res => {
            console.log(res);
            this.projectList = res;
        });
        let myHubProxy = $.connection.hub.createHubProxy('UnikreativHub');
        console.log(myHubProxy);
        myHubProxy.on('clientListener', function (msg) {
            console.log(msg);
        });
        $.connection.hub.start().done(function () {
            myHubProxy.invoke('TestHub');
        });
    }
};
ProjectListComponent = __decorate([
    core_1.Component({
        selector: 'uni-project-list',
        templateUrl: 'partial/ProjectList'
    }),
    __metadata("design:paramtypes", [project_service_1.ProjectService])
], ProjectListComponent);
exports.ProjectListComponent = ProjectListComponent;
//# sourceMappingURL=project-list.component.js.map