import { Component, OnInit, Input } from '@angular/core';
import { DatabaseBadge } from 'src/app/_models/database-badge';

@Component({
  selector: 'app-database',
  templateUrl: './database.component.html',
  styleUrls: ['./database.component.scss']
})
export class DatabaseComponent implements OnInit {

@Input() databaseBadge: DatabaseBadge;

  constructor() { }

  ngOnInit(): void {
  }

}
