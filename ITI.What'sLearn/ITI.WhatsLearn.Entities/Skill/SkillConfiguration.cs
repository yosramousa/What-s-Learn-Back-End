using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.WhatsLearn.Entities
{
    public class SkillConfiguration: EntityTypeConfiguration<Skill>
    {
        public SkillConfiguration()
        {
            ToTable("Skill");
            Property(i => i.skill)
               .HasColumnName("Skill")
               .HasMaxLength(250)
               .IsRequired();


        }
    }
}
