import { NgModule } from '@angular/core'
import { Routes, RouterModule } from '@angular/router'
import { Error404Component, Error500Component } from '../index'

export const errorsRoutes: Routes = [
    { path: '404', component: Error404Component },
    { path: '500', component: Error500Component }
]

@NgModule({
    imports: [RouterModule.forChild(errorsRoutes)],
    exports: [RouterModule]
})
export class ErrorsRoutingModule { }