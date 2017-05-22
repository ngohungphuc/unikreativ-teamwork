import { NgModule } from '@angular/core'
import { CommonModule } from '@angular/common'
import { ErrorsRoutingModule } from './errors.routing'
import { Error404Component, Error500Component } from '../index'


@NgModule({
    imports: [
        CommonModule,
        ErrorsRoutingModule
    ],
    declarations: [
        Error404Component,
        Error500Component
    ]
})
export class ErrorsModule { }