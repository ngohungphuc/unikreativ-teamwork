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
import { ErrorsModule } from './app/modules/errors/errors.module'
import { AuthGuard } from './app/extensions/guard/auth.guard'
import { AppRoutingModule } from './app.routing'
@NgModule({
    imports: [
        BrowserModule,
        FormsModule,
        ReactiveFormsModule,
        HttpModule,
        ServicesModule,
        // AdminModule,
        ErrorsModule,
        AppRoutingModule],
    declarations: [
        AppComponent,
        LoginComponent],
    providers: [
        LoginService,
        AuthGuard
    ],
    bootstrap: [AppComponent]
})

export class AppModule {
}