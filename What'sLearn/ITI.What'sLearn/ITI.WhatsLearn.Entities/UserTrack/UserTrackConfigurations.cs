using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.WhatsLearn.Entities
{
    public class UserTrackConfigurations: EntityTypeConfiguration<UserTrack>
    {
        public UserTrackConfigurations()
        {
            ToTable("UserTrack");
            Property(i => i.Date)
              .HasColumnName("Date")
              .IsRequired();
            Property(i => i.IsApproveed)
             .HasColumnName("IsApproveed")
             .IsRequired();
            HasRequired(i => i.User)
                .WithMany(i => i.Tracks)
                .HasForeignKey(i => i.UserID);
            HasRequired(i => i.Track)
                .WithMany(i => i.Users)
                .HasForeignKey(i => i.TrackID);
            HasMany(i => i.FinishedCourses)
                     .WithRequired(i => i.UserTrack);
        }
    }
}
