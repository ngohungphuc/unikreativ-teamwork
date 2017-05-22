import { AuthGuard } from './app/extensions/guard/auth.guard'

import { AppRoutingModule } from './app.routing'
import { NgModule } from '@angular/core'
import { BrowserModule } from '@angular/platform-browser'
import { RouterModule } from '@angular/router'
import { HttpModule } from '@angular/http'
import { FormsModule, ReactiveFormsModule } from '@angular/forms'
import { AppComponent } from './app.component'
import { LoginComponent, Error404Component, Error500Component } from './app/components/index'
import { LoginService } from './app/services/index'
import { ServicesModule } from './app/extensions/shared.module'
import { AdminComponent } from './app/components/admin.component'
@NgModule({
    imports: [
        BrowserModule,
        FormsModule,
        ReactiveFormsModule,
        HttpModule,
        ServicesModule,
        // AdminModule,
        AppRoutingModule],
    declarations: [
        AppComponent,
        LoginComponent,
        AdminComponent,
        Error404Component,
        Error500Component],
    providers: [
        LoginService,
        AuthGuard
    ],
    bootstrap: [AppComponent]
})

export class AppModule {
}