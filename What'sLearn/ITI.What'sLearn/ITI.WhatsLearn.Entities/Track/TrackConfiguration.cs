using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.WhatsLearn.Entities
{
    public class TrackCourseConfiguration : EntityTypeConfiguration<TrackCourse>
    {
        public TrackCourseConfiguration()
        {
            ToTable("TrackCourse");
            
            Property(i => i.Name)
                .HasColumnName("Name")
                .HasMaxLength(250)
                .IsRequired();

            Property(i => i.Discription)
                 .HasColumnName("Discription")
                 .HasMaxLength(1000)
                 .IsRequired();

            Property(i => i.Image)
                 .HasColumnName("Image")
                 .HasMaxLength(500)
                 .IsOptional();

            Property(i => i.IsDeleted)
                .IsRequired();

            HasRequired(i => i.SubCategory)
                .WithMany(i => i.TrackCourses)
                .HasForeignKey(i => i.SubCategoryID);

            HasMany(i => i.Users)
                        .WithRequired(i => i.TrackCourse);

            HasMany(i => i.Courses)
                           .WithRequired(i => i.TrackCourse);

        }
    }
}
