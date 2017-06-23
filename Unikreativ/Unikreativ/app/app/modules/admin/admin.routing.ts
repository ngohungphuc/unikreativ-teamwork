import { AdminComponent } from './admin.component'
import { AuthGuard } from './../../extensions/guard/auth.guard'
import { NgModule } from '@angular/core'
import { RouterModule, Routes } from '@angular/router'
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