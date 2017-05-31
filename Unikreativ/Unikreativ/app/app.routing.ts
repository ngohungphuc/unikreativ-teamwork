import { RouterModule, Routes, PreloadAllModules } from '@angular/router'
import { NgModule } from '@angular/core'
import { Error404Component, Error500Component } from './app/modules/index'
import { LoginComponent } from './app/components/login/login.component'
import { AdminComponent } from './app/modules/admin/admin.component'
export const appRoutes: Routes = [
    { path: 'login', component: LoginComponent },
    { path: '', redirectTo: '/login', pathMatch: 'full' },
    { path: '**', redirectTo: '/404', pathMatch: 'full' }
]
@NgModule({
    imports: [RouterModule.forRoot(appRoutes, { preloadingStrategy: PreloadAllModules })],
    exports: [RouterModule]
})

export class AppRoutingModule { }