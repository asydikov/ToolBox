import { Component, OnInit } from '@angular/core';
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
  constructor(private notificationService: NotificationService, private sqlService:SqlServerService, 
     private router: Router) {
   }

  ngOnInit(): void {
    this.sqlService.getDashboard().subscribe(data=>{
      this.sqlServerBadges = data;
    });
    this.userConnectionsEvent();
    this.serverMemoryUsageEvent();
    this.serverUnreachableEvent();
  }

 userConnectionsEvent(){
   this.notificationService.connectedUsersReceived.subscribe(data=>{
    let server = this.sqlServerBadges.find(x=>x.serverId == data['serverId']);
    server.connectedUsers = data['data'].length;
    server.isAlive = true;
   });
 }

 serverMemoryUsageEvent(){
  this.notificationService.serverMemoryUsageReceived.subscribe(data=>{
 let server = this.sqlServerBadges.find(x=>x.serverId == data['serverId']);
 server.pageReadsCount=data['data'].pageReadsCount;
 server.pageLifetime = data['data'].pageLifetime;
 server.isAlive = true;
  });
}

serverUnreachableEvent(){
  this.notificationService.serverUnreachableReceived.subscribe(data=>{
    let server = this.sqlServerBadges.find(x=>x.serverId == data['serverId']);
    if(server){
      server.isAlive = false;
    }
    
  });
}
}
