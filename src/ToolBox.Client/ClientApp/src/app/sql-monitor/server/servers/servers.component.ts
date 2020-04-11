import { Component, OnInit, Input } from '@angular/core';
import { SqlServerService } from 'src/app/_services/sql-server.service';
import { SqlServer } from 'src/app/_models/sql-server';
import { SqlServerBadge } from 'src/app/_models/sql-server-badge';

@Component({
  selector: 'app-servers',
  templateUrl: './servers.component.html',
  styleUrls: ['./servers.component.scss']
})
export class ServersComponent implements OnInit {
  @Input() sqlServerBadges: SqlServerBadge[];
  constructor() { }

  ngOnInit(): void {
  }

}
