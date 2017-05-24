import { NgModule } from '@angular/core'
import { CommonModule } from '@angular/common'
import { HeaderComponent } from './header.component'
import { SidebarComponent } from './sidebar.component'

@NgModule({
    imports: [
        CommonModule
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