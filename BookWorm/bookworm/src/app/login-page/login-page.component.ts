import { Component, OnInit } from '@angular/core';
import { ErrorStateMatcher } from '@angular/material/core';
import {
  FormControl,
  FormGroup,
  FormGroupDirective,
  NgForm,
  Validators,
} from '@angular/forms';
import { User } from '../user';
import { LoginService } from '../login.service';
import { Router } from '@angular/router';
import { createComponent } from '@angular/compiler/src/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.scss'],
})
export class LoginPageComponent implements OnInit {
  public user: User = {
    adress: '',
    addressId: '',
    cases: '',
    dateOfBirth: null,
    email: '',
    firstName: '',
    gender: '',
    id: '',
    lastName: '',
    password: '',
    userBookNotes: '',
    userReviews: '',
  };
  emailFormControl = new FormControl('', [
    Validators.required,
    Validators.email,
  ]);

  login: FormGroup = new FormGroup({
    email: new FormControl('', [Validators.email, Validators.required]),
    password: new FormControl('', [Validators.required, Validators.min(3)]),
  });
  hide = true;
  get emailInput() {
    return this.login.get('email');
  }
  get passwordInput() {
    return this.login.get('password');
  }

  constructor(private loginService: LoginService, private router: Router) {}

  ngOnInit(): void {}
  logIn(): void {
    this.user.email = this.emailInput.value;
    this.user.password = this.passwordInput.value;

    this.loginService.getUsers().subscribe((user) => {
      console.log(user);
      user.forEach((element) => {
        if (
          element.email === this.user.email &&
          element.password === this.user.password
        ) {
          console.log('sve se poklapa');
          this.router.navigate(['/home-page']);
        } else {
          let wrongCredentials =  document.getElementById("wrongData") as HTMLDivElement;
          wrongCredentials.innerHTML = 'Wrong Credentials. Invalid username or password';

        }
      });
    });
  }
}
