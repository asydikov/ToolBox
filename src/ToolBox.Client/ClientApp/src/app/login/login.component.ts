import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { IdentityService } from '../_services/identity.service';
import { SignIn } from '../_models/sign-in';
import { first } from 'rxjs/operators';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  submitted = false;
  loading = false;
  error = '';
  loginForm: FormGroup;

  constructor(
    private formBuilder: FormBuilder,
    private router: Router,
    private identityService: IdentityService
  ) {  }

  ngOnInit(): void {
    this.loginForm = this.formBuilder.group({
      email: ['', Validators.compose([Validators.required, Validators.email])],
      password: ['', Validators.required]
    });

    this.identityService.logout();
  }

    // convenience getter for easy access to form fields
    get form() { return this.loginForm.controls; }

  onSubmit() {
    this.submitted = true;
    // stop here if form is invalid
    if (this.loginForm.invalid) {
      return;
    }
    this.loading = true;
    this.identityService.signIn(this.form.email.value, this.form.password.value)
      .pipe(first())
      .subscribe(
        data => {
          if (!data || data['errorCode'] == 'invalid_credentials') {
            this.error = data ? data['message'] : 'Invalid credentials.';
            this.loading = false;
          } else {
            this.router.navigate(['dashboard']);
          }
        },
        error => {
          this.error = error;
          this.loading = false;
        });
  }

}
