import { Error404Component } from './error-404/error-404.component';
import { NavbarComponent } from './nav-bar/nav-bar.component';
import { StarComponent } from './star/star.component';
import { CoursesListComponent } from './courses/courses-list.component';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { HttpClientModule } from "@angular/common/http";

import { AppComponent } from './app.component';
import { PipeReplace } from './pipe/replace.pipe';
import { CourseInfoComponent } from './courses/course-info/course-info.component';

@NgModule({
  declarations: [
    AppComponent,
    CoursesListComponent,
    StarComponent,
    PipeReplace,
    NavbarComponent,
    CourseInfoComponent,
    Error404Component
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    RouterModule.forRoot([
      {
        path: 'courses', component: CoursesListComponent
      },
      {
        path: 'courses/info/:id', component: CourseInfoComponent
      },
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
