import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DashboardComponent } from './dashboard/dashboard.component';
import { ServerComponent } from './server/server.component';
import { DatabaseComponent } from './database/database.component';



@NgModule({
  declarations: [DashboardComponent, ServerComponent, DatabaseComponent],
  imports: [
    CommonModule
  ]
})
export class SqlMonitorModule { }
