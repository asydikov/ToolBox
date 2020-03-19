import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { SqlServerService } from 'src/app/_services/sql-server.service';
import { SqlServer } from 'src/app/_models/sql-server';
import { SqlServerConnection } from 'src/app/_models/sql-server-connection';
import { ResourceLoader } from '@angular/compiler';
import { Router } from '@angular/router';
import { NotificationService } from 'src/app/_services/notification.service';

@Component({
  selector: 'app-server',
  templateUrl: './server.component.html',
  styleUrls: ['./server.component.scss']
})
export class ServerComponent implements OnInit {

  submitted = false;
  loading = false;
  error = '';
  connectionSucceded = false;
  showConnectionStatus = false;
  serverForm: FormGroup;

  constructor(private formBuilder: FormBuilder,
    private router: Router,
    private notificationService: NotificationService,
    private sqlServerService: SqlServerService) {
    this.serverAddedEvent();
  }

  ngOnInit(): void {
    this.serverForm = this.formBuilder.group({
      name: [''],
      host: ['', Validators.required],
      port: ['', Validators.required],
      login: ['', Validators.required],
      password: ['', Validators.required],
      description: ['']
    });
  }

  // convenience getter for easy access to form fields
  get form() { return this.serverForm.controls; }

  connectionCheck() {
    if (this.onSubmitted()) {
      return;
    }
    this.requestModeOn();
    this.sqlServerService.connectionCheck(this.getSqlServerConnection()).subscribe(result => {
      this.connectionSucceded = result['name'] != '';

      this.serverForm.get('name').setValue(result['name']);
      this.requestModeOff();
    }
    );
  }

  add() {
    if (this.onSubmitted()) {
      return;
    }
    this.requestModeOn();
    this.sqlServerService.serverAdd(this.getSqlServer()).subscribe(result => {
    });
  }

  serverAddedEvent() {
    this.notificationService.serverAddedReceived.subscribe(data => {
      this.requestModeOff();
      this.router.navigate(['dashboard']);
    });
  }

  onSubmitted(): boolean {
    this.submitted = true;
    return this.serverForm.invalid;
  }

  requestModeOn() {
    this.loading = true;
    this.showConnectionStatus = false;
  }

  requestModeOff() {
    this.loading = false;
    this.showConnectionStatus = true;
  }

  private getSqlServer(): SqlServer {
    let sqlServer = new SqlServer();
    sqlServer.name = this.form.name.value;
    sqlServer.host = this.form.host.value;
    sqlServer.port = this.form.port.value;
    sqlServer.login = this.form.login.value;
    sqlServer.password = this.form.password.value;
    sqlServer.description = this.form.description.value;
    return sqlServer;

  }

  private getSqlServerConnection(): SqlServerConnection {
    let sqlServerConnection = new SqlServerConnection();
    sqlServerConnection.host = this.form.host.value;
    sqlServerConnection.port = this.form.port.value;
    sqlServerConnection.login = this.form.login.value;
    sqlServerConnection.password = this.form.password.value;
    sqlServerConnection.databaseName = '';
    return sqlServerConnection;

  }
}
