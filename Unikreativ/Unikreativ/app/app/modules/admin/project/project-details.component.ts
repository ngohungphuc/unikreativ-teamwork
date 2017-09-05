import { Component, OnInit } from '@angular/core'
import { ActivatedRoute  } from '@angular/router'

@Component({
    selector: 'uni-project-detail',
    templateUrl: 'partial/ProjectDetail'
})
export class ProjectDetailComponent implements OnInit {
    projectName: any

    constructor(private route: ActivatedRoute) { }

    ngOnInit() {
        this.projectName = this.route.params.subscribe(params => {
            console.log(params['name'])
        })
    }
}