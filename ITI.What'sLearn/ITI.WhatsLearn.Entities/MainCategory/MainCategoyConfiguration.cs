using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.WhatsLearn.Entities
{
    public class MainCategoyConfiguration : EntityTypeConfiguration<MainCategory>
    {
        public MainCategoyConfiguration()
        {
            ToTable("MainCategory");
            
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
                 .HasMaxLength(500)
                 .IsOptional();

            Property(i => i.IsDeleted)
                .IsRequired();

            HasMany(i => i.MainCategoryLinks)
                .WithRequired(i => i.MainCategory);

            HasMany(i => i.MainCategoryDocuments)
                .WithRequired(i => i.MainCategory);

            HasMany(i => i.MainCategoryVedios)
              .WithRequired(i => i.MainCategory);

            HasMany(i => i.SubCategories)
             .WithRequired(i => i.MainCategory);

        }
    }
}
