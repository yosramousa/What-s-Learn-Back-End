using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.WhatsLearn.Entities
{
    public class MainCategoryVedioConfiguration :EntityTypeConfiguration<MainCategoryVedio>
    {
        public MainCategoryVedioConfiguration()
        {
            ToTable("MainCategoryVedio");

            Property(i => i.Vedio)
                    .HasColumnName("Vedio")
                    .HasMaxLength(1000)
                    .IsRequired();


            Property(i => i.Description)
                    .HasColumnName("Description")
                    .HasMaxLength(250)
                    .IsRequired();

            HasRequired(i => i.MainCategory)
                .WithMany(i => i.MainCategoryVedios)
                .HasForeignKey(i => i.MainCategoryID);
        }

    }
}
