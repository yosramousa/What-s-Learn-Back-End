using BroadCaster.Helpers;
using ITI.WhatsLearn.Services;
using ITI.WhatsLearn.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ITI.WhatsLearn.Presentation.Controllers
{
    public class UserProfileController : ApiController
    {
        private readonly UserService userService;
        private readonly SkillService skillService;

        public UserProfileController(UserService _UserService , SkillService _skillService)
        {
            userService = _UserService;
            skillService = _skillService;
        }


        [HttpGet]
        public ResultViewModel<UserViewModel> GetProfile()
        {

            ResultViewModel<UserViewModel> result
                   = new ResultViewModel<UserViewModel>();
            
            string Token = Request.Headers.Authorization?
                    .Parameter;

            Dictionary<string, string>
                            cliams = SecurityHelper.Validate(Token);
            string ID = cliams.FirstOrDefault(i => i.Key == "ID").Value;
            try
            {
                var User = userService.GetByID(int.Parse(ID));
                result.Successed = true;
                result.Data = User.ToViewModel();
            }
            catch (Exception ex)
            {
                result.Successed = false;
                result.Message = "Something Went Wrong !!";
            }


            return result;
        }

        [HttpPost]
        public ResultViewModel<UserEditViewModel> Update(UserEditViewModel User)
        {
            ResultViewModel<UserEditViewModel> result
                = new ResultViewModel<UserEditViewModel>();

            try
            {
                if (!ModelState.IsValid)
                {
                    result.Message = "In Valid Model State";
                }
                else
                {
                    UserEditViewModel selectedEmp
                        = userService.Update(User);

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

        public ResultViewModel<IEnumerable<SkillViewModel>> GetAllSkills()
        {
            ResultViewModel<IEnumerable<SkillViewModel>> result =
                new ResultViewModel<IEnumerable<SkillViewModel>>();

            try
            {
                result.Data = skillService.GetAll();
                result.Message = "Skills gotten succesfuly";
                result.Successed = true;
            }
            catch
            {

                result.Message = "Something went wrong!!";
                result.Successed = false;
            }
            return result;
        }
    }
}
