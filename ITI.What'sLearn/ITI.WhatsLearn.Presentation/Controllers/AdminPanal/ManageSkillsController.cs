using ITI.WhatsLearn.Presentation.Filters;
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
   [AUTHORIZE(Roles = "Admin")]
    public class ManageSkillsController : ApiController
    {
        SkillService skillService;

        public ManageSkillsController(SkillService _skillkService)
        {
            skillService = _skillkService;

        }
        [HttpGet]
        public ResultViewModel<IEnumerable<SkillViewModel>> GetList( int SortBy,int PageIndex, int PageSize)
        {

            ResultViewModel<IEnumerable<SkillViewModel>> result
              = new ResultViewModel<IEnumerable<SkillViewModel>>();
            int count = 0;
            try
            {
                var skills = skillService.GetAll(out count, SortBy, pageIndex: PageIndex, pageSize: PageSize);
                
                result.Successed = true;
                result.Data = skills;
                result.Count = count;
            }
            catch (Exception ex)
            {
                result.Successed = false;
                result.Message = "Something Went Wrong !!";
            }
            return result;

        }
       [HttpGet]
       public bool Delete(int id)
        {
            if (skillService.GetByID(id)!= null)
            {
                skillService.Remove(id);
                return true;
            }
            else
                return false;
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


    }
}
