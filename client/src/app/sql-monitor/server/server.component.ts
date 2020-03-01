import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-server',
  templateUrl: './server.component.html',
  styleUrls: ['./server.component.scss']
})
export class ServerComponent implements OnInit {

  submitted = false;
  loading = false;
  error = '';
  serverForm: FormGroup;

  constructor( private formBuilder: FormBuilder) { }

  ngOnInit(): void {
    this.serverForm = this.formBuilder.group({
      name: ['', Validators.required],
      host: ['', Validators.required],
      port: ['',Validators.required],
      login: ['', Validators.required],
      password: ['',Validators.required],
      description: ['']
    });
  }

  // convenience getter for easy access to form fields
  get form() { return this.serverForm.controls; }

}
