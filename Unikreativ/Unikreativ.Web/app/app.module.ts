import { NgModule } from '@angular/core'
import { BrowserModule } from '@angular/platform-browser'
import { RouterModule } from '@angular/router'
import { HttpModule } from '@angular/http'
import { FormsModule, ReactiveFormsModule } from '@angular/forms'
import { AppComponent } from './app.component'
import { LoginComponent } from './app/components/login/login.component'
import { Error404Component } from './app/components/errors/404.component'
import { Error500Component } from './app/components/errors/500.component'
import { appRoutes } from './routes/routes'
import './app/extensions/rxjs-extensions'
import { LoginService } from './app/services/index'
@NgModule({
    imports: [
        BrowserModule,
        FormsModule,
        ReactiveFormsModule,
        HttpModule,
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