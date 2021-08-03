using Course_Manager.Data.Mapping;
using Course_Manager.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;


namespace Course_Manager.Data.Data
{
    public class Context : DbContext
    {
        protected override void OnModelCreating( ModelBuilder modelBuilder )
        {
            modelBuilder.ApplyConfiguration(new CourseMapping());
            base.OnModelCreating(modelBuilder);
        }
        public Context( DbContextOptions<Context> options ) : base( options ) { }
        
        
        public DbSet<Course> Courses { get; set; }
    }
}
