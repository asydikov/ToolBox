import { Component, OnInit, OnDestroy } from '@angular/core';
import { NotificationService } from 'src/app/_services/notification.service';
import { Router } from '@angular/router';
import { SqlServerService } from 'src/app/_services/sql-server.service';
import { SqlServerBadge } from 'src/app/_models/sql-server-badge';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {
  sqlServerBadges: SqlServerBadge[];
  constructor(private notificationService: NotificationService, private sqlService: SqlServerService) {
  }

  ngOnInit(): void {
    this.sqlService.getDashboard().subscribe(data => {
      this.sqlServerBadges = data;
    });
    this.userConnectionsEvent();
    this.serverMemoryUsageEvent();
    this.serverUnreachableEvent();
  }

  userConnectionsEvent() {
    this.notificationService.connectedUsersReceived.subscribe(data => {
      if(!this.sqlServerBadges)
        return;
      let server = this.sqlServerBadges.find(x => x.serverId == data['serverId']);
      if (server == undefined || server.connectedUsers == undefined)
          return;
      server.connectedUsers = data['data'].length ?? 0;
      server.isAlive = true;
    });
  }

  serverMemoryUsageEvent() {
    this.notificationService.serverMemoryUsageReceived.subscribe(data => {
      let server = this.sqlServerBadges.find(x => x.serverId == data['serverId']);
      if (server == undefined || server.pageReadsCount== undefined)
          return;
      server.pageReadsCount = data['data']?.pageReadsCount ?? 0;
      server.pageLifetime = data['data']?.pageLifetime ?? 0;
      server.isAlive = true;
    });
  }

  serverUnreachableEvent() {
    this.notificationService.serverUnreachableReceived.subscribe(data => {
      let server = this.sqlServerBadges.find(x => x.serverId == data['serverId']);
      if (server) {
        server.isAlive = false;
      }

    });
  }
}
