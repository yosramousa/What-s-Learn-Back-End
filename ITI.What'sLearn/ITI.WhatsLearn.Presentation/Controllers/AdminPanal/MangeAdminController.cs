using ITI.WhatsLearn.Entities;
using ITI.WhatsLearn.Presentation.Filters;
using ITI.WhatsLearn.Services;
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
    public class MangeAdminsController : ApiController
    {

        private readonly AdminService adminService;
        public MangeAdminsController(AdminService _adminService)
        {
            adminService = _adminService;
        }
        [HttpGet]
        public ResultViewModel<IEnumerable<MangeAdminViewModel>> GetList(int PageIndex, int PageSize)
        {

            ResultViewModel<IEnumerable<MangeAdminViewModel>> result
              = new ResultViewModel<IEnumerable<MangeAdminViewModel>>();
            int count;
            try
            {
                var admins = adminService.GetAll(out count, PageIndex, PageSize)?.Select(u => new MangeAdminViewModel
                {
                    ID = u.ID,
                    Name = u.Name,
                    Status = u.IsActive ? "Active" : "Not Active",
                });
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
        [HttpGet]
        public ResultViewModel<IEnumerable<MangeAdminViewModel>> Search(int SearchOp, String SearchText, int PageIndex, int PageSize)
        {
            ResultViewModel<IEnumerable<MangeAdminViewModel>> result
              = new ResultViewModel<IEnumerable<MangeAdminViewModel>>();
            IEnumerable<AdminViewModel> admins = new List<AdminViewModel>();
            int count = 0;

            try
            {
                if (SearchOp == 0)//By Name
                {
                    admins = adminService.GetAll(out count, PageIndex, PageSize);

                }
                if (SearchOp == 1)//By Name
                {
                    admins = adminService.SearchByName(SearchText,out count, pageIndex: PageIndex, pageSize: PageSize);

                }
                var Admins = admins.Select(u => new MangeAdminViewModel
                {
                    ID = u.ID,
                    Name = u.Name,
                    Status = u.IsActive ? "Active" : "Disable",
                    Image=u.Image


                });
                result.Successed = true;
                result.Data = Admins;
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
        public String Delete(int id)
        {
            if (adminService.GetByID(id) != null)
            {
                adminService.Remove(id);
                return "Admin Deleted Sucessfully";
            }
            else
                return "Admin Not Found !";


        }
        [HttpGet]
        public ResultViewModel<AdminViewModel> Details(int id)
        {
            ResultViewModel<AdminViewModel> result
                = new ResultViewModel<AdminViewModel>();

            try
            {
                Admin admin = adminService.GetByID(id);
                if (admin != null)
                {
                    result.Successed = true;
                    result.Message = "Sucess";
                    result.Data = admin.ToViewModel();
                }
                else
                {
                    result.Successed = false;
                    result.Message = "Admin Not Found";
                }
            }
            catch (Exception ex)
            {
                result.Successed = false;
                result.Message = "Admin Not Found !!";
            }
            return result;
        }
        [HttpGet]
        public String ChangeStatus(int id)
        {
            try
            {
                if (adminService.ChangeStatus(id))
                    return "Status Updated Sucessfully";
                else
                    return "Admin Not Found";
            }
            catch (Exception e)
            {
                return "Status Not Updated ";
            }
        }

        [HttpPost]
        public ResultViewModel<AdminEditViewModel> Post([FromBody]AdminEditViewModel Admin)
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

        //Name
        //Stauts

        //Details >>AdminProfile
        //Add
        //Delete 
        //Search (Name :0 ,Track:1)
        //Pagntion (PageSize , PageIndex), Filte


    }
}
