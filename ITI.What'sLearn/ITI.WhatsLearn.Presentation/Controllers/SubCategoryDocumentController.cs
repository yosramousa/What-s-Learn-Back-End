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

    public class SubCategoryDocumentController : ApiController
    {
        private readonly SubCategoryDocumentService subCategoryDocumentService;
        public SubCategoryDocumentController(SubCategoryDocumentService _subCategoryDocumentService)
        {
            subCategoryDocumentService = _subCategoryDocumentService;
        }

        [HttpGet]
        public ResultViewModel<IEnumerable<SubCategoryDocumentViewModel>> GetList()
        {
            ResultViewModel<IEnumerable<SubCategoryDocumentViewModel>> result
                = new ResultViewModel<IEnumerable<SubCategoryDocumentViewModel>>();
            try
            {
                var subCatgoryDoc = subCategoryDocumentService.GetAll();
                result.Successed = true;
                result.Data = subCatgoryDoc ;
            }
            catch (Exception ex)
            {
                result.Successed = false;
                result.Message = "Something Went Wrong !!";
            }
            return result;
        }


        [HttpPost]
        public ResultViewModel<SubCategoryDocumentEditViewModel> Post(SubCategoryDocumentEditViewModel UserSkill)
        {
            ResultViewModel<SubCategoryDocumentEditViewModel> result
                = new ResultViewModel<SubCategoryDocumentEditViewModel>();

            try
            {
                if (!ModelState.IsValid)
                {
                    result.Message = "In Valid Model State";
                }
                else
                {
                    SubCategoryDocumentEditViewModel selectedUserSkill
                        = subCategoryDocumentService.Add(UserSkill);

                    result.Successed = true;
                    result.Data = selectedUserSkill;
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
        public ResultViewModel<SubCategoryDocumentEditViewModel> Update(SubCategoryDocumentEditViewModel UserSkill)
        {
            ResultViewModel<SubCategoryDocumentEditViewModel> result
                = new ResultViewModel<SubCategoryDocumentEditViewModel>();

            try
            {
                if (!ModelState.IsValid)
                {
                    result.Message = "In Valid Model State";
                }
                else
                {
                    SubCategoryDocumentEditViewModel selectedEmp
                        = subCategoryDocumentService.Update(UserSkill);

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
        public ResultViewModel<SubCategoryDocumentViewModel> GetByID(int id)
        {
            ResultViewModel<SubCategoryDocumentViewModel> result
                = new ResultViewModel<SubCategoryDocumentViewModel>();
            try
            {
                var subCategoryDoc = subCategoryDocumentService.GetByID(id)?.ToViewModel();
                result.Successed = true;
                result.Data = subCategoryDoc;
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
            if (subCategoryDocumentService.GetByID(id) != null)
            {
                subCategoryDocumentService.Remove(id);
                return "UserSkill Deleted Sucessfully";
            }
            else
                return "UserSkill Not Found !";
        }

    }
}
