using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.WhatsLearn.Entities
{
     public class FinishedCourseConfigurations:EntityTypeConfiguration<FinishedCourse>
    {
        public FinishedCourseConfigurations()
        {
            ToTable("FinishedCourse");

            HasRequired(i => i.course)
                .WithMany(i => i.UserTrackCourses)
                .HasForeignKey(i => i.courseID);

            HasRequired(i => i.UserTrackCourse)
                .WithMany(i => i.FinishedCourses)
                .HasForeignKey(i => i.UserTrackCourseID);
        }
    }
}
