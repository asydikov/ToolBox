import { Component } from '@angular/core';
import { IdentityService } from './_services/identity.service';
import { User } from './_models/user';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  currentUser: User;
  
  constructor(private identityService: IdentityService) {
      this.identityService.currentUser.subscribe(user => this.currentUser = user);
     }
}




