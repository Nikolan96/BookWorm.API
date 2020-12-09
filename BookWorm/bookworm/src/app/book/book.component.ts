
import { Component, OnInit } from '@angular/core';
import { BookService } from '../book.service';
import { CurrentlyReadingBook } from '../interfaces/currentlyReadingBook';
import { ActivatedRoute, Router } from '@angular/router';
import { Book } from '../interfaces/book';
import { BookRecommendation } from '../interfaces/bookRecommendation';
import { BookOpened } from '../interfaces/openedBook';


@Component({
  selector: 'app-book',
  templateUrl: './book.component.html',
  styleUrls: ['./book.component.scss']
})
export class BookComponent implements OnInit {
  disabled: boolean = false;
  userId: string;
  bookId: string;
  bookRecommendation: Array<BookRecommendation> = [];
  book: Book = {
    id: '',
    isbn: '',
    publishDate: null,
    title: '',
    cover: '',
    numberOfPages: 0,
    genreId: '',
    publisherId: '',
    booksUserIsCurrentlyReading: {
      id: '',
      bookId: '',
      userId: '',
      currentPage: 0
    }
  };

  currentlyReadingBook: CurrentlyReadingBook = {
    userId: '',
    bookId: '',
    currentPage: 0
  };
    bookOpened: BookOpened = {
      userId: '',
      bookId: ''
  };
  constructor(private bookService: BookService, private route: ActivatedRoute, private router: Router) { }

  ngOnInit(): void {
    this.userId = localStorage.getItem('userId');
    this.bookId = this.route.snapshot.paramMap.get('id');
    this.currentlyReadingBook.bookId = this.bookId;
    this.currentlyReadingBook.userId = this.userId;
    this.getBook();
    this.getRecommendations();
  }

  addToCurrentlyReading(): void {
    this.bookService.postUserCurrentlyReading(this.currentlyReadingBook).subscribe(
      (currenlyReading) => {
        console.log(currenlyReading);
        this.disabled = true;
      },
      (error) => {
        console.log(error.error);
      }
    );
  }

  getBook(): void {
    this.bookService.getBook(this.bookId).subscribe(
      (book) => {
        this.book = book;
      },
      (error) => {
        console.log(error.error);
      }
    );
  }

   getRecommendations(): void {
    this.bookService.getBookRecommendation(this.userId).subscribe(
      (bookRecommendations) => {
        this.bookRecommendation = bookRecommendations;
        console.log('rec', this.bookRecommendation);
      },
      (error) => {
        console.log(error.error);
      }
    );
  }
  goToBookPage(id: any): void {
    this.router.navigate([`/book/${id}`]);
    this.bookOpened.bookId = id;
    this.bookOpened.userId = this.userId;
    this.bookService.postUserOpenedBookPage(this.bookOpened).subscribe();
  }
}
