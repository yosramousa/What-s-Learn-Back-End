using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.WhatsLearn.Entities
{
    public   class UserCertificateConfiguration : EntityTypeConfiguration<UserCertificate>
    {
        public UserCertificateConfiguration()
        {
            ToTable("UserCertificate");
                Property(i => i.Title)
                .HasColumnName("Title")
                .HasMaxLength(250)
                .IsRequired();
            HasRequired(i => i.User)
                .WithMany(i => i.Certificates)
                .HasForeignKey(i => i.UserID);
        }
    }
}
