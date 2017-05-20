import { DashboardComponent } from './index'
import { AuthGuard } from './../../extensions/guard/auth.guard'
import { Routes, RouterModule } from '@angular/router'
export const adminRoutes = [
  { path: 'dashboard', component: DashboardComponent, canActivate: [AuthGuard]  }
]

export const AdminRouting = RouterModule.forRoot(adminRoutes)