using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.WhatsLearn.Entities
{
    public class UserSocialLinkConfiguration: EntityTypeConfiguration<UserSocialLink>
    {
        public UserSocialLinkConfiguration()
        {
            ToTable("UserSocialLink");
            Property(i => i.link)
                .HasColumnName("Link")
                .HasMaxLength(250)
                .IsRequired();

            HasRequired(i => i.User)
                .WithMany(i => i.SocialLinks)
                .HasForeignKey(i => i.UserID);
        }
    }
}
