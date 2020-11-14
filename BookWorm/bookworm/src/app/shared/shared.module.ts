
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { MatMenuModule } from '@angular/material/menu';
import { MatTabsModule } from '@angular/material/tabs';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatDialogModule } from '@angular/material/dialog';
import { MatTableModule } from '@angular/material/table';
import { MatIconModule } from '@angular/material/icon';
import { MatCardModule } from '@angular/material/card';
import { FlexLayoutModule } from '@angular/flex-layout';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {MatStepperModule} from '@angular/material/stepper';
import { MatSelectModule } from '@angular/material/select';

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    MatCardModule,
    MatIconModule,
    MatButtonModule,
    MatInputModule,
    MatTableModule,
    MatMenuModule,
    MatTabsModule,
    MatToolbarModule,
    MatDialogModule,
    BrowserAnimationsModule,
    FlexLayoutModule,
    MatStepperModule,
    MatSelectModule
  ],
  exports: [
    MatCardModule,
    MatIconModule,
    MatButtonModule,
    MatInputModule,
    MatTableModule,
    MatMenuModule,
    MatTabsModule,
    MatToolbarModule,
    MatDialogModule,
    BrowserAnimationsModule,
    FlexLayoutModule,
    MatStepperModule,
    MatSelectModule
  ]
})
export class SharedModule { }
