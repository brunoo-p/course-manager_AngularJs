import { Component, OnInit } from "@angular/core";
import { Course } from "./course";

@Component({
  selector: 'app-course-list',
  templateUrl: './courses-list.components.html',
})

export class CoursesListComponent implements OnInit{
  titleApp = 'Courses Manager';
  courses: Course[] = [];

  ngOnInit() : void {
    this.courses = [

      {
        id : 1,
        name : 'Angular: Forms',
        imageUrl : '../../assets/images/Angularforms.png',
        price : 99.94,
        code : 'RVH-4526',
        duration : 120,
        releaseDate: 'November, 17, 2021',
        rating : 4.5,
      },
      {
        id : 2,
        name : 'Angular: HTTP',
        imageUrl : '../../assets/images/Angularhttp.png',
        price : 65.29,
        code : 'PRF-5669',
        duration : 90,
        releaseDate: 'December, 30, 2020',
        rating : 4,
      }

    ]
  }
}
