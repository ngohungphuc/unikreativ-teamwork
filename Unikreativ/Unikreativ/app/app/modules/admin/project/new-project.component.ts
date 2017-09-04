import { PushService } from './../../../extensions/notification.service'
import { UserService } from '../../../services/users/user.service'
import { ProjectService } from './../../../services/project/project.service'
import { Component, OnInit, Inject } from '@angular/core'
import {
  FormControl,
  FormBuilder,
  FormGroup,
  Validators
} from '@angular/forms'
import { Toastr_Token, Toastr } from '../../../extensions/toastr'
import { RequestState } from '../../../model/RequestState'
import { Event } from '../../../model/EventModel'
import { Project } from '../../../model/ProjectModel'

@Component({
  selector: 'uni-new-project',
  templateUrl: 'partial/newproject'
})
export class NewProjectComponent implements OnInit {
  showResult = false
  clientList: any
  client: string
  newProjectForm: FormGroup

  constructor(
    private projectService: ProjectService,
    private userService: UserService,
    private fb: FormBuilder,
    @Inject(Toastr_Token) private toastr: Toastr,
    private pushService: PushService
  ) {}

  ngOnInit() {
    this.newProjectForm = this.fb.group({
      projectName: ['', Validators.required],
      user: ['', Validators.required],
      projectDescription: ['', Validators.required]
    })
  }

  async newProject(value: any,clientName) {
    const client = this.client ? clientName.value : this.client
    let newProject = {
      ProjectName: value.projectName,
      UserName: client,
      ProjectDescription: value.projectDescription
    }

    await this.projectService.newProject(newProject).then(res => {
      if (res.result) {
        this.pushService.notify(
          new Project(
            value.projectName,
            client,
            value.projectDescription,
            new Date()
          )
        )
        this.pushService.notify(
          new Event(
            res.eventData.TaskName,
            res.eventData.AssignBy,
            res.eventData.DateAssigned,
            res.eventData.Description
          )
        )
        this.toastr.success(res.msg, 'Success')
      } else this.toastr.error(res.msg, 'Error')
    })
  }

  searchClients(clientName) {
    if (clientName) {
      this.userService.searchClients(clientName).subscribe(
        res => {
          if (res) {
            this.showResult = true
            this.clientList = res
          }
        },
        err => {
          this.toastr.error('Error')
        }
      )
    } else this.showResult = false
  }

  selectClient(clientName) {
    this.client = clientName
    this.showResult = false
  }
}
