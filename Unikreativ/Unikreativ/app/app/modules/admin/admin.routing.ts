import {
    AdminComponent,
    ProjectComponent,
    ProjectDetailComponent,
    UserComponent
    } from '../index'
import { AuthGuard } from './../../extensions/guard/auth.guard'
import { NgModule } from '@angular/core'
import { RouterModule, Routes } from '@angular/router'

export const adminRoutes: Routes = [
    {
        path: 'admin',
        component: AdminComponent,
        canActivate: [AuthGuard],
        children: [
            {
                path:'project',
                component: ProjectComponent
            },
            {
                path:'project/:name',
                component: ProjectDetailComponent
            },
            {
                path: 'people',
                component: UserComponent
            }
        ]
    },

]

@NgModule({
    imports: [RouterModule.forChild(adminRoutes)],
    exports: [RouterModule]
})
export class AdminRoutingModule { }