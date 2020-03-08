import { Component, OnInit } from '@angular/core';
import { SqlServerService } from 'src/app/_services/sql-server.service';
import { TimeConsumingQueries } from 'src/app/_models/time-consuming-queries';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-queries',
  templateUrl: './queries.component.html',
  styleUrls: ['./queries.component.scss']
})
export class QueriesComponent implements OnInit {

  queries: TimeConsumingQueries[];

  constructor(private sqlService: SqlServerService, private routemap: ActivatedRoute) { }

  ngOnInit(): void {
    let serverId= this.routemap.snapshot.paramMap.get('serverId');
      this.getTimeConsumingQueries(serverId);

  }

  getTimeConsumingQueries(serverId: string) {
    this.sqlService.getTimeConsumingQueries(serverId).subscribe(data => {
      this.queries = data;
    });
  }
}
