export class SqlServerBadge{
     serverId:string;
     name:string;
     serverAddress:string; 
     description :string;
     pageReadsCount :number = 0;
     requestCount :number = 0;
     pageLifetime :number = 0;
     connectedUsers:number = 0;
     isAlive:boolean = true;

     /**
      *
      */
     constructor() {
     this.name ='';
     this.serverAddress =''; 
     this.description='';
     this.pageReadsCount = 0;
     this.requestCount  = 0;
     this.pageLifetime = 0;
     this.connectedUsers = 0;
     this.isAlive = true;
     }
}