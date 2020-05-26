using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.WhatsLearn.Entities
{
    public class TrackCourseConfigurations: EntityTypeConfiguration<TrackCourse>
    {
        public TrackCourseConfigurations()
        {
            ToTable("TrackCourse");
            HasRequired(i => i.Track)
               .WithMany(i => i.Courses)
               .HasForeignKey(i => i.TrackID);
            HasRequired(i => i.Course)
                .WithMany(i => i.Tracks)
                .HasForeignKey(i => i.CourseID);
        }

    }
}
