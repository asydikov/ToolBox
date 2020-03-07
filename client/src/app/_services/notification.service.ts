import { Injectable, EventEmitter } from '@angular/core';
import { HubConnection, HubConnectionBuilder, HttpTransportType } from '@aspnet/signalr';  
import { IdentityService } from './identity.service';

@Injectable({
  providedIn: 'root'
})
export class NotificationService {

  messageReceived = new EventEmitter<any>();  
  connectedUsersReceived = new EventEmitter<any>();  
  serverMemoryUsageReceived= new EventEmitter<any>();  
  connectionEstablished = new EventEmitter<Boolean>();  
  
  private connectionIsEstablished = false;  
  private _hubConnection: HubConnection;  
  
  constructor(private identityService: IdentityService) {  
    this.createConnection();  
    this.registerOnServerEvents();  
    this.startConnection();  
    
  }  
  
  sendMessage(message: any) {  
    this._hubConnection.invoke('NewMessage', message);  
  }  
  
  private createConnection() {  
    this._hubConnection = new HubConnectionBuilder()  
      .withUrl('http://localhost:5050/notification', {
        skipNegotiation:true,
        transport: HttpTransportType.WebSockets
      })  
      .build();  
  }  
  
  private startConnection(): void {  
    this._hubConnection  
      .start()  
      .then(() => {  
        this._hubConnection.invoke('initializeAsync',this.identityService.accesTokenFromLocalStorage);
        this.connectionIsEstablished = true;  
        console.log('Hub connection started');  
        this.connectionEstablished.emit(true);  
      })  
      .catch(err => {  
        console.log('Error while establishing connection, retrying...');  
        setTimeout(function () { this.startConnection(); }, 5000);  
      });  
  }  
  
  private registerOnServerEvents(): void {  
  // this.operationCompletedEvent();
   this.serverMemoryUsageEvent();
   this.connectedUsersEvent();
   //this.databaseSpaceEvent();
  };

  private operationCompletedEvent(): void {  
    this._hubConnection.on('operation_completed', (operation) => {
      console.log(operation);
    this.messageReceived.emit(operation);
    });
  }  
  private serverMemoryUsageEvent(): void {  
    this._hubConnection.on('server-memory-usage-metrics', (operation) => {
    this.serverMemoryUsageReceived.emit(operation);
    });
  }  


  private connectedUsersEvent(): void {  
    this._hubConnection.on('connected_users_metrics', (operation) => {
    this.connectedUsersReceived.emit(operation);
    });
  }  

  private databaseSpaceEvent(): void {  
    this._hubConnection.on('database-space-metrics', (operation) => {
      console.log(operation);
    this.messageReceived.emit(operation);
    });
  }  
  

  // this._hubConnection.on('operation_rejected', (operation) => {
  //     appendMessage('Operation rejected.', "danger", operation);
  // });
  //}  
}
