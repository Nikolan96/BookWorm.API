import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { throwToolbarMixedModesError } from '@angular/material/toolbar';
import { NgImageSliderComponent } from 'ng-image-slider';
import { BookPreview } from '../book';
import { BookService } from '../book.service';
import { Fact } from '../fact';
import { Genre } from '../genre';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.scss'],
})
export class HomePageComponent implements OnInit {
  @ViewChild('nav') slider: NgImageSliderComponent;
  imageObject: Array<object> = [
    {
      image: '../../assets/reasons to read/undraw_book_lover_mkck.svg',
    },
    {
      image: '../../assets/reasons to read/undraw_book_reading_kx9s.svg', // Support base64 image
      thumbImage: '../../assets/reasons to read/undraw_book_reading_kx9s.svg', // Support base64 image
      title: 'Image title', //Optional: You can use this key if want to show image with title
      alt: 'Image alt' //Optional: You can use this key if want to show image with alt
    },
  ];
  books: Array<BookPreview> = [];
  bookFacts: Array<Fact> = [];
  authorFacts: Array<Fact> = [];
  genres: Array<Genre> = [];
  constructor(private bookService: BookService) {}

  ngOnInit(): void {
    this.generatePicksOfTheWeek();
    this.generatePicksOfTheDay();
    this.getBookFacts();
    this.getAuthorFacts();
    this.getGenres();
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
        console.log(this.genres);
      },
      (error) => {
        console.log(error.error);
      }
    );
  }
  prevImageClick() {
    this.slider.prev();
  }

  nextImageClick() {
    this.slider.next();
  }
}
