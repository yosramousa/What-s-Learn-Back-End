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
    public class CourseDocumentController : ApiController
    {
        private readonly CourseDocumentService courseDocumentService;
        public CourseDocumentController(CourseDocumentService _courseDocumentService)
        {
            courseDocumentService = _courseDocumentService;
        }

        [HttpGet]
        public ResultViewModel<IEnumerable<CourseDocumentViewModel>> GetList(int pageIndex, int pageSize = 20)
        {
            ResultViewModel<IEnumerable<CourseDocumentViewModel>> result
               = new ResultViewModel<IEnumerable<CourseDocumentViewModel>>();

            try
            {
                var admins = courseDocumentService.GetAll(pageIndex, pageSize);
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
        public ResultViewModel<CourseDocumentEditViewModel> Post(CourseDocumentEditViewModel courseDocument)
        {
            ResultViewModel<CourseDocumentEditViewModel> result
                = new ResultViewModel<CourseDocumentEditViewModel>();

            try
            {
                if (!ModelState.IsValid)
                {
                    result.Message = "In Valid Model State";
                }
                else
                {
                    CourseDocumentEditViewModel selectedAdmin
                        = courseDocumentService.Add(courseDocument);

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
        public ResultViewModel<CourseDocumentViewModel> GetByID(int id)
        {
            ResultViewModel<CourseDocumentViewModel> result
                = new ResultViewModel<CourseDocumentViewModel>();
            try
            {
                var admin = courseDocumentService.GetByID(id);
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
        public ResultViewModel<CourseDocumentEditViewModel> Update(CourseDocumentEditViewModel courseDocument)
        {
            ResultViewModel<CourseDocumentEditViewModel> result
              = new ResultViewModel<CourseDocumentEditViewModel>();

            try
            {
                if (!ModelState.IsValid)
                {
                    result.Message = "In Valid Model State";
                }
                else
                {
                    CourseDocumentEditViewModel selectedAdmin
                        = courseDocumentService.Update(courseDocument);
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
        public ResultViewModel<CourseDocumentEditViewModel> Delete(int id)
        {
            ResultViewModel<CourseDocumentEditViewModel> result
             = new ResultViewModel<CourseDocumentEditViewModel>();

            try
            {
                if (!ModelState.IsValid)
                {
                    result.Message = "In Valid Model State";
                }
                else
                {
                    courseDocumentService.Remove(id);
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
