import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BookPreview } from './book';
import { Observable } from 'rxjs';
import { Fact } from './fact';
import { Genre } from './genre';
import { ReasonsToRead } from './reasonsToRead';
import { BookOpened } from './openedBook';
import { BookRecommendation } from './bookRecommendation';
import { CurrentlyReadingBook } from './currentlyReadingBook';

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

  getReasonsToRead(): Observable<ReasonsToRead[]> {
    return this.http.get<ReasonsToRead[]>('http://localhost:57339/api/ReasonsToRead');
  }

  getBookRecommendation(id: string): Observable<BookRecommendation[]>  {
    return this.http.get<BookRecommendation[]>(`http://localhost:57339/api/BookRecommendation/GetRecommendations/${id}`);
  }
  postUserOpenedBookPage(bookOpened: BookOpened): Observable<BookOpened> {
    return this.http.post<BookOpened>(`http://localhost:57339/api/UserOpenedBookPage`, bookOpened);
  }

  postUserCurrentlyReading(bookAdded: CurrentlyReadingBook): Observable<CurrentlyReadingBook> {
    return this.http.post<CurrentlyReadingBook>('http://localhost:57339/api/UserCurrentlyReading', bookAdded);
  }
}
