using ITI.WhatsLearn.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.WhatsLearn.ViewModel
{
    public static class SkillExtensions
    {
        public static SkillViewModel ToViewModel(this Skill model)
        {
            return new SkillViewModel
            {
                ID = model.ID,
               skill=model.skill
            };
        }
        public static Skill ToModel(this SkillEditViewModel editModel)
        {
            return new Skill
            {
                ID = editModel.ID,
                skill = editModel.skill

            };
        }
        public static SkillEditViewModel ToEditableViewModel(this Skill model)
        {
            return new SkillEditViewModel
            {
                ID = model.ID,
                skill = model.skill
            };
        }
    }
}
