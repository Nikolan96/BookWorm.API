import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BookPreview } from './book';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BookService {

  constructor(private http: HttpClient) { }

  getBooksOfTheWeek(): Observable<BookPreview[]>  {
    return this.http.get<BookPreview[]>('http://localhost:57339/api/Book/GetPicksOfTheWeek');
  }

  getBooksOfTheDay(): Observable<BookPreview[]>  {
    return this.http.get<BookPreview[]>('http://localhost:57339/api/Book/GetPicksOfTheDay');
  }
  getBookAuthor(id: string): Observable<string>  {
    return this.http.get<string>(`http://localhost:57339/api/BookAuthor/${id}`);
  }
}
