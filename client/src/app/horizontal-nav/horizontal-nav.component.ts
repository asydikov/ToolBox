import { Component, OnInit } from '@angular/core';
import { Router, NavigationEnd, ActivatedRoute } from '@angular/router';
import { filter,map, mergeMap } from 'rxjs/operators';
import { User } from '../_models/User';
import { IdentityService } from '../_services/identity.service';

@Component({
  selector: 'app-horizontal-nav',
  templateUrl: './horizontal-nav.component.html',
  styleUrls: ['./horizontal-nav.component.scss']
})
export class HorizontalNavComponent implements OnInit {
title:string = 'Dashboard';
currentUser: User;
  constructor(private router:Router,
    private activatedRoute:ActivatedRoute,
    private identityService: IdentityService ) { 
      this.identityService.currentUser.subscribe(user => this.currentUser = user);
    }

  ngOnInit(): void {
    this.router.events.pipe(
      filter((event) => event instanceof NavigationEnd),
      map(() => this.activatedRoute),
      map((route) => {
        while (route.firstChild) route = route.firstChild;
        return route;
      }),
      filter((route) => route.outlet === 'primary'),
      mergeMap((route) => route.data),
    ).subscribe((data) => {
      this.title = data['title'];
    })
  }

}
