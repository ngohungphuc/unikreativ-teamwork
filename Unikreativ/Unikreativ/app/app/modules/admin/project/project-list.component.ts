import { Component, OnInit, Input } from '@angular/core'
import { ProjectService } from '../../../services/project/project.service'
import { Subscription } from 'rxjs/Subscription'
import { PushService } from '../../../extensions/notification.service'
import { Project } from '../../../model/ProjectModel'

@Component({
    selector: 'uni-project-list',
    templateUrl: 'partial/ProjectList'
})
export class ProjectListComponent implements OnInit {
    private subscriptions: Subscription[] = []
    projectList: any

    constructor(
        private pushService: PushService,
        private projectService: ProjectService) { }

    ngOnInit() { 
        this.projectService.getProjectList().then(res => {
            this.projectList = res
        })

        this.subscriptions.push(
            this.pushService
            .observe(event => event instanceof Project)
            .subscribe(val => {
                this.populateProject(val)
            })
        )
    }

    populateProject(projectData){
        console.log(projectData)
        this.projectList = [...this.projectList, projectData]
    }
}