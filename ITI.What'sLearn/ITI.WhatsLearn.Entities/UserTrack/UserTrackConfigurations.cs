using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
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
            Property(i => i.EnrollDate)
              .HasColumnName("EnrollDate")
              .IsRequired();

            Property(i => i.FinshedDate)
             .HasColumnName("FinshedDate");
            

            Property(i => i.IsApproveed)
             .HasColumnName("IsApproveed")
             .IsRequired();
            Property(i=>i.UserID)
                .HasColumnName("UserID")
                .IsRequired();

            Property(i => i.TrackID)
                .HasColumnName("TrackID")
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
