import { Component, OnInit } from '@angular/core';
import {ErrorStateMatcher} from '@angular/material/core';
import {FormControl, FormGroup, FormGroupDirective, NgForm, Validators} from '@angular/forms';
import { User } from '../user';
@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.scss']
})
export class LoginPageComponent implements OnInit {

  public user: User = {
    email: '',
    password: ''
  };
  emailFormControl = new FormControl('', [
    Validators.required,
    Validators.email,
  ]);

  login: FormGroup = new FormGroup({
    email: new FormControl('', [Validators.email, Validators.required ]),
    password: new FormControl('', [Validators.required, Validators.min(3) ])
  });
  hide = true;
  get emailInput() { return this.login.get('email'); }
  get passwordInput() { return this.login.get('password'); }

  constructor() { }

  ngOnInit(): void {

  }
  logIn(): void {
    this.user.email = this.emailInput.value;
    this.user.password = this.passwordInput.value;
    console.log('email', this.user.email);

  }



}
