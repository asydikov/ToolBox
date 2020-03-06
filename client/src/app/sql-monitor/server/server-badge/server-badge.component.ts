import { Component, OnInit, Input } from '@angular/core';
import { SqlServer } from 'src/app/_models/sql-server';

@Component({
  selector: 'app-server-badge',
  templateUrl: './server-badge.component.html',
  styleUrls: ['./server-badge.component.scss']
})
export class ServerBadgeComponent implements OnInit {

  @Input() server: SqlServer;

  constructor() { }

  ngOnInit(): void {
  }

}
