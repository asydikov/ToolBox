import { Component, OnInit } from '@angular/core';
import { NotificationService } from 'src/app/_services/notification.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {

  constructor(private notificationService: NotificationService) {
    notificationService.messageReceived.subscribe(msg=>{
      console.log(msg);

    })
   }

  ngOnInit(): void {
  }

}
