import { Component, OnInit } from '@angular/core'
import { ActivatedRoute  } from '@angular/router'
import { ProjectService } from '../../../services/project/project.service';

@Component({
    selector: 'uni-project-detail',
    templateUrl: 'partial/ProjectDetail'
})
export class ProjectDetailComponent implements OnInit {
    projectName: any
    projectDetail: any
    constructor(
        private route: ActivatedRoute,
        private projectService: ProjectService) { }

    ngOnInit() {
        this.route.params.subscribe(params => {
            this.projectService.getProjectByName(params['name']).then(res => {
                this.projectDetail = res
                console.log(this.projectDetail)
            })
        })
    }
}