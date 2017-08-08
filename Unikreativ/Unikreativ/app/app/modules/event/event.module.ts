import { NgModule } from '@angular/core'
import { BrowserModule } from '@angular/platform-browser'
import { EventListComponent } from '../index'

@NgModule({
    imports: [ 
        BrowserModule 
    ],
    exports: [
        EventListComponent
    ],
    declarations: [ 
        EventListComponent 
    ],
    providers:[]
})
export class EventModule { }