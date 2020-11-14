import { UserLogin } from './userLogin';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { User } from './user';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  constructor(private http: HttpClient) { }

  getUsers(): Observable<User[]>  {
    return this.http.get<User[]>('http://localhost:57339/api/User');
  }


  login(loginForm: UserLogin): Observable<UserLogin> {
    return this.http.post<UserLogin>(`http://localhost:57339/api/User/Login`, loginForm);
  }

  singup(singupForm: UserLogin): Observable<UserLogin> {
    return this.http.post<UserLogin>(`http://localhost:57339/api/User/Register`, singupForm);
  }

  handleError(error: HttpErrorResponse) {
    return throwError(error);
}

  // getUsers(id: any): Observable<User[]>  {
  //   return this.http.get<User[]>(`http://localhost:57339/api/User/${id}`);
  // }
}
