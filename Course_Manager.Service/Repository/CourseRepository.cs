using Course_Manager.Data.Data;
using Course_Manager.Domain.Entity;
using Course_Manager.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course_Manager.Service.Repository
{
    public class CourseRepository : ICourseRepository
    {
        private readonly Context _context;

        public CourseRepository(Context context)
        {
            _context = context;
        }
        public void Add( Course course )
        {
            try
            {
                var newCourse = new Course(
                    course.Id,
                    course.Name,
                    course.ImageUrl,
                    course.Price,
                    course.Code,
                    course.Duration,
                    course.ReleaseDate,
                    course.Description,
                    course.Rating,
                    course.IsDeleted
                ) { };

                if(newCourse != null){
                    _context.Add(newCourse);
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

                var oldCourse = GetById(id);
                var changed = _context.Remove(oldCourse);
                Add(course);
                
                _context.SaveChanges();

                return course;
            }catch(Exception ex)
            {
                throw new Exception("Error to Delete: ", ex);
            }
        }
    }
}
