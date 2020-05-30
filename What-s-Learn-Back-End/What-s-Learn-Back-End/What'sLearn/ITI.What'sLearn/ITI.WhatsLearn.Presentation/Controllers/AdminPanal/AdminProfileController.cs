using BroadCaster.Helpers;
using ITI.WhatsLearn.Presentation.Filters;
using ITI.WhatsLearn.ViewModel;
using ITI.WhatsLearnServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Routing;
using System.Web.Security;

namespace ITI.WhatsLearn.Presentation.Controllers
{
    [AUTHORIZE(Roles = "Admin")]

    public class AdminProfileController : ApiController
    {
        private readonly AdminService adminService;
        public AdminProfileController(AdminService _adminService)
        {
            adminService = _adminService;
        }


        [HttpGet]
        public ResultViewModel<AdminViewModel> GetProfile()
        {

            ResultViewModel<AdminViewModel> result
                   = new ResultViewModel<AdminViewModel>();
            string Token = Request.Headers.Authorization?
                    .Parameter;

            Dictionary<string, string>
                            cliams = SecurityHelper.Validate(Token);
            string ID = cliams.First(i => i.Key == "ID").Value;
            try
                {
                    var admin = adminService.GetByID(int.Parse(ID));
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

       
        [HttpGet]
        public ResultViewModel<AdminEditViewModel> Update(AdminEditViewModel Admin)
        {
            ResultViewModel<AdminEditViewModel> result
              = new ResultViewModel<AdminEditViewModel>();

            try
            {
                if (!ModelState.IsValid)
                {
                    result.Message = "In Valid Model State";
                }
                else
                {
                    AdminEditViewModel selectedAdmin
                        = adminService.Update(Admin);
                    result.Successed = true;
                    result.Data = selectedAdmin;
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
