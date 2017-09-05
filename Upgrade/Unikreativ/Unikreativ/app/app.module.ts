import { AdminModule, ErrorsModule, EventModule } from './app/modules/index'
import { AppComponent } from './app.component'
import { AppRoutingModule } from './app.routing'
import { BrowserModule } from '@angular/platform-browser'
import { FormsModule, ReactiveFormsModule } from '@angular/forms'
import { HttpModule } from '@angular/http'
import { LoginComponent } from './app/components/login/login.component'
import { LoginService } from './app/services/index'
import { NavModule } from './app/modules/template/nav.module'
import { NgModule } from '@angular/core'
import { RouterModule } from '@angular/router'
import { ServicesModule } from './app/extensions/shared.module'

@NgModule({
    imports: [
        BrowserModule,
        FormsModule,
        ReactiveFormsModule,
        HttpModule,
        ServicesModule,
        NavModule,
        AdminModule,
        EventModule,
        ErrorsModule,
        AppRoutingModule
    ],
    declarations: [
        AppComponent,
        LoginComponent,
    ],
    providers: [
        LoginService
    ],
    bootstrap: [AppComponent]
})

export class AppModule {
}