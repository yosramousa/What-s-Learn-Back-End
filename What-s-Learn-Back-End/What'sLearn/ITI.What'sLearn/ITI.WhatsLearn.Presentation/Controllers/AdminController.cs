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
    public class AdminController : ApiController
    {
        private readonly AdminService adminService;
        public AdminController(AdminService _adminService)
        {
            adminService = _adminService;
        }

        [HttpGet]
        public ResultViewModel<IEnumerable<AdminViewModel>> GetList(int pageIndex, int pageSize = 20)
        {
            ResultViewModel<IEnumerable<AdminViewModel>> result
               = new ResultViewModel<IEnumerable<AdminViewModel>>();

            try
            {
                var admins = adminService.GetAll(pageIndex, pageSize);
                result.Successed = true;
                result.Data = admins;
            }
            catch (Exception ex)
            {
                result.Successed = false;
                result.Message = "Something Went Wrong !!";
            }
            return result;
        }
        [HttpPost]
        public ResultViewModel<AdminEditViewModel> Post(AdminEditViewModel Admin)
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
                        = adminService.Add(Admin);

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
        [HttpGet]
        public ResultViewModel<AdminViewModel> GetByID(int id)
        {
            ResultViewModel<AdminViewModel> result
                = new ResultViewModel<AdminViewModel>();
            try
            {
                var admin = adminService.GetByID(id);
                result.Successed = true;
                result.Data = admin;
            }
            catch (Exception ex)
            {
                result.Successed = false;
                result.Message = "Something Went Wrong !!";
            }
            return result;
        }
        [HttpPost]
        public ResultViewModel<AdminViewModel> Login(AdminViewModel Admin)
        {
            ResultViewModel<AdminViewModel> result
              = new ResultViewModel<AdminViewModel>();
            try
            {
                var user = GetByID(Admin.ID);
                    //adminService.Get(i => i.Name == Admin.Name && i.Password == Admin.Password);

                if (user == null)
                {
                    result.Successed = false;
                    result.Message = "Invalid User Name Or password";
                }
                else
                {
                    result.Successed = true;
                    //Admin.Token = SecurityHelper.GenerateToken(user);
                    Admin.Password = null;
                    result.Data = Admin;
                }

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
        [HttpGet]
        public ResultViewModel<AdminEditViewModel> Delete(int id)
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
                    adminService.Remove(id);
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
