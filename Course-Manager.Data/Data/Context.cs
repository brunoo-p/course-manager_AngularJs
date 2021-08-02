using Course_Manager.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;


namespace Course_Manager.Data.Data
{
    public class Context : DbContext
    {
        protected override void OnConfiguring( DbContextOptionsBuilder optionsBuilder )
        {
            optionsBuilder.UseSqlServer("string Database");
        }
        public DbSet<Course> Courses { get; set; }
        public Context(){ }  
    }
}
