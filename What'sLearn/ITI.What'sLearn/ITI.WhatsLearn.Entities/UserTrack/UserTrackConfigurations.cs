using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.WhatsLearn.Entities
{
    public class UserTrackCourseConfigurations: EntityTypeConfiguration<UserTrackCourse>
    {
        public UserTrackCourseConfigurations()
        {
            ToTable("UserTrackCourse");
            Property(i => i.Date)
              .HasColumnName("Date")
              .IsRequired();
            Property(i => i.IsApproveed)
             .HasColumnName("IsApproveed")
             .IsRequired();
            HasRequired(i => i.User)
                .WithMany(i => i.TrackCourses)
                .HasForeignKey(i => i.UserID);
            HasRequired(i => i.TrackCourse)
                .WithMany(i => i.Users)
                .HasForeignKey(i => i.TrackCourseID);
            HasMany(i => i.FinishedCourses)
                     .WithRequired(i => i.UserTrackCourse);
        }
    }
}
