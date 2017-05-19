import { DashboardComponent } from './index'
import { AuthGuard } from './../../extensions/guard/auth.guard'

export const adminRoutes = [
  { path: 'dashboard', component: DashboardComponent, canActivate: [AuthGuard]  }
]