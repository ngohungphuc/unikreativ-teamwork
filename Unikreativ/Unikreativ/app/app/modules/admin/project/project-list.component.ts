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
        this.populateProject()

        this.subscriptions.push(
            this.pushService
            .observe(event => event instanceof Project)
            .subscribe(val => {
                this.populateProject()
            })
        )
    }

    populateProject() {
        this.projectService.getProjectList().then(res => {
            this.projectList = res
        })
    }
}