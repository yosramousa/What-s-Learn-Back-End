using BroadCaster.Helpers;
using ITI.WhatsLearn.Entities;
using ITI.WhatsLearn.Presentation.Filters;
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
  
    public class UserController : ApiController
    {
        private readonly UserService UserService;
        public UserController(UserService _UserService)
        {
            UserService = _UserService;
        }

        [HttpPost]
        public ResultViewModel<LoginModel> Login(LoginModel _loginModel)
        {
            ResultViewModel<LoginModel> result
              = new ResultViewModel<LoginModel>();
            if (!ModelState.IsValid)
            {
                result.Message = "In Valid Model State";
            }
            try
            {
                UserViewModel user = UserService.Get(_loginModel.Email, _loginModel.Password)?.First();
                if (user == null)
                {
                    result.Successed = false;
                    result.Message = "Invalid User Name Or password";
                }
                else
                {
                     result.Successed = true;
                    _loginModel.Role = "User";
                    _loginModel.ID =user.ID;
                    _loginModel.Name = user.Name;
                    _loginModel.Token = SecurityHelper.GenerateToken(_loginModel);
                    _loginModel.Password = null;
                   
                  
                    result.Data = _loginModel;
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
        public ResultViewModel<IEnumerable<UserViewModel>> GetList()
        {
            ResultViewModel<IEnumerable<UserViewModel>> result
                = new ResultViewModel<IEnumerable<UserViewModel>>();
            try
            {
                var Users = UserService.GetAll();
                result.Successed = true;
                result.Data = Users;
            }
            catch (Exception ex)
            {
                result.Successed = false;
                result.Message = "Something Went Wrong !!";
            }
            return result;
        }
       
        [HttpPost]
        public ResultViewModel<UserEditViewModel> Post(UserEditViewModel User)
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
                    UserEditViewModel selectedUser
                        = UserService.Add(User);
                   
                    result.Successed = true;
                    result.Data = selectedUser;
                }
            }
            catch (Exception ex)
            {
                result.Successed = false;
                result.Message = "Semething Went Wrong";
            }
            return result;
        }
        //[AUTHORIZE(Roles = "User,Admin")]
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
                        = UserService.Update(User);

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
        [AUTHORIZE(Roles = "User,Admin")]
        
        public ResultViewModel<UserViewModel> GetByID(int id)
        {
            ResultViewModel<UserViewModel> result
                = new ResultViewModel<UserViewModel>();
            try
            {
                var User =  UserService.GetByID(id)?.ToViewModel();
                result.Successed = true;
                result.Data = User;
            }
            catch (Exception ex)
            {
                result.Successed = false;
                result.Message = "Something Went Wrong !!";
            }
            return result;
        }
        [AUTHORIZE(Roles = "Admin")]
        [HttpGet]
        public string Delete(int id)
        {
            if (UserService.GetByID(id) != null)
            {
                UserService.Remove(id);
                return "User Deleted Sucessfully";
            }
            else
                return "User Not Found !";
        }

    }
}
