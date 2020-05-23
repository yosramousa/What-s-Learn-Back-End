using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.WhatsLearn.Entities
{
    public class UserSkillConfiguration : EntityTypeConfiguration<UserSkill>
    {
        public UserSkillConfiguration()
        {
            ToTable("UserSkill");
            Property(i => i.Level)
               .HasColumnName("Level").IsRequired();
            HasRequired(i => i.User)
               .WithMany(i => i.Skills)
               .HasForeignKey(i => i.UserID);
            HasRequired(i => i.Skill)
            .WithMany(i => i.Skills)
            .HasForeignKey(i => i.SkillID);


        }
    }
}
