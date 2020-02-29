import { Component, OnInit } from '@angular/core';
import { IdentityService } from '../_services/identity.service';
import { Router } from '@angular/router';
import { User } from '../_models/User';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.scss']
})
export class NavComponent implements OnInit {

  currentUser: User;
  
  constructor(private router: Router,
    private identityService: IdentityService) {
      this.identityService.currentUser.subscribe(user => this.currentUser = user);
     }

  ngOnInit(): void {
  }

  logout() {
    this.identityService.logout();
    this.router.navigate(['/login']);
  }

}
