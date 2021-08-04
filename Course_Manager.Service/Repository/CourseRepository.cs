using Course_Manager.Data.Data;
using Course_Manager.Domain.Entity;
using Course_Manager.Domain.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Course_Manager.Service.Repository
{
    public class CourseRepository : ICourseRepository
    {
        private readonly Context _context;

        public CourseRepository(Context context)
        {
            _context = context;
            var pendingMigration = _context.Database.GetPendingMigrations();

            if ( pendingMigration.Any() ) _context.Database.Migrate();
        }
        public void Add( Course course )
        {
            try
            {
                var newCourse = new Course(
                    name: course.Name,
                    imageUrl: course.ImageUrl,
                    price: course.Price,
                    code: course.Code,
                    duration: course.Duration,
                    releaseDate: course.ReleaseDate,
                    description: course.Description,
                    rating: course.Rating,
                    isDeleted: false
                ) { };

                if(newCourse != null){
                    _context.Set<Course>().Add(newCourse);
                    _context.SaveChanges();
                }

            }
            catch ( Exception ex )
            {
                throw new Exception("Error into Add: ", ex);
            };
        }

        public void Delete( int id )
        {
            try{
                var course = GetById(id);
                if (course == null){

                    throw default;
                }
                
                course.IsExcluded(true);
                _context.SaveChanges();

            
            }catch( IndexOutOfRangeException ex )
            {
                throw new Exception("Error to Delete: ", ex);
            }
        }

        public IEnumerable<Course> GetAll()
        {
            try{

                return _context.Courses.Where( _ => _.IsDeleted == false ).ToList();
            
            }catch( Exception ex )
            {
                throw new Exception("err: ", ex);
            }
        }

        public Course GetById( int id )
        {
            try{

                var course = _context.Courses.Where(_ => _.Id == id).FirstOrDefault();
                return course;

            }catch( IndexOutOfRangeException ex )
            {
                throw new Exception("Error Find Course: ", ex);
            }
        }

        public Course Update( int id, Course course )
        {
            try{
                /*if ( id != course.Id ) return default;*/

                var setCourse = GetById(id);
                if(setCourse == null)
                {
                    return null;
                }

                setCourse.UpdateCourse(course);
                
                _context.SaveChanges();

                return setCourse;
            }catch(Exception ex)
            {
                throw new Exception("Error to Update: ", ex);
            }
        }
    }
}
