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
}