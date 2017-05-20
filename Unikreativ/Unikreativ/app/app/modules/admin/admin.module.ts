import { NgModule } from '@angular/core'
import { CommonModule } from '@angular/common'
import { RouterModule } from '@angular/router'
import { FormsModule, ReactiveFormsModule } from '@angular/forms'
import { DashboardComponent, adminRoutes } from './index'
import { AuthGuard } from './../../extensions/guard/auth.guard'
import { AdminRouting } from './admin.routes'
@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    AdminRouting
  ],
  declarations: [
    DashboardComponent
  ],
  providers: [
    AuthGuard
  ]
})
export class AdminModule { }