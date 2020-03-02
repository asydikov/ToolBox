import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DashboardComponent } from './dashboard/dashboard.component';
import { ServerComponent } from './server/server.component';
import { DatabaseComponent } from './database/database.component';


const routes: Routes = [
 
  { path: '' , component: DashboardComponent,data: { title: 'Dashboard' }},
  { path: 'server', component: ServerComponent, data: { title: 'Monitored Servers' }},
  { path: 'database', component: DatabaseComponent, data: { title: 'Monitored Servers' }},
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SqlMonitorRoutingModule { }
