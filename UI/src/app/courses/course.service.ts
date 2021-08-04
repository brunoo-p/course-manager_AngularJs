import { Injectable } from "@angular/core";

import { Course } from "./course";
import { Observable } from "rxjs";
import { HttpClient } from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})


export class CourseService {

  constructor(private httpClient : HttpClient){ }

  private courseUrl : string = "https://localhost:44336/api/course";

  retrieveAll() : Observable<Course[]> {

    return this.httpClient.get<Course[]>(this.courseUrl);
  }

  retrieveById(id: number) : Observable<Course> {
    return this.httpClient.get<Course>(`${this.courseUrl}/${id}`);
  }

  save(course : Course) : Observable<any>{
    if(course.id){
      return this.httpClient.put<any>(`${this.courseUrl}/${course.id}`, course, {responseType: 'text' as 'json'});

    }
    else{
      return this.httpClient.post<any>(`${this.courseUrl}`, course);
    }
  }

  deleteById(id: number) : Observable<any> {
    return this.httpClient.delete<any>(`${this.courseUrl}/${id}`);
  }
}
