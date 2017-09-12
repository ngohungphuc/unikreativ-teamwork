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
const router_1 = require("@angular/router");
const project_service_1 = require("../../../services/project/project.service");
let ProjectDetailComponent = class ProjectDetailComponent {
    constructor(route, projectService) {
        this.route = route;
        this.projectService = projectService;
    }
    ngOnInit() {
        this.route.params.subscribe(params => {
            this.projectService.getProjectByName(params['name']).then(res => {
                this.projectDetail = res;
                console.log(this.projectDetail);
            });
        });
    }
};
ProjectDetailComponent = __decorate([
    core_1.Component({
        selector: 'uni-project-detail',
        templateUrl: 'partial/ProjectDetail'
    }),
    __metadata("design:paramtypes", [router_1.ActivatedRoute,
        project_service_1.ProjectService])
], ProjectDetailComponent);
exports.ProjectDetailComponent = ProjectDetailComponent;
//# sourceMappingURL=project-details.component.js.map