import { NgModule } from '@angular/core'
import { ErrorsRoutingModule } from './errors.routing'
import { Error404Component, Error500Component } from '../index'


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