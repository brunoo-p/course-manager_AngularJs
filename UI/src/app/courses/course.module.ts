import { PipeModule } from './../shared/pipe/pipe.module';
import { StarModule } from './../shared/component/star/star.module';
import { RouterModule } from '@angular/router';
import { NgModule } from "@angular/core";
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

import { CourseInfoComponent } from "./course-info/course-info.component";
import { CoursesListComponent } from "./courses-list.component";

@NgModule({
  declarations:[
    CoursesListComponent,
    CourseInfoComponent
  ],
  imports:[
    CommonModule,
    FormsModule,
    StarModule,
    PipeModule,
    RouterModule.forChild([
      {
        path: 'courses', component: CoursesListComponent
      },
      {
        path: 'courses/info/:id', component: CourseInfoComponent
      }
    ])
  ],
  exports:[]
})
export class CourseModule{

}
