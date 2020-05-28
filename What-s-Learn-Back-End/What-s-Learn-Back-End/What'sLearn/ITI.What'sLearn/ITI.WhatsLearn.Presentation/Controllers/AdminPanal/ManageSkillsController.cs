using ITI.WhatsLearn.ViewModel;
using ITI.WhatsLearnServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ITI.WhatsLearn.Presentation.Controllers.AdminPanal
{
    public class ManageSkillsController : ApiController
    {
        SkillService skillService;

        public ManageSkillsController(SkillService _skillkService)
        {
            skillService = _skillkService;

        }
        [HttpGet]
        public ResultViewModel<IEnumerable<SkillViewModel>> GetList(int PageIndex, int PageSize)
        {

            ResultViewModel<IEnumerable<SkillViewModel>> result
              = new ResultViewModel<IEnumerable<SkillViewModel>>();

            try
            {
                var skills = skillService.GetAll(pageIndex: PageIndex, pageSize: PageSize);
                result.Successed = true;
                result.Data = skills;
            }
            catch (Exception ex)
            {
                result.Successed = false;
                result.Message = "Something Went Wrong !!";
            }
            return result;

        }
       [HttpGet]
       public string Delete(int id)
        {
            if (skillService.GetByID(id)!= null)
            {
                skillService.Remove(id);
                return "skill Deleted Sucessfully";
            }
            else
                return "skill Not Found !";
        }
        [HttpPost]
        public ResultViewModel<SkillEditViewModel> Post(SkillEditViewModel skill)
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
                        = skillService.Add(skill);

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
        [HttpPost]
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

    }
}
