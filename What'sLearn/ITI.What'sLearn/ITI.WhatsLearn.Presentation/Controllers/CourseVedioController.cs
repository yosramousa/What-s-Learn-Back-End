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
    public class CourseVedioController : ApiController
    {
        private readonly CourseVedioService courseVedioService;
        public CourseVedioController(CourseVedioService _courseVedioService)
        {
            courseVedioService = _courseVedioService;
        }

        [HttpGet]
        public ResultViewModel<IEnumerable<CourseVedioViewModel>> GetList(int pageIndex, int pageSize = 20)
        {
            ResultViewModel<IEnumerable<CourseVedioViewModel>> result
               = new ResultViewModel<IEnumerable<CourseVedioViewModel>>();

            try
            {
                var Courses = courseVedioService.GetAll(pageIndex, pageSize);
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
        public ResultViewModel<CourseVedioEditViewModel> Post(CourseVedioEditViewModel CourseVedio)
        {
            ResultViewModel<CourseVedioEditViewModel> result
                = new ResultViewModel<CourseVedioEditViewModel>();

            try
            {
                if (!ModelState.IsValid)
                {
                    result.Message = "In Valid Model State";
                }
                else
                {
                    CourseVedioEditViewModel selectedCourseVedio
                        = courseVedioService.Add(CourseVedio);

                    result.Successed = true;
                    result.Data = selectedCourseVedio;
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
        public ResultViewModel<CourseVedioViewModel> GetByID(int id)
        {
            ResultViewModel<CourseVedioViewModel> result
                = new ResultViewModel<CourseVedioViewModel>();
            try
            {
                var course = courseVedioService.GetByID(id);
                result.Successed = true;
                result.Data = course;
            }
            catch (Exception ex)
            {
                result.Successed = false;
                result.Message = "Something Went Wrong !!";
            }
            return result;
        }
        [HttpGet]
        public ResultViewModel<CourseVedioEditViewModel> Update(CourseVedioEditViewModel CourseVedio)
        {
            ResultViewModel<CourseVedioEditViewModel> result
              = new ResultViewModel<CourseVedioEditViewModel>();

            try
            {
                if (!ModelState.IsValid)
                {
                    result.Message = "In Valid Model State";
                }
                else
                {
                    CourseVedioEditViewModel selectedCourseVedio
                        = courseVedioService.Update(CourseVedio);
                    result.Successed = true;
                    result.Data = selectedCourseVedio;
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
        public ResultViewModel<CourseVedioEditViewModel> Remove(int id)
        {
            ResultViewModel<CourseVedioEditViewModel> result
             = new ResultViewModel<CourseVedioEditViewModel>();

            try
            {
                if (!ModelState.IsValid)
                {
                    result.Message = "In Valid Model State";
                }
                else
                {
                    courseVedioService.Remove(id);
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
