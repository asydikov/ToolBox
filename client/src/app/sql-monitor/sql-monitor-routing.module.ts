import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DashboardComponent } from './dashboard/dashboard.component';
import { ServerComponent } from './server/server.component';
import { DatabaseComponent } from './database/database.component';
import { ServerBadgeComponent } from './server/server-badge/server-badge.component';


const routes: Routes = [
 
  { path: '' , component: DashboardComponent,data: { title: 'Dashboard' }},
  { path: 'servers/add', component: ServerComponent, data: { title: 'Monitored Servers' }},
  { path: 'database', component: DatabaseComponent, data: { title: 'Monitored Servers' }},
  { path: 'server', component: ServerBadgeComponent, data: { title: 'Monitored Server' }},
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SqlMonitorRoutingModule { }
