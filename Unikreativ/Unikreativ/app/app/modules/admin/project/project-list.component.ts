import { Component, OnInit } from '@angular/core'
import { ProjectService } from '../../../services/project/project.service'

@Component({
    selector: 'uni-project-list',
    templateUrl: 'partial/ProjectList'
})
export class ProjectListComponent implements OnInit {
    projectList: any
    constructor(private projectService: ProjectService) { }

    ngOnInit() { 
        this.projectService.getProjectList().then(res=> {
            this.projectList = res
        })

    }

}