import { Component, OnInit } from '@angular/core';
import { SqlServerService } from 'src/app/_services/sql-server.service';
import { SqlServer } from 'src/app/_models/sql-server';

@Component({
  selector: 'app-servers',
  templateUrl: './servers.component.html',
  styleUrls: ['./servers.component.scss']
})
export class ServersComponent implements OnInit {

  servers:SqlServer[]
  constructor(private sqlServerService: SqlServerService) { }

  ngOnInit(): void {
    this.getUserServers();
  }

  getUserServers(){
    this.sqlServerService.getServers().subscribe(servers=>{
      this.servers = servers;
    });
  }
}
