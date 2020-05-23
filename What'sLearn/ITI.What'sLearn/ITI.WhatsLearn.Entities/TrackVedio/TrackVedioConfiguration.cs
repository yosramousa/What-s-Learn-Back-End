using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.WhatsLearn.Entities
{
    public class TrackedioConfiguration :EntityTypeConfiguration<TrackVedio>
    {
        public TrackedioConfiguration()
        {
            ToTable("TrackVedio");

            Property(i => i.Vedio)
                    .HasColumnName("Vedio")
                    .HasMaxLength(1000)
                    .IsRequired();


            Property(i => i.Description)
                    .HasColumnName("Description")
                    .HasMaxLength(250)
                    .IsRequired();

            HasRequired(i => i.Track)
                .WithMany(i => i.TrackVedios)
                .HasForeignKey(i => i.TrackID);
        }

    }
}
