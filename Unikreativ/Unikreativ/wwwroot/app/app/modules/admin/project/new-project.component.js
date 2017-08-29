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
var __param = (this && this.__param) || function (paramIndex, decorator) {
    return function (target, key) { decorator(target, key, paramIndex); }
};
var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : new P(function (resolve) { resolve(result.value); }).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
Object.defineProperty(exports, "__esModule", { value: true });
const notification_service_1 = require("./../../../extensions/notification.service");
const user_service_1 = require("../../../services/users/user.service");
const project_service_1 = require("./../../../services/project/project.service");
const core_1 = require("@angular/core");
const forms_1 = require("@angular/forms");
const toastr_1 = require("../../../extensions/toastr");
const ProjectModel_1 = require("../../../model/ProjectModel");
let NewProjectComponent = class NewProjectComponent {
    constructor(projectService, userService, fb, toastr, pushService) {
        this.projectService = projectService;
        this.userService = userService;
        this.fb = fb;
        this.toastr = toastr;
        this.pushService = pushService;
        this.showResult = false;
    }
    ngOnInit() {
        this.newProjectForm = this.fb.group({
            projectName: ['', forms_1.Validators.required],
            user: ['', forms_1.Validators.required],
            projectDescription: ['', forms_1.Validators.required]
        });
    }
    newProject(value) {
        return __awaiter(this, void 0, void 0, function* () {
            let newProject = {
                ProjectName: value.projectName,
                UserName: this.client,
                ProjectDescription: value.projectDescription
            };
            yield this.projectService.newProject(newProject).then(res => {
                if (res.result) {
                    this.toastr.success(res.msg, 'Success');
                    this.pushService.notify(new ProjectModel_1.Project(res.eventData.TaskName, res.eventData.AssignBy, res.eventData.DateAssigned, res.eventData.Description));
                }
                else
                    this.toastr.error(res.msg, 'Error');
            });
        });
    }
    searchClients(clientName) {
        if (clientName) {
            this.userService.searchClients(clientName).subscribe(res => {
                if (res) {
                    this.showResult = true;
                    this.clientList = res;
                }
            }, err => {
                this.toastr.error('Error');
            });
        }
        else
            this.showResult = false;
    }
    selectClient(clientName) {
        this.client = clientName;
        this.showResult = false;
    }
};
NewProjectComponent = __decorate([
    core_1.Component({
        selector: 'uni-new-project',
        templateUrl: 'partial/newproject'
    }),
    __param(3, core_1.Inject(toastr_1.Toastr_Token)),
    __metadata("design:paramtypes", [project_service_1.ProjectService,
        user_service_1.UserService,
        forms_1.FormBuilder, Object, notification_service_1.PushService])
], NewProjectComponent);
exports.NewProjectComponent = NewProjectComponent;
//# sourceMappingURL=new-project.component.js.map