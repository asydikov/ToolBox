import { Database } from './database';

export class SqlServer{
id:string;
userId:string;
name:string;
host:string;
port:number;
login:string;
password:string;
description:string;
databases: Database[];

/**
 *
 */
constructor() {
    
}
}
