import { CourseService } from './course.service';
import { Component, OnInit } from "@angular/core";
import { Course } from "./course";

@Component({
  selector: 'app-course-list',
  templateUrl: './courses-list.components.html',
})

export class CoursesListComponent implements OnInit{

  constructor(private courseService : CourseService) {}

  titleApp = 'Courses Manager';

  courses: Course[] = [];

  ngOnInit() : void {
    this.courses = this.courseService.retrieveAll();
  }
}
