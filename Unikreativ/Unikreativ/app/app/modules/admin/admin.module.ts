import { NgModule } from '@angular/core'
import { NavModule } from './../template/nav.module'
import { AdminRoutingModule } from './admin.routing'
import { AuthGuard } from './../../extensions/guard/auth.guard'
import { AdminComponent, UserComponent } from '../index'


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
        AuthGuard
    ],
})
export class AdminModule { }