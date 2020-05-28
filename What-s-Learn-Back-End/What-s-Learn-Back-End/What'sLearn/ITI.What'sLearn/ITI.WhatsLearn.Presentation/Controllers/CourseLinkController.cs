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
    public class CourseLinkController : ApiController
    {
        private readonly CourseLinkService courseLinkService;
        public CourseLinkController(CourseLinkService _courseLinkService)
        {
            courseLinkService = _courseLinkService;
        }

        [HttpGet]
        public ResultViewModel<IEnumerable<CourseLinkViewModel>> GetList(int pageIndex, int pageSize = 20)
        {
            ResultViewModel<IEnumerable<CourseLinkViewModel>> result
               = new ResultViewModel<IEnumerable<CourseLinkViewModel>>();

            try
            {
                var admins = courseLinkService.GetAll(pageIndex, pageSize);
                result.Successed = true;
                result.Data = admins;
            }
            catch (Exception ex)
            {
                result.Successed = false;
                result.Message = "Something Went Wrong !!";
            }
            return result;
        }
        [HttpPost]
        public ResultViewModel<CourseLinkEditViewModel> Post(CourseLinkEditViewModel courseLink)
        {
            ResultViewModel<CourseLinkEditViewModel> result
                = new ResultViewModel<CourseLinkEditViewModel>();

            try
            {
                if (!ModelState.IsValid)
                {
                    result.Message = "In Valid Model State";
                }
                else
                {
                    CourseLinkEditViewModel selectedCourse
                        = courseLinkService.Add(courseLink);

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
        public ResultViewModel<CourseLinkViewModel> GetByID(int id)
        {
            ResultViewModel<CourseLinkViewModel> result
                = new ResultViewModel<CourseLinkViewModel>();
            try
            {
                var admin = courseLinkService.GetByID(id);
                result.Successed = true;
                result.Data = admin;
            }
            catch (Exception ex)
            {
                result.Successed = false;
                result.Message = "Something Went Wrong !!";
            }
            return result;
        }
        [HttpGet]
        public ResultViewModel<CourseLinkEditViewModel> Update(CourseLinkEditViewModel courseDocument)
        {
            ResultViewModel<CourseLinkEditViewModel> result
              = new ResultViewModel<CourseLinkEditViewModel>();

            try
            {
                if (!ModelState.IsValid)
                {
                    result.Message = "In Valid Model State";
                }
                else
                {
                    CourseLinkEditViewModel selectedAdmin
                        = courseLinkService.Update(courseDocument);
                    result.Successed = true;
                    result.Data = selectedAdmin;
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
        public ResultViewModel<CourseLinkEditViewModel> Remove(int id)
        {
            ResultViewModel<CourseLinkEditViewModel> result
             = new ResultViewModel<CourseLinkEditViewModel>();

            try
            {
                if (!ModelState.IsValid)
                {
                    result.Message = "In Valid Model State";
                }
                else
                {
                    courseLinkService.Remove(id);
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
