import { CourseService } from './course.service';
import { Component, OnInit } from "@angular/core";
import { Course } from "./course";

@Component({
  templateUrl: './courses-list.components.html',
  styleUrls: ['./courses-list.components.css']
})

export class CoursesListComponent implements OnInit{

    constructor(private courseService : CourseService) {}

    titleApp = 'Courses Manager';

    _filterBy: string = '';
    _courses: Course[] = [];

    filteredCourses : Course[]  = [];

    ngOnInit() : void {
        this.retrieveAll();
    }

    retrieveAll() : void {
      this.courseService.retrieveAll().subscribe({
        next: courses => {
          this._courses = courses;
          this.filteredCourses = this._courses;
        },
        error: err => console.log(err)

      });
    }

    deleteById(courseId : number) : void {
      this.courseService.deleteById(courseId).subscribe({
        next: () => {
          console.log("Deleted with success!");
          this.retrieveAll();
        },
        error: err => console.log(err)
      });
    }

    set filter(value: string) {
        this._filterBy = value;
        this.filteredCourses = this._courses
          .filter((course : Course) => course.name.toLocaleLowerCase()
          .indexOf(this._filterBy.toLocaleLowerCase()) > -1);
    }
    get filter() {
        return this._filterBy;
    }

}
