
import { Component, OnInit } from '@angular/core';
import { BookService } from '../book.service';
import { CurrentlyReadingBook } from '../currentlyReadingBook';
import { ActivatedRoute } from '@angular/router';
import { Book } from '../book';
import { dateInputsHaveChanged } from '@angular/material/datepicker/datepicker-input-base';
import { getLocaleDateTimeFormat } from '@angular/common';


@Component({
  selector: 'app-book',
  templateUrl: './book.component.html',
  styleUrls: ['./book.component.scss']
})
export class BookComponent implements OnInit {
  disabled: boolean = false;
  userId: string;
  bookId: string;
  // book: Book = {
  //   id: '',
  //   isbn: '',
  //   publishDate: null,
  //   title: '',
  //   cover: '',
  //   numberOfPages: 0,
  //   genreId: '',
  //   publisherId: '',
  //   booksUserIsCurrentlyReading: {
  //     id: '',
  //     bookId: '',
  //     userId: '',
  //     currentPage: 0
  //   }
  // };
  book: Book[];
  currentlyReadingBook: CurrentlyReadingBook = {
    userId: '',
    bookId: '',
    currentPage: 0
  };
  constructor(private bookService: BookService, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.userId = localStorage.getItem('userId');
    this.bookId = this.route.snapshot.paramMap.get('id');
    this.currentlyReadingBook.bookId = this.bookId;
    this.currentlyReadingBook.userId = this.userId;
    this.getBook();
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
        console.log(this.book);
      },
      (error) => {
        console.log(error.error);
      }
    );
  }
}
