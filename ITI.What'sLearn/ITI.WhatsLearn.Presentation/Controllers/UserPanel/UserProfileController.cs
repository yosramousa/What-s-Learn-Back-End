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
        public UserProfileController(UserService _UserService)
        {
            userService = _UserService;
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
            string ID = cliams.First(i => i.Key == "ID").Value;
            try
            {
                var admin = userService.GetByID(int.Parse(ID));
                result.Successed = true;
                result.Data = admin.ToViewModel();
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


    }
}
