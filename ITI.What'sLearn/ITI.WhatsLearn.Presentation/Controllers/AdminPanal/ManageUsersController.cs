﻿using ITI.WhatsLearn.Entities;
using ITI.WhatsLearn.Presentation.Filters;
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
    [AUTHORIZE(Roles = "Admin")]

    public class ManageUsersController : ApiController
    {

        private readonly UserService userService;
        public ManageUsersController(UserService _userService)
        {
            userService = _userService;
        }
        //[HttpGet]
        //public ResultViewModel<IEnumerable<ManageUserViewModel>> GetList(int PageIndex, int PageSize)
        //{

        //    ResultViewModel<IEnumerable<ManageUserViewModel>> result
        //      = new ResultViewModel<IEnumerable<ManageUserViewModel>>();

        //    try
        //    {
        //        var users = userService.GetAll(PageIndex, PageSize)?.Select(u => new ManageUserViewModel
        //        {
        //            ID = u.ID,
        //            Name = u.Name,
        //            Status = u.IsActive ? "Active" : "Not Active",
        //            TracksName =String.Join(" - ",u.Tracks.Select(i => i.Name))

        //        }); ; ;
        //        result.Successed = true;
        //        result.Data = users;
        //    }
        //    catch (Exception ex)
        //    {
        //        result.Successed = false;
        //        result.Message = "Something Went Wrong !!";
        //    }
        //    return result;

        //}
        //
        [HttpGet]
        public ResultViewModel<IEnumerable<ManageUserViewModel>> Search(int SortBy, int SerachOption, String SerachText, int PageIndex, int PageSize)
        {
            ResultViewModel<IEnumerable<ManageUserViewModel>> result
              = new ResultViewModel<IEnumerable<ManageUserViewModel>>();
            IEnumerable<UserViewModel> users = new List<UserViewModel>();
            int count = 0;
            try
            {
                if (SerachOption == 0)
                {
                    users = userService.GetAll(out count, SortBy, PageIndex, PageSize);
                }

                if (SerachOption == 1)//By Name
                {

                    users = userService.SearchByName(out count, SortBy, SerachText, pageIndex: PageIndex, pageSize: PageSize);


                }
                else if (SerachOption == 2)//BY TrackName
                {
                    users = userService.SearchByTrackName(out count, SortBy, SerachText, pageIndex: PageIndex, pageSize: PageSize);
                }

                var Users = users.Select(u => new ManageUserViewModel
                {
                    ID = u.ID,
                    Name = u.Name,
                    Status = u.IsActive ? "Active" : "Not Ative",
                    TracksName =
                            string.Join(" - ", u.Tracks.Select(i => i.Name).ToArray())

                });
                result.Successed = true;
                result.Count = userService.Count();
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
        public bool Delete(int id)
        {
            if (userService.GetByID(id) != null)
            {
                userService.Remove(id);
                return true;
            }
            else
                return false;


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
                        Gender = user.Gender == 1 ? "Male" : "Female",

                        Phone = user.Phone,
                        Image = user.Image,
                        Tracks = user.Tracks.Count() > 0 ? user.Tracks.Select(i => new UserTracksViewModel
                        {
                            ID = i.TrackID,
                            TrackName = i.Track.Name,
                            FinshedCourses = i.FinishedCourses.Count() > 0 ? i.FinishedCourses.Select(x => x.course.Name).ToList() : null,
                            Progress = i.FinishedCourses.Count() > 0 ? Math.Ceiling(((float)i.FinishedCourses.Count() / i.Track.Courses.Count()) * 100) : 0,
                            CuurentCourse = i.Track.Courses.Count() > 0 ? i.Track.Courses.Skip(i.FinishedCourses.Count()).First().Course.Name : null,
                            FutureCourses = i.FinishedCourses.Count() > 0 ? i.Track.Courses.Skip(i.FinishedCourses.Count() + 1).Select(x => x.Course.Name).ToList() : i.Track.Courses.Select(x => x.Course.Name).Skip(1).ToList(),
                        }).ToList() : null
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


    }
}

