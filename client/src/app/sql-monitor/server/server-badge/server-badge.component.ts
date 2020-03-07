import { Component, OnInit, Input } from '@angular/core';
import { SqlServerBadge } from 'src/app/_models/sql-server-badge';

@Component({
  selector: 'app-server-badge',
  templateUrl: './server-badge.component.html',
  styleUrls: ['./server-badge.component.scss']
})
export class ServerBadgeComponent implements OnInit {

  @Input() server: SqlServerBadge;
  @Input()pageReadsCounts:number;
  @Input()pageLifetime:number;
  constructor() { }

  ngOnInit(): void {
  }

}
