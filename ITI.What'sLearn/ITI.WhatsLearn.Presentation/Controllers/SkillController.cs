using ITI.WhatsLearn.ViewModel;
using ITI.WhatsLearnServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ITI.WhatsLearn.Presentation.Controllers
{
    public class SkillController : ApiController
    {

        private readonly SkillService skillService;
        public SkillController(SkillService _skillService)
        {
            skillService = _skillService;
        }

        [HttpGet]
        public ResultViewModel<IEnumerable<SkillViewModel>> GetList(int pageIndex, int pageSize = 20)
        {
            ResultViewModel<IEnumerable<SkillViewModel>> result
               = new ResultViewModel<IEnumerable<SkillViewModel>>();

            try
            {
                var Skills = skillService.GetAll(pageIndex, pageSize);
                result.Successed = true;
                result.Data = Skills;
            }
            catch (Exception ex)
            {
                result.Successed = false;
                result.Message = "Something Went Wrong !!";
            }
            return result;
        }
        [HttpPost]
        public ResultViewModel<SkillEditViewModel> Post(SkillEditViewModel Skill)
        {
            ResultViewModel<SkillEditViewModel> result
                = new ResultViewModel<SkillEditViewModel>();

            try
            {
                if (!ModelState.IsValid)
                {
                    result.Message = "In Valid Model State";
                }
                else
                {
                    SkillEditViewModel selectedSkill
                        = skillService.Add(Skill);

                    result.Successed = true;
                    result.Data = selectedSkill;
                }
            }
            catch (Exception ex)
            {
                result.Successed = false;
                result.Message = "Semething Went Wrong";
            }
            return result;
        }
        [HttpGet]
        public ResultViewModel<SkillViewModel> GetByID(int id)
        {
            ResultViewModel<SkillViewModel> result
                = new ResultViewModel<SkillViewModel>();
            try
            {
                var skill = skillService.GetByID(id);
                result.Successed = true;
                result.Data = skill;
            }
            catch (Exception ex)
            {
                result.Successed = false;
                result.Message = "Something Went Wrong !!";
            }
            return result;
        }
        [HttpPost]

        [HttpGet]
        public ResultViewModel<SkillEditViewModel> Update(SkillEditViewModel Skill)
        {
            ResultViewModel<SkillEditViewModel> result
              = new ResultViewModel<SkillEditViewModel>();

            try
            {
                if (!ModelState.IsValid)
                {
                    result.Message = "In Valid Model State";
                }
                else
                {
                    SkillEditViewModel selectedSkill
                        = skillService.Update(Skill);
                    result.Successed = true;
                    result.Data = selectedSkill;
                }
            }
            catch (Exception ex)
            {
                result.Successed = false;
                result.Message = "Semething Went Wrong";
            }
            return result;
        }
        [HttpGet]
        public ResultViewModel<SkillEditViewModel> Delete(int id)
        {
            ResultViewModel<SkillEditViewModel> result
             = new ResultViewModel<SkillEditViewModel>();

            try
            {
                if (!ModelState.IsValid)
                {
                    result.Message = "In Valid Model State";
                }
                else
                {
                    skillService.Remove(id);
                    result.Successed = true;
                }
            }
            catch (Exception ex)
            {
                result.Successed = false;
                result.Message = "Semething Went Wrong";
            }
            return result;

        }
    }
}
