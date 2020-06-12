using ITI.WhatsLearn.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.WhatsLearn.ViewModel
{
    public static class UserSkillExtentions
    {
        public static UserSkillViewModel ToViewModel(this UserSkill model)
        {
            return new UserSkillViewModel()
            {
                ID = model.ID,
                UserName = model.User.Name,
                SkillName = model.Skill.skill,
                Level = model.Level,
                IsDeleted=model.IsDeleted,
                SkillID = model.SkillID,
                UserID = model.UserID

            };
        }
        public static UserSkill ToModel(this UserSkillEditViewModel editModel)
        {
            return new UserSkill()
            {
                ID = editModel.ID,
                UserID = editModel.UserID,
                SkillID = editModel.SkillID,
                Level = editModel.Level,
                IsDeleted = editModel.IsDeleted,
                

            };
        }
        public static UserSkillEditViewModel ToEditableViewModel(this UserSkill model)
        {
            return new UserSkillEditViewModel()
            {
                ID = model.ID,
                UserID = model.UserID,
                SkillID = model.SkillID,
                Level = model.Level,
                IsDeleted = model.IsDeleted,
                SkillName =model.Skill?.skill
                
            };
        }
    }
}
