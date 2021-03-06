﻿using ITI.WhatsLearn.Entities;
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
    [AUTHORIZE(Roles = "User,Admin")]

    public class TrackCourseController : ApiController
    {
        private readonly IHubContext Hub;
        private readonly UserTrackService userTrackService;

        private readonly TrackCourseService TrackCourseService;

        private readonly CourseService courseService;
        private readonly TrackService TrackService;

        public TrackCourseController(CourseService _courseService, TrackCourseService _TrackCourseService, UserTrackService _userTrackService, TrackService _trackService)
        {
            courseService = _courseService;
            TrackService = _trackService;
            TrackCourseService = _TrackCourseService;
            userTrackService = _userTrackService;

            Hub = GlobalHost.ConnectionManager.GetHubContext<WhatsLearnHub>();

        }

        [HttpGet]
        public ResultViewModel<IEnumerable<TrackCourseViewModel>> GetList()
        {
            ResultViewModel<IEnumerable<TrackCourseViewModel>> result
                = new ResultViewModel<IEnumerable<TrackCourseViewModel>>();
            try
            {
                var TrackCourses = TrackCourseService.GetAll();
                result.Successed = true;
                result.Data = TrackCourses;
            }
            catch (Exception ex)
            {
                result.Successed = false;
                result.Message = "Something Went Wrong !!";
            }
            return result;
        }


        [HttpPost]
        public ResultViewModel<TrackCourseEditViewModel> Post(TrackCourseEditViewModel TrackCourse)
        {
            ResultViewModel<TrackCourseEditViewModel> result
                = new ResultViewModel<TrackCourseEditViewModel>();

            try
            {
                if (!ModelState.IsValid)
                {
                    result.Message = "In Valid Model State";
                }
                else
                {
                    TrackCourseEditViewModel selectedTrackCourse
                        = TrackCourseService.Add(TrackCourse);

                    var Users = userTrackService.GetAll().Where(i => i.TrackID == TrackCourse.TrackID).Select(i => i.UserID);

                    Hub.Clients.All.NewCourseAdded(new
                    {
                        Users,
                        CourseName = courseService.GetByID(TrackCourse.CourseID).Name,
                        TrackName = TrackService.GetByID(TrackCourse.TrackID).Name
                    });


                    result.Successed = true;
                    result.Data = selectedTrackCourse;
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
        public ResultViewModel<TrackCourseEditViewModel> Update(TrackCourseEditViewModel TrackCourse)
        {
            ResultViewModel<TrackCourseEditViewModel> result
                = new ResultViewModel<TrackCourseEditViewModel>();

            try
            {
                if (!ModelState.IsValid)
                {
                    result.Message = "In Valid Model State";
                }
                else
                {
                    TrackCourseEditViewModel selectedEmp
                        = TrackCourseService.Update(TrackCourse);

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
        public ResultViewModel<TrackCourseViewModel> GetByID(int id)
        {
            ResultViewModel<TrackCourseViewModel> result
                = new ResultViewModel<TrackCourseViewModel>();
            try
            {
                var TrackCourse = TrackCourseService.GetByID(id)?.ToViewModel();
                result.Successed = true;
                result.Data = TrackCourse;
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
            if (TrackCourseService.GetByID(id) != null)
            {
                TrackCourseService.Remove(id);
                return "TrackCourse Deleted Sucessfully";
            }
            else
                return "TrackCourse Not Found !";
        }


        [HttpPost]
        public ResultViewModel<IEnumerable<TrackCourseEditViewModel>> Add(List<TrackCourseEditViewModel> TrackCourses)
        {
            ResultViewModel<IEnumerable<TrackCourseEditViewModel>> result
                = new ResultViewModel<IEnumerable<TrackCourseEditViewModel>>();



            List<TrackCourseEditViewModel> courses = new List<TrackCourseEditViewModel>();

            try
            {
                if (TrackCourses.Count() == 0)
                {
                    result.Message = "List Is Empty";
                    result.Successed = false;
                    
                }
                else
                {
                    foreach (var c in TrackCourses)
                    {
                        if (!TrackCourseService.ISExist(c.TrackID, c.CourseID))
                            courses.Add(TrackCourseService.Add(c));
                    }
                    var Users = userTrackService.GetAll().Where(i => i.TrackID == TrackCourses.FirstOrDefault()?.TrackID).Select(i => i.UserID);

                    Hub.Clients.All.NewCourseAdded(new
                    {
                        Users,
                        CourseName = courseService.GetByID(TrackCourses.FirstOrDefault().CourseID).Name,
                        TrackName = TrackService.GetByID(TrackCourses.FirstOrDefault().TrackID).Name
                    });


                    result.Successed = true;
                     result.Data = courses;
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
