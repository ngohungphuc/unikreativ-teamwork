import { NgModule } from '@angular/core'
import { CommonModule } from '@angular/common'
import { AdminRoutingModule } from './admin.routing'
import { AuthGuard } from './../../extensions/guard/auth.guard'
import { AdminComponent } from './admin.component'

@NgModule({
    imports: [
        CommonModule,
        AdminRoutingModule
    ],
    declarations: [
        AdminComponent
    ],
    providers: [
        AuthGuard
    ],
})
export class AdminModule { }