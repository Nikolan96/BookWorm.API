
import { Component, OnInit } from '@angular/core';
import { BookService } from '../book.service';
import { CurrentlyReadingBook } from '../currentlyReadingBook';
import { ActivatedRoute } from '@angular/router';


@Component({
  selector: 'app-book',
  templateUrl: './book.component.html',
  styleUrls: ['./book.component.scss']
})
export class BookComponent implements OnInit {
  disabled: boolean = false;
  currentlyReadingBook: CurrentlyReadingBook = {
    userId: '',
    bookId: '',
    currentPage: 0
  };
  constructor(private bookService: BookService, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.currentlyReadingBook.bookId = this.route.snapshot.paramMap.get('id');
    this.currentlyReadingBook.userId = localStorage.getItem('userId');
    console.log(this.currentlyReadingBook.userId);
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
}
