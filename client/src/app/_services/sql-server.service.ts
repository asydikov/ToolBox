import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { SqlServerConnection } from '../_models/sql-server-connection';
import { SqlServer } from '../_models/sql-server';
import { SqlServerBadge } from '../_models/sql-server-badge';
import { TimeConsumingQueries } from '../_models/time-consuming-queries';

@Injectable({
  providedIn: 'root'
})
export class SqlServerService {

  constructor(private http: HttpClient) { }

  connectionCheck(serverConnection:SqlServerConnection){
    return this.http.post(`${environment.apiUrl}/${environment.sqlmonitoryService}/server-connection-check`, serverConnection)
  }
  
  serverAdd(sqlServer:SqlServer){
    return this.http.post(`${environment.apiUrl}/${environment.sqlmonitoryService}/server-add`, sqlServer)
  }
  
  getDashboard(){
    return this.http.get<SqlServerBadge[]>(`${environment.apiUrl}/${environment.sqlmonitoryService}/dashboard`)
  }

  getServers(){
    return this.http.get<SqlServer[]>(`${environment.apiUrl}/${environment.sqlmonitoryService}/servers`)
  }

  getTimeConsumingQueries(serverId: string){
    return this.http.post<TimeConsumingQueries[]>(`${environment.apiUrl}/${environment.sqlmonitoryService}/time-consuming-queries`, {id: serverId})
  }
}
