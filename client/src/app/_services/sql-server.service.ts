import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { SqlServerConnection } from '../_models/sql-server-connection';
import { SqlServer } from '../_models/sql-server';

@Injectable({
  providedIn: 'root'
})
export class SqlServerService {

  constructor(private http: HttpClient) { }

  connectionCheck(serverConnection:SqlServerConnection):Observable<boolean>{
    return this.http.post<boolean>(`${environment.apiUrl}/${environment.sqlmonitoryService}/server-connection-check`, serverConnection)
  }

  
  serverAdd(sqlServer:SqlServer){
    return this.http.post(`${environment.apiUrl}/${environment.sqlmonitoryService}/server-add`, sqlServer)
  }
}
