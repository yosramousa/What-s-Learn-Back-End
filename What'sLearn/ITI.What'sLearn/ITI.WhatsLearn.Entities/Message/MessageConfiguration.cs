using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.WhatsLearn.Entities
{
    public class MessageConfiguration :EntityTypeConfiguration<Message>
    {
        public MessageConfiguration()
        {
            ToTable("Message");

            Property(i => i.FullName)
                .HasColumnName("FullName")
                .HasMaxLength(50)
                .IsRequired();
            Property(i => i.Email)
                .HasColumnName("Email")
                .HasMaxLength(50)
                .IsRequired();

            Property(i => i.Text)
                .HasColumnName("Text")
                .HasMaxLength(1000)
                .IsRequired();


            Property(i => i.SendTime)
                .HasColumnName("SendTime")
                .IsRequired();


            Property(i => i.IsRead)
                .HasColumnName("IsRead")
                .IsRequired();
        }

    }
}
