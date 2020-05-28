using ITI.WhatsLearn.Entities;
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
    public class ManageUsersController : ApiController
    {

        private readonly UserService userService;
        public ManageUsersController(UserService _userService)
        {
            userService = _userService;
        }
        [HttpGet]
        public ResultViewModel<IEnumerable<ManageUserViewModel>> GetList(int PageIndex, int PageSize)
        {

            ResultViewModel<IEnumerable<ManageUserViewModel>> result
              = new ResultViewModel<IEnumerable<ManageUserViewModel>>();

            try
            {
                var users = userService.GetAll(PageIndex, PageSize)?.Select(u => new ManageUserViewModel
                {
                    ID = u.ID,
                    Name = u.Name,
                    Status = u.IsActive ? "Active" : "Not Active",
                    TracksName = u.Tracks.Select(i => i.Name).ToList()

                });
                result.Successed = true;
                result.Data = users;
            }
            catch (Exception ex)
            {
                result.Successed = false;
                result.Message = "Something Went Wrong !!";
            }
            return result;

        }
        [HttpGet]
        public ResultViewModel<IEnumerable<ManageUserViewModel>> Search(int SerachOption, String SerachText, int PageIndex, int PageSize)
        {
            ResultViewModel<IEnumerable<ManageUserViewModel>> result
              = new ResultViewModel<IEnumerable<ManageUserViewModel>>();
            IEnumerable<UserViewModel> users = new List<UserViewModel>();
            try
            {

                if (SerachOption == 0)//By Name
                {
                    users = userService.SearchByName(SerachText, pageIndex: PageIndex, pageSize: PageSize);

                }
                else if (SerachOption == 1)//BY TrackName
                {
                    users = userService.SearchByTrackName(SerachText, pageIndex: PageIndex, pageSize: PageSize);
                }

                var Users = users.Select(u => new ManageUserViewModel
                {
                    ID = u.ID,
                    Name = u.Name,
                    Status = u.IsActive ? "Active" : "Disable",
                    TracksName = u.Tracks.Select(i => i.Name).ToList()

                });
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
        [HttpGet]
        public String Delete(int id)
        {
            if (userService.GetByID(id) != null)
            {
                userService.Remove(id);
                return "User Deleted Sucessfully";
            }
            else
                return "User Not Found !";


        }
        [HttpGet]
        public ResultViewModel<UserDetailsViewModel> Details(int id)
        {
            ResultViewModel<UserDetailsViewModel> result
                = new ResultViewModel<UserDetailsViewModel>();

            try
            {
                User user = userService.GetByID(id);
                if (user != null)
                {
                    UserDetailsViewModel userDetails = new UserDetailsViewModel()
                    {
                        ID = user.ID,
                        Name = user.Name,
                        Email = user.Email,
                        Adress = user.Adress,
                        Age = user.Age,
                        Education = user.Education,
                        Gender = user.Gender,
                        Phone = user.Phone,
                        Image = user.Image,
                        Tracks = user.Tracks.Select(i => new UserTracksViewModel
                        {
                            TrackName = i.Track.Name,
                            FinshedCourses = i.FinishedCourses.Select(x => x.course.Name)?.ToList(),
                            Progress = i.FinishedCourses != null ? i.FinishedCourses.Count() / i.Track.Courses.Count() : 0,
                            CuurentCourse = i.FinishedCourses != null ? i.Track.Courses.Skip(i.FinishedCourses.Count()).First().Course.Name : i.Track.Courses.First().Course.Name,
                            FutureCourses = i.FinishedCourses != null ? i.Track.Courses.Skip(i.FinishedCourses.Count() + 1).Select(x => x.Course.Name).ToList() : i.Track.Courses.Select(x => x.Course.Name).ToList(),
                        }).ToList()


                    };
                    result.Successed = true;
                    result.Message = "Sucess";
                    result.Data = userDetails;
                }
                else
                {
                    result.Successed = false;
                    result.Message = "User Not Found";

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
        public String ChangeStatus(int id)
        {
            try
            {
                //User u = userService.GetByID(id);
                //u.IsActive = !u.IsActive;
                //userService.Update(u.ToEditableViewModel());
                if (userService.ChangeStatus(id))
                    return "Status Updated Sucessfully";
                else
                    return "User Not Found";

            }
            catch (Exception e)
            {
                return "Error";
            }
        }

        //Name
        //Stauts
        //Tracks (Name)
        //Details >>UserProfule
        //Delete 
        //Search (Name :0 ,Track:1)
        //Pagntion (PageSize , PageIndex), Filte

    }
}
