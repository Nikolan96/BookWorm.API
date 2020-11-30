import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { BookPreview } from '../book';
import { BookService } from '../book.service';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.scss'],
})
export class HomePageComponent implements OnInit {

  books: Array<BookPreview> = [];
  constructor(private bookService: BookService) {}

  ngOnInit(): void {
    this.generatePicksOfTheWeek();
    this.generatePicksOfTheDay();
  }

  generatePicksOfTheWeek(): void {
    this.bookService.getBooksOfTheWeek().subscribe(
      (books) => {
        this.books = books;
      },
      (error) => {
        console.log(error.error);
      }
    );
  }

  generatePicksOfTheDay(): void {
    this.bookService.getBooksOfTheDay().subscribe(
      (books) => {
        this.books = books;
      },
      (error) => {
        console.log(error.error);
      }
    );
  }

  openFact(): void {
    let button = document.getElementById('facts-div');
    if (!button.classList.contains('fun-facts-after')) {
      button.classList.add('fun-facts-after');
    } else {
      button.classList.remove('fun-facts-after');
    }
  }
}
