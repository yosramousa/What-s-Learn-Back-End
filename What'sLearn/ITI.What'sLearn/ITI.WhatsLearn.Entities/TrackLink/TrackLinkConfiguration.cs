using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.WhatsLearn.Entities
{
    public class TrackCourseLinkConfiguration : EntityTypeConfiguration<TrackCourseLink>
    {
        public TrackCourseLinkConfiguration()
        {
            ToTable("TrackCourseLink");

            Property(i => i.Link)
                    .HasColumnName("Link")
                    .HasMaxLength(1000)
                    .IsRequired();


            Property(i => i.Description)
                    .HasColumnName("Description")
                    .HasMaxLength(250)
                    .IsRequired();

            HasRequired(i => i.TrackCourse)
                .WithMany(i => i.TrackCourseLinks)
                .HasForeignKey(i => i.TrackCourseID);

        }
    }
}
