import { NgModule } from '@angular/core'
import { Routes, RouterModule } from '@angular/router'
import { UserComponent } from './user.component'
import { AuthGuard } from './../../extensions/guard/auth.guard'

export const adminRoutes: Routes = [
    { path: 'user', component: UserComponent }
]

@NgModule({
    imports: [RouterModule.forChild(adminRoutes)],
    exports: [RouterModule]
})
export class AdminRoutingModule { }