import { NgModule } from '@angular/core'
import { BrowserModule } from '@angular/platform-browser'
import { HeaderComponent } from './header.component'
import { SidebarComponent } from './sidebar.component'
import { RouterModule } from '@angular/router'

@NgModule({
    imports: [
        BrowserModule,
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