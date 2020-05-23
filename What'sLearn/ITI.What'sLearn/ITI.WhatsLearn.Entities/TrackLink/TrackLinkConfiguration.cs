using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.WhatsLearn.Entities
{
    public class TrackLinkConfiguration : EntityTypeConfiguration<TrackLink>
    {
        public TrackLinkConfiguration()
        {
            ToTable("TrackLink");

            Property(i => i.Link)
                    .HasColumnName("Link")
                    .HasMaxLength(1000)
                    .IsRequired();


            Property(i => i.Description)
                    .HasColumnName("Description")
                    .HasMaxLength(250)
                    .IsRequired();

            HasRequired(i => i.Track)
                .WithMany(i => i.Trackinks)
                .HasForeignKey(i => i.TrackID);

        }
    }
}
