
import { NgModule } from '@angular/core'
import { BrowserModule } from '@angular/platform-browser'
import { RouterModule } from '@angular/router'
import { HttpModule } from '@angular/http'
import { FormsModule, ReactiveFormsModule } from '@angular/forms'
import { AppComponent } from './app.component'
import { Error404Component, Error500Component } from './app/modules/index'
import { LoginComponent } from './app/components/login/login.component'
import { LoginService } from './app/services/index'
import { ServicesModule } from './app/extensions/shared.module'
import { AppRoutingModule } from './app.routing'
import { AdminModule, ErrorsModule } from './app/modules/index'

@NgModule({
    imports: [
        BrowserModule,
        FormsModule,
        ReactiveFormsModule,
        HttpModule,
        ServicesModule,
        AdminModule,
        ErrorsModule,
        AppRoutingModule],
    declarations: [
        AppComponent,
        LoginComponent],
    providers: [
        LoginService
    ],
    bootstrap: [AppComponent]
})

export class AppModule {
}