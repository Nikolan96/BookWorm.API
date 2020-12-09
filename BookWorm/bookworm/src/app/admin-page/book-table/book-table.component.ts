import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { BookService } from 'src/app/book.service';
import { Book } from 'src/app/interfaces/book';

@Component({
  selector: 'app-book-table',
  templateUrl: './book-table.component.html',
  styleUrls: ['./book-table.component.scss']
})
export class BookTableComponent implements OnInit {
  displayedColumns: string[] = ['id', 'isbn', 'publishDate', 'title', 'cover', 'numberOfPages', 'genreId', 'publisherId'];
  books: Book[];
  dataSource;
  constructor(private bookService: BookService) { }

  ngOnInit(): void {
    this.displayBooks();
  }

  displayBooks(): void{
    this.bookService.getBooks().subscribe((books) => {
      console.log(books);
      this.dataSource = new MatTableDataSource(books);
    });
  }
}
