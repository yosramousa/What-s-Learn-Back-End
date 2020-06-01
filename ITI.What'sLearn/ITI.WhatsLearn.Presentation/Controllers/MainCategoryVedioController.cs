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
    public class MainCategoryVedioController : ApiController
    {
        private readonly MainCategoryVedioService mainCategoryVedioService;
        public MainCategoryVedioController(MainCategoryVedioService _mainCategoryVedioService)
        {
            mainCategoryVedioService = _mainCategoryVedioService;
        }

        [HttpGet]
        public ResultViewModel<IEnumerable<MainCategoryVedioViewModel>> GetList(int pageIndex, int pageSize = 20)
        {
            ResultViewModel<IEnumerable<MainCategoryVedioViewModel>> result
               = new ResultViewModel<IEnumerable<MainCategoryVedioViewModel>>();

            try
            {
                var MainCategoryVedio = mainCategoryVedioService.GetAll(pageIndex, pageSize);
                result.Successed = true;
                result.Data = MainCategoryVedio;
            }
            catch (Exception ex)
            {
                result.Successed = false;
                result.Message = "Something Went Wrong !!";
            }
            return result;
        }
        [HttpPost]
        public ResultViewModel<MainCategoryVedioEditViewModel> Post(MainCategoryVedioEditViewModel MainCategoryVedio)
        {
            ResultViewModel<MainCategoryVedioEditViewModel> result
                = new ResultViewModel<MainCategoryVedioEditViewModel>();

            try
            {
                if (!ModelState.IsValid)
                {
                    result.Message = "In Valid Model State";
                }
                else
                {
                    MainCategoryVedioEditViewModel selectedMainCategoryVedio
                        = mainCategoryVedioService.Add(MainCategoryVedio);

                    result.Successed = true;
                    result.Data = selectedMainCategoryVedio;
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
        public ResultViewModel<MainCategoryVedioViewModel> GetByID(int id)
        {
            ResultViewModel<MainCategoryVedioViewModel> result
                = new ResultViewModel<MainCategoryVedioViewModel>();
            try
            {
                var mainCategory = mainCategoryVedioService.GetByID(id);
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
        [HttpGet]
        public ResultViewModel<MainCategoryVedioEditViewModel> Update(MainCategoryVedioEditViewModel MainCategoryVedio)
        {
            ResultViewModel<MainCategoryVedioEditViewModel> result
              = new ResultViewModel<MainCategoryVedioEditViewModel>();

            try
            {
                if (!ModelState.IsValid)
                {
                    result.Message = "In Valid Model State";
                }
                else
                {
                    MainCategoryVedioEditViewModel selectedMainCategoryVedio
                        = mainCategoryVedioService.Update(MainCategoryVedio);
                    result.Successed = true;
                    result.Data = selectedMainCategoryVedio;
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
        public ResultViewModel<MainCategoryVedioEditViewModel> Delete(int id)
        {
            ResultViewModel<MainCategoryVedioEditViewModel> result
             = new ResultViewModel<MainCategoryVedioEditViewModel>();

            try
            {
                if (!ModelState.IsValid)
                {
                    result.Message = "In Valid Model State";
                }
                else
                {
                    mainCategoryVedioService.Remove(id);
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
