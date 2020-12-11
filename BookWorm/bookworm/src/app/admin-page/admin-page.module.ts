import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AchievementTableComponent } from './achievement-table/achievement-table.component';
import { BookDeleteModalComponent } from './book-table/book-delete-modal/book-delete-modal.component';
import { BookAddModalComponent } from './book-table/book-add-modal/book-add-modal.component';



@NgModule({
  declarations: [AchievementTableComponent, BookDeleteModalComponent, BookAddModalComponent],
  imports: [
    CommonModule
  ]
})
export class AdminPageModule { }
