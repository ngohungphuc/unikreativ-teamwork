import { AuthGuard } from './../../extensions/guard/auth.guard'
import { AdminComponent } from './admin.component'
import { NgModule } from '@angular/core'
import { Routes, RouterModule } from '@angular/router'
import { UserComponent } from './user/user.component'


export const adminRoutes: Routes = [
    {
        path: 'admin',
        component: AdminComponent,
        canActivate: [AuthGuard],
        children: [
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