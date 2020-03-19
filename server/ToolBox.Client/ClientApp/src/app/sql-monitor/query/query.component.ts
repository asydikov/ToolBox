import { Component, OnInit, Input } from '@angular/core';
import { TimeConsumingQueries } from 'src/app/_models/time-consuming-queries';

@Component({
  selector: 'app-query',
  templateUrl: './query.component.html',
  styleUrls: ['./query.component.scss']
})
export class QueryComponent implements OnInit {

  @Input() query: TimeConsumingQueries;

  constructor() { }

  ngOnInit(): void {
  }

}
