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
    public class CourseController : ApiController
    {
        private readonly CourseService courseService;
        public CourseController(CourseService _courseService)
        {
            courseService = _courseService;
        }

        [HttpGet]
        public ResultViewModel<IEnumerable<CourseViewModel>> GetList(int pageIndex, int pageSize = 20)
        {
            ResultViewModel<IEnumerable<CourseViewModel>> result
               = new ResultViewModel<IEnumerable<CourseViewModel>>();

            try
            {
                var Courses = courseService.GetAll(pageIndex, pageSize);
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
        public ResultViewModel<CourseEditViewModel> Remove(int id)
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
