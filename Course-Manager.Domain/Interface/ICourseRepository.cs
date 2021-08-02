using Course_Manager.Domain.Entity;
using System;
using System.Collections.Generic;

namespace Course_Manager.Domain.Interface
{
    public interface ICourseRepository
    {
        IEnumerable<Course> GetAll();
        Course GetById( int id );
        void Add( Course course );
        void Delete( int id );
        Course Update( int id, Course course );


    }
}
