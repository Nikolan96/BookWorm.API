import { Component, OnInit } from '@angular/core';
import {
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { LoginService } from '../login.service';
import { Router } from '@angular/router';
import { UserLogin } from '../userLogin';

@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.scss'],
})
export class LoginPageComponent implements OnInit {
  public user: UserLogin = {
    email: '',
    password: '',
  };

  login: FormGroup = new FormGroup({
    email: new FormControl('', [Validators.email, Validators.required]),
    password: new FormControl('', [Validators.required, Validators.min(3)]),
  });
  hide = true;

  singup: FormGroup = new FormGroup(
    {
      emailSingUp: new FormControl('', [Validators.email, Validators.required]),
      passwordSingUp: new FormControl('', [
        Validators.required,
        Validators.min(3),
      ]),
      confirmPassword: new FormControl('', [
        Validators.required,
        Validators.min(3),
      ]),

    }
  );

  get emailInput() {
    return this.login.get('email');
  }
  get passwordInput() {
    return this.login.get('password');
  }
  get emailInputSingup() {
    return this.singup.get('emailSingUp');
  }
  get passwordInputSingUp() {
    return this.singup.get('passwordSingUp');
  }
  get passwordInputConfirm() {
    return this.singup.get('confirmPassword');
  }
  constructor(private loginService: LoginService, private router: Router) {}

  ngOnInit(): void {}

  logIn(): void {
    this.loginService.login(this.login.value).subscribe(
      (response) => {
        this.router.navigate(['home-page']);
      },
      (error) => {
        const wrongCredentials = document.getElementById(
          'wrongData'
        ) as HTMLDivElement;
        wrongCredentials.innerHTML = error.error;
        console.log(error.error);
      }
    );
  }
  singUp(): void {
    if (this.checkPasswords) {
      console.log('cao');
    }
  }

  checkPasswords(): boolean {
    if (this.passwordInputSingUp.value === this.passwordInputConfirm.value) {
      return true;
    } else {
      return false;
    }
  }
}
