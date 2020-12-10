import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { BookService } from '../../../book.service';

@Component({
  selector: 'app-book-delete-modal',
  templateUrl: './book-delete-modal.component.html',
  styleUrls: ['./book-delete-modal.component.scss']
})
export class BookDeleteModalComponent implements OnInit {
  constructor(private bookService: BookService, @Inject(MAT_DIALOG_DATA) public data) { }

  ngOnInit(): void {
  }

  deleteBook(id: any): void {
    this.bookService.deleteBook(id).subscribe();
  }
}
