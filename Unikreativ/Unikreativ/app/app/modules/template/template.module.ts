import { NgModule } from '@angular/core'
import { CommonModule } from '@angular/common'
import { SidebarComponent, HeaderComponent } from '../index'

@NgModule({
    imports: [
        CommonModule
    ],
    exports: [
        SidebarComponent,
        HeaderComponent
    ],
    declarations: [
        SidebarComponent,
        HeaderComponent
    ]
})
export class TemplateModule { }