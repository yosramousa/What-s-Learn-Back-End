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
    public class UserSocialLinkController : ApiController
    {
        private readonly UserSocialLinkService UserSocialLinkService;
        public UserSocialLinkController(UserSocialLinkService _UserSocialLinkService)
        {
            UserSocialLinkService = _UserSocialLinkService;
        }

        [HttpGet]
        public ResultViewModel<IEnumerable<UserSocialLinkViewModel>> GetList()
        {
            ResultViewModel<IEnumerable<UserSocialLinkViewModel>> result
                = new ResultViewModel<IEnumerable<UserSocialLinkViewModel>>();
            try
            {
                var UserSocialLinks = UserSocialLinkService.GetAll();
                result.Successed = true;
                result.Data = UserSocialLinks;
            }
            catch (Exception ex)
            {
                result.Successed = false;
                result.Message = "Something Went Wrong !!";
            }
            return result;
        }


        [HttpPost]
        public ResultViewModel<UserSocialLinkEditViewModel> Post(UserSocialLinkEditViewModel UserSocialLink)
        {
            ResultViewModel<UserSocialLinkEditViewModel> result
                = new ResultViewModel<UserSocialLinkEditViewModel>();

            try
            {
                if (!ModelState.IsValid)
                {
                    result.Message = "In Valid Model State";
                }
                else
                {
                    UserSocialLinkEditViewModel selectedUserSocialLink
                        = UserSocialLinkService.Add(UserSocialLink);

                    result.Successed = true;
                    result.Data = selectedUserSocialLink;
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
        public ResultViewModel<UserSocialLinkEditViewModel> Update(UserSocialLinkEditViewModel UserSocialLink)
        {
            ResultViewModel<UserSocialLinkEditViewModel> result
                = new ResultViewModel<UserSocialLinkEditViewModel>();

            try
            {
                if (!ModelState.IsValid)
                {
                    result.Message = "In Valid Model State";
                }
                else
                {
                    UserSocialLinkEditViewModel selectedEmp
                        = UserSocialLinkService.Update(UserSocialLink);

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
        public ResultViewModel<UserSocialLinkViewModel> GetByID(int id)
        {
            ResultViewModel<UserSocialLinkViewModel> result
                = new ResultViewModel<UserSocialLinkViewModel>();
            try
            {
                var UserSocialLink = UserSocialLinkService.GetByID(id)?.ToViewModel();
                result.Successed = true;
                result.Data = UserSocialLink;
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
            if (UserSocialLinkService.GetByID(id) != null)
            {
                UserSocialLinkService.Remove(id);
                return "UserSocialLink Deleted Sucessfully";
            }
            else
                return "UserSocialLink Not Found !";
        }

    }
}
