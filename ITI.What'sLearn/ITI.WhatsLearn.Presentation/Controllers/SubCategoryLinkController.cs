using ITI.WhatsLearn.Entities;
using ITI.WhatsLearn.Presentation.Filters;
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
    [AUTHORIZE(Roles = "User,Admin")]

    public class SubCategoryLinkController : ApiController
    {
        private readonly SubCategoryLinkService SubCategoryLinkService;
        public SubCategoryLinkController(SubCategoryLinkService _SubCategoryLinkService)
        {
            SubCategoryLinkService = _SubCategoryLinkService;
        }

        [HttpGet]
        public ResultViewModel<IEnumerable<SubCategoryLinkViewModel>> GetList()
        {
            ResultViewModel<IEnumerable<SubCategoryLinkViewModel>> result
                = new ResultViewModel<IEnumerable<SubCategoryLinkViewModel>>();
            try
            {
                var SubCategoryLinks = SubCategoryLinkService.GetAll();
                result.Successed = true;
                result.Data = SubCategoryLinks;
            }
            catch (Exception ex)
            {
                result.Successed = false;
                result.Message = "Something Went Wrong !!";
            }
            return result;
        }


        [HttpPost]
        public ResultViewModel<SubCategoryLinkEditViewModel> Post(SubCategoryLinkEditViewModel SubCategoryLink)
        {
            ResultViewModel<SubCategoryLinkEditViewModel> result
                = new ResultViewModel<SubCategoryLinkEditViewModel>();

            try
            {
                if (!ModelState.IsValid)
                {
                    result.Message = "In Valid Model State";
                }
                else
                {
                    SubCategoryLinkEditViewModel selectedSubCategoryLink
                        = SubCategoryLinkService.Add(SubCategoryLink);

                    result.Successed = true;
                    result.Data = selectedSubCategoryLink;
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
        public ResultViewModel<SubCategoryLinkEditViewModel> Update(SubCategoryLinkEditViewModel SubCategoryLink)
        {
            ResultViewModel<SubCategoryLinkEditViewModel> result
                = new ResultViewModel<SubCategoryLinkEditViewModel>();

            try
            {
                if (!ModelState.IsValid)
                {
                    result.Message = "In Valid Model State";
                }
                else
                {
                    SubCategoryLinkEditViewModel selectedEmp
                        = SubCategoryLinkService.Update(SubCategoryLink);

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
        public ResultViewModel<SubCategoryLinkViewModel> GetByID(int id)
        {
            ResultViewModel<SubCategoryLinkViewModel> result
                = new ResultViewModel<SubCategoryLinkViewModel>();
            try
            {
                var SubCategoryLink = SubCategoryLinkService.GetByID(id)?.ToViewModel();
                result.Successed = true;
                result.Data = SubCategoryLink;
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
            if (SubCategoryLinkService.GetByID(id) != null)
            {
                SubCategoryLinkService.Remove(id);
                return "SubCategoryLink Deleted Sucessfully";
            }
            else
                return "SubCategoryLink Not Found !";
        }

    }
}
