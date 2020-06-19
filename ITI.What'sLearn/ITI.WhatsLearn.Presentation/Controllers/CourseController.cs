using BroadCaster.Helpers;
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

namespace ITI.WhatsLearn.Presentation.Controllers
{
    [AUTHORIZE(Roles = "User,Admin")]

    public class CourseController : ApiController
    {
        private readonly IHubContext Hub;

        private readonly CourseService courseService;
        private readonly UserTrackService userTrackService;

        private readonly TrackService TrackService;

        public CourseController(CourseService _courseService ,UserTrackService _userTrackService,TrackService _trackService)
        {
            
            courseService = _courseService;
            TrackService = _trackService;
            userTrackService = _userTrackService;
            Hub = GlobalHost.ConnectionManager.GetHubContext<WhatsLearnHub>();

        }

        [HttpGet]
        public ResultViewModel<IEnumerable<CourseViewModel>> GetList(int pageIndex, int pageSize = 20)
        {
            ResultViewModel<IEnumerable<CourseViewModel>> result
               = new ResultViewModel<IEnumerable<CourseViewModel>>();
            int count = 0;
            try
            {
                var Courses = courseService.GetAll(out count, 0, pageIndex, pageSize);
                result.Successed = true;
                result.Data = Courses;
            }
            catch (Exception ex)
            {
                result.Successed = false;
                result.Message = "Something Went Wrong !!";
            }
            return result;
        }
        [HttpPost]
        public ResultViewModel<CourseEditViewModel> Post(CourseEditViewModel Course)
        {
            ResultViewModel<CourseEditViewModel> result
                = new ResultViewModel<CourseEditViewModel>();

            string Token = Request.Headers.Authorization?
                   .Parameter;

            Dictionary<string, string>
                            cliams = SecurityHelper.Validate(Token);
            int UserID = int.Parse(cliams.First(i => i.Key == "ID").Value);



            try
            {
                if (!ModelState.IsValid)
                {
                    result.Message = "In Valid Model State";
                }
                else
                {
                    CourseEditViewModel selectedCourse
                        = courseService.Add(Course);
                 

                    result.Successed = true;
                    result.Data = selectedCourse;
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
        public ResultViewModel<CourseViewModel> GetByID(int id)
        {
            ResultViewModel<CourseViewModel> result
                = new ResultViewModel<CourseViewModel>();
            try
            {
                var course = courseService.GetByID(id);
                result.Successed = true;
                result.Data = course.ToViewModel();
            }
            catch (Exception ex)
            {
                result.Successed = false;
                result.Message = "Something Went Wrong !!";
            }
            return result;
        }
        [HttpPost]
        public ResultViewModel<CourseEditViewModel> Update(CourseEditViewModel Course)
        {
            ResultViewModel<CourseEditViewModel> result
              = new ResultViewModel<CourseEditViewModel>();

            try
            {
                if (!ModelState.IsValid)
                {
                    result.Message = "In Valid Model State";
                }
                else
                {
                    CourseEditViewModel selectedCourse
                        = courseService.Update(Course);
                    result.Successed = true;
                    result.Data = selectedCourse;
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
        public ResultViewModel<CourseEditViewModel> Delete(int id)
        {
            ResultViewModel<CourseEditViewModel> result
             = new ResultViewModel<CourseEditViewModel>();

            try
            {
                if (!ModelState.IsValid)
                {
                    result.Message = "In Valid Model State";
                }
                else
                {
                    courseService.Remove(id);
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
