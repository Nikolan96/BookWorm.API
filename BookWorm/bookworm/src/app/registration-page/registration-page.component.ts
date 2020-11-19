import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import countriesJson from '../../assets/countries.json';
import { Registration } from '../registration';
import { LoginService } from '../login.service';

@Component({
  selector: 'app-registration-page',
  templateUrl: './registration-page.component.html',
  styleUrls: ['./registration-page.component.scss'],
})
export class RegistrationPageComponent implements OnInit {
  public registration: Registration = {
    UserRegistration: {
      firstName: '',
      lastName: '',
      email: '',
      password: '',
      gender: '',
      dateOfBirth: null,
    },
    Address: {
      line1: '',
      city: '',
      country: '',
    },
  };
  gender = ['Female', 'Male'];
  isLinear = false;
  firstFormGroup: FormGroup;
  secondFormGroup: FormGroup;
  thirdFormGroup: FormGroup;
  countries: any[];
  email: string;
  hide = true;
  constructor(
    private httpService: HttpClient,
    private formBuilder: FormBuilder,
    private loginService: LoginService
  ) {}

  ngOnInit(): void {
    this.email = localStorage.getItem('email');
    this.countries = countriesJson;

    this.firstFormGroup = this.formBuilder.group({
      firstname: ['', Validators.required],
      lastname: ['', Validators.required],
      gender: ['', Validators.required],
      date: ['', Validators.required],
    });
    this.secondFormGroup = this.formBuilder.group({
      address: ['', Validators.required],
      city: ['', Validators.required],
      country: ['', Validators.required],
    });
    this.thirdFormGroup = this.formBuilder.group({
      email: ['', Validators.required],
      password: ['', Validators.required, Validators.min(3)],
      confirmPassword: ['', Validators.required, Validators.min(3)],
    });
  }

  get passwordInput() {
    return this.thirdFormGroup.get('password');
  }

  get passwordInputConfirm() {
    return this.thirdFormGroup.get('confirmPassword');
  }

  finishRegistration(): void {
    this.fillOutForm();
    console.log(this.registration);
    this.loginService.register(this.registration).subscribe(
      (response) => {
        console.log('radi');
      },
      (error) => {
        console.log(error.error);
      }
    );
  }

  fillOutForm(): void {
    this.registration.UserRegistration.firstName = this.firstFormGroup.value.firstname;
    this.registration.UserRegistration.lastName = this.firstFormGroup.value.lastname;
    this.registration.UserRegistration.gender = this.firstFormGroup.value.gender;
    this.registration.UserRegistration.dateOfBirth = this.firstFormGroup.value.date;
    this.registration.Address.line1 = this.secondFormGroup.value.address;
    this.registration.Address.city = this.secondFormGroup.value.city;
    this.registration.Address.country = this.secondFormGroup.value.country;
    this.registration.UserRegistration.email = this.thirdFormGroup.value.email;
    this.registration.UserRegistration.password = this.thirdFormGroup.value.password;
  }
}
