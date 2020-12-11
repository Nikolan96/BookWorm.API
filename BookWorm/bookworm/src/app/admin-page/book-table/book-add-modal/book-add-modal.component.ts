import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { BookService } from '../../../book.service';

@Component({
  selector: 'app-book-add-modal',
  templateUrl: './book-add-modal.component.html',
  styleUrls: ['./book-add-modal.component.scss']
})
export class BookAddModalComponent implements OnInit {
  addForm: FormGroup;

  constructor(  private router: Router, private bookService: BookService, private formBuilder: FormBuilder) { }

  ngOnInit(): void {
    this.initForm();
  }


  private initForm(): void {
    this.addForm = this.formBuilder.group({
      id: new FormControl(null, Validators.required),
      isbn: new FormControl(null, Validators.required),
      publishDate: new FormControl(null, Validators.required),
      title: new FormControl(null, Validators.required),
      numberOfPages: new FormControl(null, Validators.required),
      cover: new FormControl(null, Validators.required),
      genreId: new FormControl(null, Validators.required),
      publisherId: new FormControl(null, Validators.required),
    });
  }
}
