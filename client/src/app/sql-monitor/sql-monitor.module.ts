import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DashboardComponent } from './dashboard/dashboard.component';
import { ServerComponent } from './server/server.component';
import { SqlMonitorRoutingModule } from './sql-monitor-routing.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ServersComponent } from './server/servers/servers.component';
import { ServerBadgeComponent } from './server/server-badge/server-badge.component';
import { DatabaseComponent } from './databases/database/database.component';
import { QueryComponent } from './query/query.component';
import { QueriesComponent } from './query/queries/queries.component';
import { DatabasesComponent } from './databases/databases.component';



@NgModule({
  declarations: [
    DashboardComponent, 
    ServerComponent,
     DatabaseComponent,
     ServersComponent,
     ServerBadgeComponent,
     QueryComponent,
     QueriesComponent,
     DatabasesComponent
    ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    SqlMonitorRoutingModule
  ]
})
export class SqlMonitorModule { }
