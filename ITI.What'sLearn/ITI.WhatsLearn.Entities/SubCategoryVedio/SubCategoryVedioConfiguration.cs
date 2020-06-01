using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.WhatsLearn.Entities
{
    public class SubCategoryVedioConfiguration :EntityTypeConfiguration<SubCategoryVedio>
    {
        public SubCategoryVedioConfiguration()
        {
            ToTable("SubCategoryVedio");

            Property(i => i.Vedio)
                    .HasColumnName("Vedio")
                    .HasMaxLength(1000)
                    .IsRequired();


            Property(i => i.Description)
                    .HasColumnName("Description")
                    .HasMaxLength(250)
                    .IsRequired();

            HasRequired(i => i.SubCategory)
                .WithMany(i => i.SubCategoryVedios)
                .HasForeignKey(i => i.SubCategoryID);
        }

    }
}
