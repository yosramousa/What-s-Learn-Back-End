using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.WhatsLearn.Entities
{
    public class TrackCourseedioConfiguration :EntityTypeConfiguration<TrackCourseVedio>
    {
        public TrackCourseedioConfiguration()
        {
            ToTable("TrackCourseVedio");

            Property(i => i.Vedio)
                    .HasColumnName("Vedio")
                    .HasMaxLength(1000)
                    .IsRequired();


            Property(i => i.Description)
                    .HasColumnName("Description")
                    .HasMaxLength(250)
                    .IsRequired();

            HasRequired(i => i.TrackCourse)
                .WithMany(i => i.TrackCourseVedios)
                .HasForeignKey(i => i.TrackCourseID);
        }

    }
}
