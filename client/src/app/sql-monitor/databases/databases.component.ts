import { Component, OnInit } from '@angular/core';
import { SqlServerService } from 'src/app/_services/sql-server.service';
import { ActivatedRoute } from '@angular/router';
import { DatabaseBadge } from 'src/app/_models/database-badge';

@Component({
  selector: 'app-databases',
  templateUrl: './databases.component.html',
  styleUrls: ['./databases.component.scss']
})
export class DatabasesComponent implements OnInit {

  databaseBadges: DatabaseBadge[];

  constructor(private sqlService: SqlServerService, private routemap: ActivatedRoute) { }

  ngOnInit(): void {
    let serverId = this.routemap.snapshot.paramMap.get('serverId');
    this.getServerDatabases(serverId);
  }
  getServerDatabases(serverId: string) {
    this.sqlService.getServerDatabases(serverId).subscribe(data => {
      this.databaseBadges = data;
    });
  }

}
