import { CourseService } from './../course.service';
import { Course } from './../course';
import { Component, OnInit } from "@angular/core";
import { ActivatedRoute } from "@angular/router";

@Component({
  templateUrl: './course-info.component.html'
})

export class CourseInfoComponent implements OnInit {

  constructor(private activateRoute : ActivatedRoute, private courseService : CourseService){ }

  course! : Course;

  ngOnInit() : void {
    this.courseService.retrieveById(parseInt(this.activateRoute.snapshot.paramMap.get('id')!))
      .subscribe({
        next: c => this.course = c,
        error: error => console.log("Error:", error)
      });
  }


  save() : void {
    this.courseService.save(this.course).subscribe({
      next: course => console.log("saved"),
      error: err => console.log("err", err)
    });
  }
}
