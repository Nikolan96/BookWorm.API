import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginPageComponent } from './login-page/login-page.component';
import { HomePageComponent } from './home-page/home-page.component';

const routes: Routes = [
  { path: '', redirectTo: '/login-page', pathMatch: 'full' },
  { path: 'login-page', component: LoginPageComponent },
  { path: 'home-page', component: HomePageComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
