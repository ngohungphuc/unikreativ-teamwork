import {
    AdminComponent,
    NewClientComponent,
    ClientEditComponent,
    NewMemberComponent,
    EditMemberComponent,
    UserComponent,
    ProjectComponent,
    NewProjectComponent
} from '../index'
import {AdminRoutingModule} from './admin.routing'
import {AuthGuard} from './../../extensions/guard/auth.guard'
import {AuthHttpServices, UserService} from '../../services/index'
import {BrowserModule} from '@angular/platform-browser'
import {FormsModule, ReactiveFormsModule} from '@angular/forms'
import {NavModule} from './../template/nav.module'
import {NgModule} from '@angular/core'
import { ProjectService } from '../../services/project/project.service'


@NgModule({
    imports: [
        BrowserModule, FormsModule, ReactiveFormsModule, NavModule, AdminRoutingModule
    ],
    declarations: [
        AdminComponent,
        UserComponent,
        NewClientComponent,
        ClientEditComponent,
        NewMemberComponent,
        EditMemberComponent,
        ProjectComponent,
        NewProjectComponent
    ],
    providers: [AuthGuard, UserService,ProjectService, AuthHttpServices]
})
export class AdminModule {}