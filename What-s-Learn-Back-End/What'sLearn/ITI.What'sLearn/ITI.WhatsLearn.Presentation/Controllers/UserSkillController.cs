using ITI.WhatsLearn.Entities;
using ITI.WhatsLearn.Services;
using ITI.WhatsLearn.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ITI.WhatsLearn.Presentation
{
    public class UserSkillController : ApiController
    {
        private readonly UserSkillService UserSkillService;
        public UserSkillController(UserSkillService _UserSkillService)
        {
            UserSkillService = _UserSkillService;
        }

        [HttpGet]
        public ResultViewModel<IEnumerable<UserSkillViewModel>> GetList()
        {
            ResultViewModel<IEnumerable<UserSkillViewModel>> result
                = new ResultViewModel<IEnumerable<UserSkillViewModel>>();
            try
            {
                var UserSkills = UserSkillService.GetAll();
                result.Successed = true;
                result.Data = UserSkills;
            }
            catch (Exception ex)
            {
                result.Successed = false;
                result.Message = "Something Went Wrong !!";
            }
            return result;
        }


        [HttpPost]
        public ResultViewModel<UserSkillEditViewModel> Post(UserSkillEditViewModel UserSkill)
        {
            ResultViewModel<UserSkillEditViewModel> result
                = new ResultViewModel<UserSkillEditViewModel>();

            try
            {
                if (!ModelState.IsValid)
                {
                    result.Message = "In Valid Model State";
                }
                else
                {
                    UserSkillEditViewModel selectedUserSkill
                        = UserSkillService.Add(UserSkill);

                    result.Successed = true;
                    result.Data = selectedUserSkill;
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
        public ResultViewModel<UserSkillEditViewModel> Update(UserSkillEditViewModel UserSkill)
        {
            ResultViewModel<UserSkillEditViewModel> result
                = new ResultViewModel<UserSkillEditViewModel>();

            try
            {
                if (!ModelState.IsValid)
                {
                    result.Message = "In Valid Model State";
                }
                else
                {
                    UserSkillEditViewModel selectedEmp
                        = UserSkillService.Update(UserSkill);

                    result.Successed = true;
                    result.Data = selectedEmp;
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
        public ResultViewModel<UserSkillViewModel> GetByID(int id)
        {
            ResultViewModel<UserSkillViewModel> result
                = new ResultViewModel<UserSkillViewModel>();
            try
            {
                var UserSkill = UserSkillService.GetByID(id)?.ToViewModel();
                result.Successed = true;
                result.Data = UserSkill;
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
            if (UserSkillService.GetByID(id) != null)
            {
                UserSkillService.Remove(id);
                return "UserSkill Deleted Sucessfully";
            }
            else
                return "UserSkill Not Found !";
        }

    }
}
