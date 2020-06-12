using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.WhatsLearn.Entities
{
    public class CourseConfiguration : EntityTypeConfiguration<Course>
    {
        public CourseConfiguration()
        {
            ToTable("Course");

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
            Property(i => i.Icon)
                .HasColumnName("Icon");

            HasMany(i => i.CourseLinks)
                .WithRequired(i => i.Course);

            HasMany(i => i.CourseDocuments)
                .WithRequired(i => i.Course);

            HasMany(i => i.CourseVedios)
              .WithRequired(i => i.Course);
            HasMany(i => i.Tracks)
                          .WithRequired(i => i.Course);

            HasMany(i => i.UserTracks)
                .WithRequired(i => i.course);

        }
    }
}
