import { Component, OnInit } from '@angular/core';
import { BookPreview } from '../book';
import { BookService } from '../book.service';
import { Fact } from '../fact';
import { Genre } from '../genre';
import { ReasonsToRead } from '../reasonsToRead';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.scss'],
})
export class HomePageComponent implements OnInit {
  picksOfTheWeek: Array<BookPreview> = [];
  picksOfTheDay: Array<BookPreview> = [];
  bookFacts: Array<Fact> = [];
  reasonsToRead: Array<ReasonsToRead> = [];
  authorFacts: Array<Fact> = [];
  genres: Array<Genre> = [];
  constructor(private bookService: BookService, private router: Router) {}

  ngOnInit(): void {
    this.generatePicksOfTheWeek();
    this.generatePicksOfTheDay();
    this.getBookFacts();
    this.getAuthorFacts();
    this.getGenres();
    this.getReasonsToRead();
  }

  generatePicksOfTheWeek(): void {
    this.bookService.getBooksOfTheWeek().subscribe(
      (books) => {
        this.picksOfTheWeek = books;
        console.log(this.picksOfTheWeek);
      },
      (error) => {
        console.log(error.error);
      }
    );
  }

  generatePicksOfTheDay(): void {
    this.bookService.getBooksOfTheDay().subscribe(
      (books) => {
        this.picksOfTheDay = books;
        console.log(this.picksOfTheDay);
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

  getBookFacts(): void {
    this.bookService.getBookFacts().subscribe(
      (facts) => {
        this.bookFacts = facts;
        let randomFact = this.bookFacts[
          Math.floor(Math.random() * this.bookFacts.length)
        ];
        this.bookFacts = [];
        this.bookFacts.push(randomFact);
      },
      (error) => {
        console.log(error.error);
      }
    );
  }

  getAuthorFacts(): void {
    this.bookService.getBookFacts().subscribe(
      (facts) => {
        this.authorFacts = facts;
        let randomFact = this.bookFacts[
          Math.floor(Math.random() * this.bookFacts.length)
        ];
        this.authorFacts = [];
        this.authorFacts.push(randomFact);
      },
      (error) => {
        console.log(error.error);
      }
    );
  }

  getGenres(): void {
    this.bookService.getGenres().subscribe(
      (genres) => {
        this.genres = genres;
      },
      (error) => {
        console.log(error.error);
      }
    );
  }

  getReasonsToRead(): void {
    this.bookService.getReasonsToRead().subscribe(
      (reasons) => {
        for (let i = 0; i < 5; i++) {
          this.reasonsToRead.push(reasons[i]);
        }
      },
      (error) => {
        console.log(error.error);
      }
    );
  }


  goToBookPage(id: any): void {
    this.router.navigate([`/book/${id}`]);
  }
}
