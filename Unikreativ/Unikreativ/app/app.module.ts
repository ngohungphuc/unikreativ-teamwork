﻿import { NgModule } from '@angular/core'
import { BrowserModule } from '@angular/platform-browser'
import { RouterModule } from '@angular/router'
import { HttpModule } from '@angular/http'
import { FormsModule, ReactiveFormsModule } from '@angular/forms'
import { AppComponent } from './app.component'
import { LoginComponent } from './app/components/login/login.component'
import { Error404Component,Error500Component } from './app/components/errors/index'
import { appRoutes } from './routes/routes'
import { LoginService } from './app/services/index'
import { AdminModule } from './app/modules/admin/admin.module'
import { ServicesModule } from './app/extensions/shared.module'

@NgModule({
    imports: [
        BrowserModule,
        FormsModule,
        ReactiveFormsModule,
        HttpModule,
        ServicesModule,
        AdminModule,
        RouterModule.forRoot(appRoutes)],
    declarations: [
        AppComponent,
        LoginComponent,
        Error404Component,
        Error500Component],
    providers:[
        LoginService
    ],
    bootstrap: [AppComponent]
})

export class AppModule {
}