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

@Component({
  selector: 'new-project',
  templateUrl: 'partial/newproject'
})
export class NewProjectComponent implements OnInit {
  showResult = false
  clientList: any
  newProjectForm: FormGroup

  constructor(
    private projectService: ProjectService,
    private userService: UserService,
    private fb: FormBuilder,
    @Inject(Toastr_Token) private toastr: Toastr
  ) {}

  ngOnInit() {
    this.newProjectForm = this.fb.group({
      projectName: ['', Validators.required],
      user: ['', Validators.required],
      projectDescription: ['', Validators.required]
    })
  }

  async newProject(value: any) {
    let newProject = {
      ProjectName: value.projectName,
      User: value.user,
      ProjectDescription: value.projectDescription
    }

    await this.projectService.newProject(newProject).then(res => {
      if (res.State === RequestState.Success)
        this.toastr.success(res.Msg, 'Success')
      else this.toastr.error(res.Msg, 'Error')
    })
  }

  searchClients(clientName: string) {
    this.userService.searchClients(clientName).subscribe(
      res => {
        if (res) {
          console.log(res)
          this.showResult = true
          this.clientList = res
        }
      },
      err => {
        this.toastr.error('Error')
      }
    )
  }
}
