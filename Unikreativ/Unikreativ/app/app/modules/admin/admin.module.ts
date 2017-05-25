import { NgModule } from '@angular/core'
import { CommonModule } from '@angular/common'
import { AdminRoutingModule } from './admin.routing'
import { AuthGuard } from './../../extensions/guard/auth.guard'
import { AdminComponent } from './admin.component'
import { NavModule } from './../template/nav.module'
import { UserComponent } from './user/user.component'

@NgModule({
    imports: [
        CommonModule,
        AdminRoutingModule,
        NavModule
    ],
    declarations: [
        AdminComponent,
        UserComponent
    ],
    providers: [
        AuthGuard
    ],
})
export class AdminModule { }