export class DatabaseBadge{
     id:string;
         name:string;
         fullBackupTime:Date;
         differentialBackupTime:Date;
         transactionLogBackupTime:Date;
         recoveryModel:string;
         space:number;
         unallocatedSpace:number;
         unit :string;
         isAlive:false;
}