using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.WhatsLearn.Entities
{
    public class UserConfiguration: EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            ToTable("User");
            Property(i => i.Education)
               .HasColumnName("Education")
               .HasMaxLength(250)
               .IsRequired();

            Property(i => i.SignedTime)
               .HasColumnName("SignedTime")
               .IsRequired();

            HasMany(i => i.Certificates).
                WithRequired(i => i.User);
            HasMany(i => i.SocialLinks).
               WithRequired(i => i.User);
            HasMany(i => i.Skills).
             WithRequired(i => i.User);
            HasMany(i => i.Tracks)
                       .WithRequired(i => i.User);

        }
    }
}
