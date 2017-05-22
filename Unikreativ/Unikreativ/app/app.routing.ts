﻿
import { RouterModule, Routes } from '@angular/router'
import { NgModule } from '@angular/core'
import { Error404Component, Error500Component } from './app/modules/index'
import { LoginComponent } from './app/components/login/login.component'
// import { AdminComponent } from './app/components/admin.component'
import { AuthGuard } from './app/extensions/guard/auth.guard'

export const appRoutes: Routes = [
    { path: 'login', component: LoginComponent },
    // { path: 'admin', component: AdminComponent, canActivate: [AuthGuard] },
    { path: '', redirectTo: '/login', pathMatch: 'full' },
    { path: '**', redirectTo: '/404', pathMatch: 'full' }
]
@NgModule({
    imports: [RouterModule.forRoot(appRoutes)],
    exports: [RouterModule]
})

export class AppRoutingModule { }