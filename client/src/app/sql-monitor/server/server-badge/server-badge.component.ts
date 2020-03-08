import { Component, OnInit, Input } from '@angular/core';
import { SqlServerBadge } from 'src/app/_models/sql-server-badge';
import { Router } from '@angular/router';

@Component({
  selector: 'app-server-badge',
  templateUrl: './server-badge.component.html',
  styleUrls: ['./server-badge.component.scss']
})
export class ServerBadgeComponent implements OnInit {

  @Input() server: SqlServerBadge;
  constructor( private router: Router) { }

  ngOnInit(): void {
  }

  goToDatabases(){
    this.router.navigate(['dashboard/databases'] );
  }
}
