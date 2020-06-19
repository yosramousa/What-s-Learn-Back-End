using BroadCaster.Helpers;
using ITI.WhatsLearn.Entities;
using ITI.WhatsLearn.Presentation.Filters;
using ITI.WhatsLearn.Presentation.Hubs;
using ITI.WhatsLearn.Services;
using ITI.WhatsLearn.ViewModel;
using Microsoft.AspNet.SignalR;
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
        private readonly ConfigurationService ConfigService;
        private readonly IHubContext Hub;


        public UserController(UserService _UserService, ConfigurationService _configService)
        {
            UserService = _UserService;
            ConfigService = _configService;
            Hub = GlobalHost.ConnectionManager.GetHubContext<WhatsLearnHub>();

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
                UserViewModel user = UserService.Get(_loginModel.Email, _loginModel.Password)?.FirstOrDefault();
                if (user == null)
                {
                    result.Successed = false;
                    result.Message = "Invalid User Name Or password";
                }
                else
                {
                    result.Successed = true;
                    _loginModel.Role = "User";
                    _loginModel.ID = user.ID;
                    _loginModel.Name = user.Name;
                    _loginModel.Token = SecurityHelper.GenerateToken(_loginModel);
                    _loginModel.Password = null;
                    ConfigService.Increment("VisitorCount");

                    Hub.Clients.All.VisitorCount(ConfigService.Count("VisitorCount"));





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
        [AUTHORIZE(Roles = "User,Admin")]


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
        //  [AUTHORIZE(Roles = "User")]

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


                    if (UserService.GetAll().Where(i => i.Email == User.Email).Count() == 0)
                    {
                        UserEditViewModel selectedUser
                      = UserService.Add(User);

                        Hub.Clients.All.UserCount(new { UserCount = UserService.Count(), ChartData = UserService.UpdateLineChart() });

                        result.Successed = true;


                        result.Data = selectedUser;

                    }
                    else
                    {
                        result.Successed = false;
                        result.Message = "This Email Already Token";
                    }

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
        [AUTHORIZE(Roles = "User,Admin")]

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
                var User = UserService.GetByID(id)?.ToViewModel();
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

        [AUTHORIZE(Roles = "User,Admin")]

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
