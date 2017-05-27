import { NgModule } from '@angular/core'
import { NavModule } from './../template/nav.module'
import { AdminRoutingModule } from './admin.routing'
import { AuthGuard } from './../../extensions/guard/auth.guard'
import { AdminComponent, UserComponent } from '../index'
import { UserService } from '../../services/index'


@NgModule({
    imports: [
        NavModule,
        AdminRoutingModule
    ],
    declarations: [
        AdminComponent,
        UserComponent
    ],
    providers: [
        AuthGuard,
        UserService
    ],
})
export class AdminModule { }