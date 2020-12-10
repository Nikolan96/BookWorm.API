import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BookDeleteModalComponent } from './book-delete-modal.component';

describe('BookDeleteModalComponent', () => {
  let component: BookDeleteModalComponent;
  let fixture: ComponentFixture<BookDeleteModalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BookDeleteModalComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(BookDeleteModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
