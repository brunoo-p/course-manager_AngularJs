using Course_Manager.Data.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course_Manager.Data.Configuration
{
    public class DbContextFactory : IDesignTimeDbContextFactory<Context>
    {
        public Context CreateDbContext( string[] args )
        {
            var optionsBuilder = new DbContextOptionsBuilder<Context>();
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=COURSE;Trusted_Connection=True;" );
            var context = new Context(optionsBuilder.Options);

            return context;
        }
    }
}
