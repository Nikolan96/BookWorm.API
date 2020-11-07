import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { User } from './user';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  constructor(private http: HttpClient) { }

  getUsers(): Observable<User[]>  {
    return this.http.get<User[]>('http://localhost:57339/api/User');
  }
  // getUsers(id: any): Observable<User[]>  {
  //   return this.http.get<User[]>(`http://localhost:57339/api/User/${id}`);
  // }
}
