using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.WhatsLearn.Entities
{
    public class ConfigurationConfig : EntityTypeConfiguration<Configuration>
    {

        public ConfigurationConfig ()
        {
            Property(i =>i.Key )
               .HasColumnName("Key")
               .HasMaxLength(250)
               .IsRequired();
            Property(i => i.Value)
               .HasColumnName("value")
               .IsRequired();


        }

    }
}
