using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.WhatsLearn.Entities
{
    public class TrackDocumentConfiguration :EntityTypeConfiguration<TrackDocument>
    {
        public TrackDocumentConfiguration()
        {
            ToTable("TrackDocument");

            Property(i => i.File)
                    .HasColumnName("File")
                    .HasMaxLength(1000)
                    .IsRequired();


            Property(i => i.Description)
                    .HasColumnName("Description")
                    .HasMaxLength(250)
                    .IsRequired();

            HasRequired(i => i.Track)
                .WithMany(i => i.TrackDocuments)
                .HasForeignKey(i => i.TrackID);
        }
    }
}
