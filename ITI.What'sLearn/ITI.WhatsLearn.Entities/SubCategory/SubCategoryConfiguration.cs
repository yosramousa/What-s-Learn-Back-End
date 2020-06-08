using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.WhatsLearn.Entities
{
    public class SubCategoryConfiguration :EntityTypeConfiguration<SubCategory>
    {
        public SubCategoryConfiguration()
        {
            ToTable("SubCategory");

            Property(i => i.Name)
                .HasColumnName("Name")
                .HasMaxLength(250)
                .IsRequired();

            Property(i => i.Discription)
                 .HasColumnName("Discription")
                 .HasMaxLength(1000)
                 .IsRequired();

            Property(i => i.Image)
                 .HasColumnName("Image")
                 .HasMaxLength(500)
                 .IsOptional();
            Property(i => i.Icon)
               .HasColumnName("Icon")
               .IsRequired();
            Property(i => i.IsDeleted)
                .IsRequired();

            HasMany(i => i.SubCategoryLinks)
                .WithRequired(i => i.SubCategory);

            HasMany(i => i.SubCategoryDocuments)
                .WithRequired(i => i.SubCategory);

            HasMany(i => i.SubCategoryVedios)
              .WithRequired(i => i.SubCategory);
            HasMany(i => i.Tracks)
            .WithRequired(i => i.SubCategory);

            HasRequired(i => i.MainCategory)
                .WithMany(i => i.SubCategories)
                .HasForeignKey(i => i.MainCategoryID);
        }
    }
}
