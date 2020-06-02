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
    public class MainCategoryController : ApiController
    {
        private readonly MainCategoryService mainCategoryService;
        public MainCategoryController(MainCategoryService _mainCategoryService)
        {
            mainCategoryService = _mainCategoryService;
        }

        [HttpGet]
        public ResultViewModel<IEnumerable<MainCategoryViewModel>> GetList(int pageIndex, int pageSize = 20)
        {
            ResultViewModel<IEnumerable<MainCategoryViewModel>> result
               = new ResultViewModel<IEnumerable<MainCategoryViewModel>>();

            try
            {
                var MainCategories = mainCategoryService.GetAll(pageIndex, pageSize);
                result.Successed = true;
                result.Data = MainCategories;
            }
            catch (Exception ex)
            {
                result.Successed = false;
                result.Message = "Something Went Wrong !!";
            }
            return result;
        }
        [HttpPost]
        public ResultViewModel<MainCategoryEditViewModel> Post(MainCategoryEditViewModel MainCategory)
        {
            ResultViewModel<MainCategoryEditViewModel> result
                = new ResultViewModel<MainCategoryEditViewModel>();

            try
            {
                if (!ModelState.IsValid)
                {
                    result.Message = "In Valid Model State";
                }
                else
                {
                    MainCategoryEditViewModel selectedMainCategory
                        = mainCategoryService.Add(MainCategory);

                    result.Successed = true;
                    result.Data = selectedMainCategory;
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
        public ResultViewModel<MainCategoryViewModel> GetByID(int id)
        {
            ResultViewModel<MainCategoryViewModel> result
                = new ResultViewModel<MainCategoryViewModel>();
            try
            {
                var mainCategory = mainCategoryService.GetByID(id);
                result.Successed = true;
                result.Data = mainCategory;
            }
            catch (Exception ex)
            {
                result.Successed = false;
                result.Message = "Something Went Wrong !!";
            }
            return result;
        }
        [HttpPost]
        public ResultViewModel<MainCategoryEditViewModel> Update(MainCategoryEditViewModel MainCategory)
        {
            ResultViewModel<MainCategoryEditViewModel> result
              = new ResultViewModel<MainCategoryEditViewModel>();

            try
            {
                if (!ModelState.IsValid)
                {
                    result.Message = "In Valid Model State";
                }
                else
                {
                    MainCategoryEditViewModel selectedMainCategory
                        = mainCategoryService.Update(MainCategory);
                    result.Successed = true;
                    result.Data = selectedMainCategory;
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
        public ResultViewModel<MainCategoryEditViewModel> Delete(int id)
        {
            ResultViewModel<MainCategoryEditViewModel> result
             = new ResultViewModel<MainCategoryEditViewModel>();

            try
            {
                if (!ModelState.IsValid)
                {
                    result.Message = "In Valid Model State";
                }
                else
                {
                    mainCategoryService.Remove(id);
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
