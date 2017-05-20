import { Routes, RouterModule } from '@angular/router'
import { Error404Component } from '../app/components/errors/404.component'
import { Error500Component } from '../app/components/errors/500.component'
import { LoginComponent } from '../app/components/login/login.component'
export const appRoutes: Routes = [
    { path: 'login', component: LoginComponent },
    { path: '404', component: Error404Component },
    { path: '500', component: Error500Component },
    { path: '', component: LoginComponent },
    { path: '**', redirectTo: '/404', pathMatch: 'full' }
    // { path: 'user', loadChildren: 'app/user/user.module#UserModule' }
    // { path: 'events/new', component: CreateEventComponent, canDeactivate: ['canDeactivateCreateEvent'] },
]

export const Routing = RouterModule.forRoot(appRoutes)