import { CourseModule } from './courses/course.module';
import { NgModule } from '@angular/core';


import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { HttpClientModule } from "@angular/common/http";

import { AppComponent } from './app.component';
import { NavbarComponent } from './core/component/nav-bar/nav-bar.component';
import { Error404Component } from './core/component/error-404/error-404.component';


@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    Error404Component
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    CourseModule,
    RouterModule.forRoot([
      {
        path: '', redirectTo: "courses", pathMatch: 'full'
      },
      {
        // path: '**', redirectTo: 'courses', pathMatch: 'full'
        path: '**', component: Error404Component
      }
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
