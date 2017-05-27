
import { NgModule } from '@angular/core'
import { CommonModule } from '@angular/common'
import { AdminRoutingModule } from './admin.routing'
import { AuthGuard } from './../../extensions/guard/auth.guard'
import {  AdminComponent, UserComponent } from '../index'
import { NavModule } from './../template/nav.module'

@NgModule({
    imports: [
        CommonModule,
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