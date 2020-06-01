using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.WhatsLearn.Entities
{
    public class CourseLinkConfiguration
    : EntityTypeConfiguration<CourseLink>
    {
        public CourseLinkConfiguration()
        {
            ToTable("CourseLink");

            Property(i => i.Link)
                    .HasColumnName("Link")
                    .HasMaxLength(1000)
                    .IsRequired();


            Property(i => i.Description)
                    .HasColumnName("Description")
                    .HasMaxLength(250)
                    .IsRequired();

            HasRequired(i => i.Course)
                .WithMany(i => i.CourseLinks)
                .HasForeignKey(i => i.CourseID);

        }
    }
}
