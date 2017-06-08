import { FormsModule, ReactiveFormsModule } from '@angular/forms'
import { BrowserModule } from '@angular/platform-browser'
import { NgModule } from '@angular/core'
import { NavModule } from './../template/nav.module'
import { AdminRoutingModule } from './admin.routing'
import { AuthGuard } from './../../extensions/guard/auth.guard'
import { AdminComponent, UserComponent, NewClientComponent, ClientEditComponent } from '../index'
import { UserService, AuthHttpServices } from '../../services/index'


@NgModule({
    imports: [
        BrowserModule,
        FormsModule,
        ReactiveFormsModule,
        NavModule,
        AdminRoutingModule
    ],
    declarations: [
        AdminComponent,
        UserComponent,
        NewClientComponent,
        ClientEditComponent
    ],
    providers: [
        AuthGuard,
        UserService,
        AuthHttpServices
    ],
})
export class AdminModule { }