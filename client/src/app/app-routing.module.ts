import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './login/login.component';


const routes: Routes = [
  {
    path: 'sqlmonitor',
    loadChildren: () => import('./sql-monitor/sql-monitor.module').then(m => m.SqlMonitorModule)
  },
  { path: '', redirectTo: '', pathMatch: 'full' },
  // { path: 'cards', component: CardComponent, canActivate: [AuthGuard] },
  // { path: 'notes', component: NoteComponent, canActivate: [AuthGuard] },
  // { path: 'notes/:id', component: NoteComponent, canActivate: [AuthGuard] },
   { path: 'login', component: LoginComponent },
  // { path: 'regirstration', component: RegisterComponent },
  // { path: '**', component: CardComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
