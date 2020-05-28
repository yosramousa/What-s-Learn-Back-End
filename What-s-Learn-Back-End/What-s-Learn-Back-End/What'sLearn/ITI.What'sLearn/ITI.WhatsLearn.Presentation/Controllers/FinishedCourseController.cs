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
    public class FinishedCourseController : ApiController
    {
        private readonly FinishedCourseService finishedCourseService;
        public FinishedCourseController(FinishedCourseService _finishedCourseService)
        {
            finishedCourseService = _finishedCourseService;
        }

        [HttpGet]
        public ResultViewModel<IEnumerable<FinishedCourseViewModel>> GetList(int pageIndex, int pageSize = 20)
        {
            ResultViewModel<IEnumerable<FinishedCourseViewModel>> result
               = new ResultViewModel<IEnumerable<FinishedCourseViewModel>>();

            try
            {
                var finishedCourses = finishedCourseService.GetAll(pageIndex, pageSize);
                result.Successed = true;
                result.Data = finishedCourses;
            }
            catch (Exception ex)
            {
                result.Successed = false;
                result.Message = "Something Went Wrong !!";
            }
            return result;
        }
        [HttpPost]
        public ResultViewModel<FinishedCourseEditViewModel> Post(FinishedCourseEditViewModel FinishedCourse)
        {
            ResultViewModel<FinishedCourseEditViewModel> result
                = new ResultViewModel<FinishedCourseEditViewModel>();

            try
            {
                if (!ModelState.IsValid)
                {
                    result.Message = "In Valid Model State";
                }
                else
                {
                    FinishedCourseEditViewModel selectedFinishedCourse
                        = finishedCourseService.Add(FinishedCourse);

                    result.Successed = true;
                    result.Data = selectedFinishedCourse;
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
        public ResultViewModel<FinishedCourseViewModel> GetByID(int id)
        {
            ResultViewModel<FinishedCourseViewModel> result
                = new ResultViewModel<FinishedCourseViewModel>();
            try
            {
                var finishedCourse = finishedCourseService.GetByID(id);
                result.Successed = true;
                result.Data = finishedCourse;
            }
            catch (Exception ex)
            {
                result.Successed = false;
                result.Message = "Something Went Wrong !!";
            }
            return result;
        }
        [HttpPost]
        
        [HttpGet]
        public ResultViewModel<FinishedCourseEditViewModel> Update(FinishedCourseEditViewModel FinishedCourse)
        {
            ResultViewModel<FinishedCourseEditViewModel> result
              = new ResultViewModel<FinishedCourseEditViewModel>();

            try
            {
                if (!ModelState.IsValid)
                {
                    result.Message = "In Valid Model State";
                }
                else
                {
                    FinishedCourseEditViewModel selectedAdminFinishedCourse
                        = finishedCourseService.Update(FinishedCourse);
                    result.Successed = true;
                    result.Data = selectedAdminFinishedCourse;
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
        public ResultViewModel<FinishedCourseEditViewModel> Delete(int id)
        {
            ResultViewModel<FinishedCourseEditViewModel> result
             = new ResultViewModel<FinishedCourseEditViewModel>();

            try
            {
                if (!ModelState.IsValid)
                {
                    result.Message = "In Valid Model State";
                }
                else
                {
                    finishedCourseService.Remove(id);
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
