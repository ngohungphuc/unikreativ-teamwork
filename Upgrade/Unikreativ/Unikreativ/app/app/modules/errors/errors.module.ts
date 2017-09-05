import { Error404Component, Error500Component } from '../index'
import { ErrorsRoutingModule } from './errors.routing'
import { NgModule } from '@angular/core'


@NgModule({
    imports: [
        ErrorsRoutingModule
    ],
    declarations: [
        Error404Component,
        Error500Component
    ]
})
export class ErrorsModule { }