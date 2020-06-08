using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
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

            Property(i => i.UserID)
              .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                       new IndexAnnotation(
                   new IndexAttribute("IX_UserSkill", 1) { IsUnique = true }))
              .HasColumnName("UserID")
              .IsRequired();

            Property(i => i.SkillID)
             .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                      new IndexAnnotation(
                  new IndexAttribute("IX_UserSkill", 2) { IsUnique = true }))
             .HasColumnName("SkillID")
             .IsRequired();

        }
    }
}
