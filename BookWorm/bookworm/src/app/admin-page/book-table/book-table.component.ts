import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { BookService } from 'src/app/book.service';
import { Book } from 'src/app/interfaces/book';
import { BookDeleteModalComponent } from './book-delete-modal/book-delete-modal.component';

@Component({
  selector: 'app-book-table',
  templateUrl: './book-table.component.html',
  styleUrls: ['./book-table.component.scss'],
})
export class BookTableComponent implements OnInit {
  displayedColumns: string[] = [
    'id',
    'isbn',
    'publishDate',
    'title',
    'cover',
    'numberOfPages',
    'genre',
    'publisher',
    'delete',
  ];
  books: Book[];
  dataSource;
  constructor(private bookService: BookService, public dialog: MatDialog) {}

  ngOnInit(): void {
    this.displayBooks();
  }

  displayBooks(): void {
    this.bookService.getBooks().subscribe((books) => {
      this.dataSource = new MatTableDataSource(books);
    });
  }

  openDeleteModal(id: any): void {
    let dialogRef = this.dialog.open(BookDeleteModalComponent, {
      data: { id: id },
    });
    dialogRef.afterClosed().subscribe((x) => {
      this.displayBooks();
    });
  }
}
