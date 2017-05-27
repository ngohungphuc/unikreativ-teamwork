import { NgModule } from '@angular/core'
import { HeaderComponent } from './header.component'
import { SidebarComponent } from './sidebar.component'
import { RouterModule } from '@angular/router'

@NgModule({
    imports: [
        RouterModule
    ],
    exports: [
        HeaderComponent,
        SidebarComponent
    ],
    declarations: [
        HeaderComponent,
        SidebarComponent
    ]
})
export class NavModule { }