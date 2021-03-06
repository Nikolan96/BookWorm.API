import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginPageComponent } from './login-page/login-page.component';
import { HomePageComponent } from './home-page/home-page.component';
import { RegistrationPageComponent } from './registration-page/registration-page.component';
import { BookComponent } from './book/book.component';
import { AdminPageComponent } from './admin-page/admin-page.component';

const routes: Routes = [
  { path: '', redirectTo: '/login-page', pathMatch: 'full' },
  { path: 'login-page', component: LoginPageComponent },
  { path: 'home-page/:id', component: HomePageComponent },
  { path: 'registration-page', component: RegistrationPageComponent },
  { path: 'book/:id', component: BookComponent },
  { path: 'admin-page', component: AdminPageComponent }
];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
