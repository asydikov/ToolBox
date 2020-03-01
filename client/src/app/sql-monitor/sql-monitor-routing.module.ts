import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DashboardComponent } from './dashboard/dashboard.component';
import { ServerComponent } from './server/server.component';
import { DatabaseComponent } from './database/database.component';


const routes: Routes = [
 
  { path: '' , component: DashboardComponent},
  { path: 'server', component: ServerComponent, data: { title: 'Servers' },},
  { path: 'database', component: DatabaseComponent, data: { title: 'Databases' },},
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SqlMonitorRoutingModule { }
