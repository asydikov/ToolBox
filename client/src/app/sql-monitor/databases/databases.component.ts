import { Component, OnInit } from '@angular/core';
import { SqlServerService } from 'src/app/_services/sql-server.service';
import { ActivatedRoute } from '@angular/router';
import { DatabaseBadge } from 'src/app/_models/database-badge';
import { NotificationService } from 'src/app/_services/notification.service';

@Component({
  selector: 'app-databases',
  templateUrl: './databases.component.html',
  styleUrls: ['./databases.component.scss']
})
export class DatabasesComponent implements OnInit {

  databaseBadges: DatabaseBadge[];

  constructor(private sqlService: SqlServerService, 
    private routemap: ActivatedRoute,
    private notificationService: NotificationService ) { }

  ngOnInit(): void {
    let serverId = this.routemap.snapshot.paramMap.get('serverId');
    this.getServerDatabases(serverId);
  }
  
  getServerDatabases(serverId: string) {
    this.sqlService.getServerDatabases(serverId).subscribe(data => {
      this.databaseBadges = data;
      this.databaseSpaceUsageEvent();
    });
  }

  databaseSpaceUsageEvent(){
    this.notificationService.databaseSpaceReceived.subscribe(data=>{
     let databaseBadge = this.databaseBadges.find(x=>x.id == data['databaseId']);
     if(!databaseBadge){return}
     databaseBadge.space=data['data'].space;
     databaseBadge.unallocatedSpace = data['data'].unallocatedSpace;
     databaseBadge.unit = data['data'].unit;
     databaseBadge.isAlive = true;
      });
  }
}
