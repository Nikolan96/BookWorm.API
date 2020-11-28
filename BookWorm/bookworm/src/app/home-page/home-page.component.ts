import { Component, OnInit } from '@angular/core';
import { BookPreview } from '../book';
import { BookService } from '../book.service';
@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.scss'],
})
export class HomePageComponent implements OnInit {
  private books: Array<BookPreview> = [];
  constructor(private bookService: BookService) {}

  ngOnInit(): void {

    this.generatePicksOfTheWeek();
    this.generatePicksOfTheDay();
  }

  generatePicksOfTheWeek(): void {
    this.bookService.getBooksOfTheWeek().subscribe(
      (books) => {
        const container = document.getElementById('picks-of-the-week');
        const bookDiv = document.getElementById('picks-of-the-week').getElementsByTagName('div')[0];
        books.forEach(book => {
          let bookCopy = bookDiv.cloneNode(true);
          bookDiv.getElementsByTagName('div')[0].innerHTML = '';
          bookDiv.getElementsByTagName('h2')[0].innerHTML = book.title;
          bookDiv.getElementsByTagName('span')[0].innerHTML = book.isbn;
          container?.appendChild(bookCopy);
          bookCopy = null;
        });

      },
      (error) => {
        console.log(error.error);
      }
    );
  }

  generatePicksOfTheDay(): void {
    this.bookService.getBooksOfTheDay().subscribe(
      (books) => {
        const container = document.getElementById('picks-of-the-day');
        const bookDiv = document.getElementById('picks-of-the-day').getElementsByTagName('div')[0];
        books.forEach(book => {
          let bookCopy = bookDiv.cloneNode(true);
          bookDiv.getElementsByTagName('div')[0].innerHTML = '';
          bookDiv.getElementsByTagName('h2')[0].innerHTML = book.title;
          bookDiv.getElementsByTagName('span')[0].innerHTML = book.isbn;
          container?.appendChild(bookCopy);
          bookCopy = null;
        });

      },
      (error) => {
        console.log(error.error);
      }
    );
  }
}
