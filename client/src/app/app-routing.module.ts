import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { SqlMonitorModule } from './sql-monitor/sql-monitor.module';


const routes: Routes = [
 
  { path: '', redirectTo: 'login', pathMatch: 'full' },
   { path: 'login', component: LoginComponent },
   {
    path: 'sqlmonitor',

    loadChildren: () => import('./sql-monitor/sql-monitor.module').then(m => m.SqlMonitorModule)
  }   
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
