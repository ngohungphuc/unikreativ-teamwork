
import { NgModule } from '@angular/core'
import { Routes, RouterModule } from '@angular/router'
import { AdminComponent } from '../index'
import { AuthGuard } from './../../extensions/guard/auth.guard'

export const adminRoutes: Routes = [
    { path: 'admin', component: AdminComponent, canActivate: [AuthGuard] }
]

@NgModule({
    imports: [RouterModule.forChild(adminRoutes)],
    exports: [RouterModule]
})
export class AdminRoutingModule { }