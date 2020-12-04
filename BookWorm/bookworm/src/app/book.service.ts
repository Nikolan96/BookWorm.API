import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BookPreview } from './book';
import { Observable } from 'rxjs';
import { Fact } from './fact';
import { Genre } from './genre';

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

  getBookFacts(): Observable<Fact[]>  {
    return this.http.get<Fact[]>('http://localhost:57339/api/BookFact');
  }

  getAuthorFacts(): Observable<Fact[]> {
    return this.http.get<Fact[]>('http://localhost:57339/api/AuthorFact');
  }

  getGenres(): Observable<Genre[]> {
    return this.http.get<Genre[]>('http://localhost:57339/api/Genre');
  }
}
