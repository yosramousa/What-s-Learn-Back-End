using ITI.WhatsLearn.Entities;
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
    public class SubCategoryController : ApiController
    {
        private readonly SubCategoryService subCategoryService;
        public SubCategoryController(SubCategoryService _subCategoryService)
        {
            subCategoryService = _subCategoryService;
        }

        [HttpGet]
        public ResultViewModel<IEnumerable<SubCategoryViewModel>> GetList(int pageIndex, int pageSize = 20)
        {
            ResultViewModel<IEnumerable<SubCategoryViewModel>> result
               = new ResultViewModel<IEnumerable<SubCategoryViewModel>>();

            try
            {
                var SubCategories = subCategoryService.GetAll(pageIndex, pageSize);
                result.Successed = true;
                result.Data = SubCategories;
            }
            catch (Exception ex)
            {
                result.Successed = false;
                result.Message = "Something Went Wrong !!";
            }
            return result;
        }
        [HttpPost]
        public ResultViewModel<SubCategory> Post(SubCategoryEditViewModel SubCategory)
        {
            ResultViewModel<SubCategory> result
                = new ResultViewModel<SubCategory>();

            try
            {
                if (!ModelState.IsValid)
                {
                    result.Message = "In Valid Model State";
                }
                else
                {
                    SubCategory selectedSubCategory
                        = subCategoryService.Add(SubCategory);

                    result.Successed = true;
                    result.Data = selectedSubCategory;
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
        public ResultViewModel<SubCategoryViewModel> GetByID(int id)
        {
            ResultViewModel<SubCategoryViewModel> result
                = new ResultViewModel<SubCategoryViewModel>();
            try
            {
                var subCategory = subCategoryService.GetByID(id);
                result.Successed = true;
                result.Data = subCategory;
            }
            catch (Exception ex)
            {
                result.Successed = false;
                result.Message = "Something Went Wrong !!";
            }
            return result;
        }
        [HttpPost]
        public ResultViewModel<SubCategoryEditViewModel> Update(SubCategoryEditViewModel SubCategory)
        {
            ResultViewModel<SubCategoryEditViewModel> result
              = new ResultViewModel<SubCategoryEditViewModel>();

            try
            {
                if (!ModelState.IsValid)
                {
                    result.Message = "In Valid Model State";
                }
                else
                {
                    SubCategoryEditViewModel selectedSubCategory
                        = subCategoryService.Update(SubCategory);
                    result.Successed = true;
                    result.Data = selectedSubCategory;
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
        public ResultViewModel<SubCategoryEditViewModel> Delete(int id)
        {
            ResultViewModel<SubCategoryEditViewModel > result
             = new ResultViewModel<SubCategoryEditViewModel>();

            try
            {
                if (!ModelState.IsValid)
                {
                    result.Message = "In Valid Model State";
                }
                else
                {
                    subCategoryService.Remove(id);
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
