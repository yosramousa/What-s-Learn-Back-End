using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.WhatsLearn.Entities
{
    public class TrackCourseCourseConfigurations: EntityTypeConfiguration<TrackCourseCourse>
    {
        public TrackCourseCourseConfigurations()
        {
            ToTable("TrackCourseCourse");
            HasRequired(i => i.TrackCourse)
               .WithMany(i => i.Courses)
               .HasForeignKey(i => i.TrackCourseID);
            HasRequired(i => i.Course)
                .WithMany(i => i.TrackCourses)
                .HasForeignKey(i => i.CourseID);
        }

    }
}
