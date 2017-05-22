
import { RouterModule, Routes } from '@angular/router'
import { NgModule } from '@angular/core'
import { Error404Component, Error500Component, LoginComponent } from './app/components/index'
import { AdminComponent } from './app/components/admin.component'
import { AuthGuard } from './app/extensions/guard/auth.guard'

export const appRoutes: Routes = [
    { path: 'login', component: LoginComponent },
    { path: 'admin', component: AdminComponent, canActivate: [AuthGuard] },
    { path: '404', component: Error404Component },
    { path: '500', component: Error500Component },
    { path: '', redirectTo: '/login', pathMatch: 'full' },
    { path: '**', redirectTo: '/404', pathMatch: 'full' }
]
@NgModule({
    imports: [RouterModule.forRoot(appRoutes)],
    exports: [RouterModule]
})

export class AppRoutingModule { }