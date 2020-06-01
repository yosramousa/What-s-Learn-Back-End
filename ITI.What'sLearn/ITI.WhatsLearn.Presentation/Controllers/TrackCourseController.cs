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
    public class TrackCourseController : ApiController
    {
        private readonly TrackCourseService TrackCourseService;
        public TrackCourseController(TrackCourseService _TrackCourseService)
        {
            TrackCourseService = _TrackCourseService;
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

    }
}
