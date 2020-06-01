using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.WhatsLearn.Entities
{
    public class MainCategoryDocumentConfiguration :EntityTypeConfiguration<MainCategoryDocument>
    {
        public MainCategoryDocumentConfiguration()
        {
            ToTable("MainCategoryDocument");

            Property(i => i.File)
                    .HasColumnName("File")
                    .HasMaxLength(1000)
                    .IsRequired();


            Property(i => i.Description)
                    .HasColumnName("Description")
                    .HasMaxLength(250)
                    .IsRequired();

            HasRequired(i => i.MainCategory)
                .WithMany(i => i.MainCategoryDocuments)
                .HasForeignKey(i => i.MainCategoryID);
        }
    }
}
