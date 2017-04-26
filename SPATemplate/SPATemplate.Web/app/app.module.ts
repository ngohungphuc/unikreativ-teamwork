import { NgModule } from '@angular/core'
import { BrowserModule } from '@angular/platform-browser'
import { RouterModule } from '@angular/router'
import { AppComponent } from './app.component'
import { LoginComponent } from './app/components/login/login.component'
import { Error404Component } from './app/components/errors/404.component'
import { Error500Component } from './app/components/errors/500.component'
import { appRoutes } from './routes/routes'

@NgModule({
    imports: [
        BrowserModule,
        RouterModule.forRoot(appRoutes)],
    declarations: [
        AppComponent,
        LoginComponent,
        Error404Component,
        Error500Component],
    bootstrap: [AppComponent]
})

export class AppModule {
}