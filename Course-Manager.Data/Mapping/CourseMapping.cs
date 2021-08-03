using Course_Manager.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Course_Manager.Data.Mapping
{
    public class CourseMapping : IEntityTypeConfiguration<Course>
    {
        public void Configure( EntityTypeBuilder<Course> builder )
        {
            builder.ToTable("Course");
            builder.HasKey(pk => pk.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();


            builder.Property(p => p.Name)
                .IsRequired()
                .HasColumnType("varchar(30)");
                
            builder.Property(p => p.ImageUrl)
                .HasDefaultValue("");
            
            builder.Property(p => p.Price)
                .IsRequired();

            builder.Property(p => p.Code)
                .IsRequired()
                .HasColumnType("varchar(10)");

            builder.Property(p => p.Duration)
                .IsRequired();
                
            builder.Property(p => p.ReleaseDate)
                .IsRequired();
                
            builder.Property(p => p.Description)
                .IsRequired()
                .HasColumnType("varchar(50)");
                
            builder.Property(p => p.Rating)
                .HasDefaultValue(0);
            
            builder.Property(p => p.IsDeleted)
                .HasDefaultValue(false);    
        }
    }
}
