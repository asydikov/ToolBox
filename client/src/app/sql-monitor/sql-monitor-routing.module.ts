import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DashboardComponent } from './dashboard/dashboard.component';
import { ServerComponent } from './server/server.component';
import { ServerBadgeComponent } from './server/server-badge/server-badge.component';
import { DatabasesComponent } from './databases/databases.component';
import { DatabaseComponent } from './databases/database/database.component';
import { QueriesComponent } from './query/queries/queries.component';

const routes: Routes = [
 
  { path: '' , component: DashboardComponent,data: { title: 'Dashboard' }},
  { path: 'servers/add', component: ServerComponent, data: { title: 'Adding SQL Server Instance' }},
  { path: 'server/databases/:serverId', component: DatabasesComponent, data: { title: 'Monitored Databases' }},
  { path: 'database', component: DatabaseComponent, data: { title: 'Monitored Database' }},
  { path: 'server', component: ServerBadgeComponent, data: { title: 'Monitored Server' }},
  { path: 'server/queries/:serverId', component: QueriesComponent, data: { title: 'Time consuming queries' }},
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SqlMonitorRoutingModule { }
