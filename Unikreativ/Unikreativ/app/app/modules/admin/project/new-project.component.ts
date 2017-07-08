import { ProjectService } from './../../../services/project/project.service'
import {Component, OnInit, Inject} from '@angular/core'
import { FormControl, FormGroup, Validators } from '@angular/forms'
import {Toastr_Token,Toastr} from '../../../extensions/toastr'

@Component({
    selector: 'new-project', 
    templateUrl: 'partial/newproject'
})

export class NewProjectComponent implements OnInit {

    newProjectForm: FormGroup
    ProjectName: FormControl
    ClientName: FormControl
    ProjectDescription: FormControl

    constructor(
        private projectService:ProjectService,
        @Inject(Toastr_Token)private toastr: Toastr) {}

    ngOnInit() {
        this.ProjectName = new FormControl('', Validators.required)
        this.ClientName = new FormControl('', Validators.required)
        this.ProjectDescription = new FormControl('', Validators.required)


        this.newProjectForm = new FormGroup({
            ProjectName: this.ProjectName,
            ClientName: this.ClientName,
            ProjectDescription: this.ProjectDescription
        })

    }

    async newProject(value: any) {
        let newProject = {
            ProjectName: value.ProjectName,
            ClientName: value.ClientName,
            ProjectDescription: value.ProjectDescription
        }

        await this.projectService.newProject(newProject).then(
            res => {
                if (res.result) 
                    this.toastr.success(res.msg, 'Success')
                else this.toastr.error(res.msg, 'Error')
            })
    }
}