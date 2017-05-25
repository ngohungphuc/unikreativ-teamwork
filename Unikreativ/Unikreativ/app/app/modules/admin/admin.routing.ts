import { NgModule } from '@angular/core'
import { Routes, RouterModule } from '@angular/router'
import { UserComponent } from './user/user.component'


export const adminRoutes: Routes = [
    { path: 'people', component: UserComponent }
]

@NgModule({
    imports: [RouterModule.forChild(adminRoutes)],
    exports: [RouterModule]
})
export class AdminRoutingModule { }