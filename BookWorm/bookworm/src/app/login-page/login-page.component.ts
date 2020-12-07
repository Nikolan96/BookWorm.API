import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { LoginService } from '../login.service';
import { Router } from '@angular/router';
import { UserLogin } from '../userLogin';
import { ValueConverter } from '@angular/compiler/src/render3/view/template';

@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.scss'],
})
export class LoginPageComponent implements OnInit {
  email: string;
  check: boolean;
  public user: UserLogin = {
    email: '',
    password: '',
  };
  login: FormGroup = new FormGroup({
    email: new FormControl('', [Validators.email, Validators.required]),
    password: new FormControl('', [Validators.required, Validators.min(3)]),
  });
  hide = true;

  singup: FormGroup = new FormGroup({
    emailSingUp: new FormControl('', [Validators.email, Validators.required]),
    passwordSingUp: new FormControl('', [
      Validators.required,
      Validators.min(3),
    ]),
    confirmPassword: new FormControl('', [
      Validators.required,
      Validators.min(3),
    ]),
  });

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
        this.router.navigate([`/home-page/${response.id}`]);
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
    this.email = this.emailInputSingup.value;
    console.log(this.email);
    this.loginService.checkIfEmailExists(this.email).subscribe(
      (response) => {
        if (response === true) {
          console.log('User already exists');
        } else {
          localStorage.setItem('email', this.emailInputSingup.value);
          this.router.navigate(['registration-page']);
        }
      },
      (error) => {
        console.log(error.error);
      }
    );
  }


}
