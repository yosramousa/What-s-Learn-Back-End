using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.WhatsLearn.Entities
{
    public class PersonConfiguration : EntityTypeConfiguration<Person>
    {
        public PersonConfiguration()
        {

            Property(i => i.Name)
                .HasColumnName("Name")
                .HasMaxLength(250)
                .IsRequired();
            Property(i => i.Email)
               .HasColumnName("Email")
               .HasMaxLength(250)
               .IsRequired();
            Property(i => i.Password)
               .HasColumnName("Password")
               .HasMaxLength(250)
               .IsRequired();
            Property(i => i.Age)
               .HasColumnName("Age").IsRequired();
            Property(i => i.Adress)
               .HasColumnName("Adress")
               .HasMaxLength(250)
               .IsRequired();
            Property(i => i.Gender)
             .HasColumnName("Gender").IsRequired();
            Property(i => i.Phone)
               .HasColumnName("Phone")
               .HasMaxLength(20)
               .IsRequired();
            Property(i => i.IsActive)
           .HasColumnName("IsActive").IsRequired();
            Property(i => i.Image)
              .HasColumnName("Image")
              .HasMaxLength(20);
            Property(i => i.IsDeleted)
          .HasColumnName("IsDeleted").IsRequired();
        }
    }
}
