import { Component, OnInit } from '@angular/core'
import { ProjectService } from '../../../services/project/project.service'
import * as $ from 'jquery'
@Component({
    selector: 'uni-project-list',
    templateUrl: 'partial/ProjectList'
})
export class ProjectListComponent implements OnInit {
    projectList: any
    constructor(private projectService: ProjectService) { }

    ngOnInit() { 
        this.projectService.getProjectList().then(res=> {
            console.log(res)
            this.projectList = res
        })

        let myHubProxy = $.connection.hub.createHubProxy('UnikreativHub')
        console.log(myHubProxy)
        myHubProxy.on('clientListener', function (msg) {
            console.log(msg)
        })

        $.connection.hub.start().done(function () {
            myHubProxy.invoke('TestHub')
        })
    }

}