using ITI.WhatsLearn.Presentation.Filters;
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

      [AUTHORIZE(Roles = "User,Admin")]


    public class MainCategoryDocumentController : ApiController
    {
        private readonly MainCategoryDocumentService mainCategoryDocumentService;
        public MainCategoryDocumentController(MainCategoryDocumentService _mainCategoryDocumentService)
        {
            mainCategoryDocumentService = _mainCategoryDocumentService;
        }

        [HttpGet]
        public ResultViewModel<IEnumerable<MainCategoryDocumentViewModel>> GetList(int pageIndex, int pageSize = 20)
        {
            ResultViewModel<IEnumerable<MainCategoryDocumentViewModel>> result
               = new ResultViewModel<IEnumerable<MainCategoryDocumentViewModel>>();

            try
            {
                var MainCategoryDocuments = mainCategoryDocumentService.GetAll(pageIndex, pageSize);
                result.Successed = true;
                result.Data = MainCategoryDocuments;
            }
            catch (Exception ex)
            {
                result.Successed = false;
                result.Message = "Something Went Wrong !!";
            }
            return result;
        }
        [HttpPost]
        public ResultViewModel<MainCategoryDocumentEditViewModel> Post(MainCategoryDocumentEditViewModel MainCategoryDocument)
        {
            ResultViewModel<MainCategoryDocumentEditViewModel> result
                = new ResultViewModel<MainCategoryDocumentEditViewModel>();

            try
            {
                if (!ModelState.IsValid)
                {
                    result.Message = "In Valid Model State";
                }
                else
                {
                    MainCategoryDocumentEditViewModel selectedMainCategoryDocument
                        = mainCategoryDocumentService.Add(MainCategoryDocument);

                    result.Successed = true;
                    result.Data = selectedMainCategoryDocument;
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
        public ResultViewModel<MainCategoryDocumentViewModel> GetByID(int id)
        {
            ResultViewModel<MainCategoryDocumentViewModel> result
                = new ResultViewModel<MainCategoryDocumentViewModel>();
            try
            {
                var mainCategoryDocument = mainCategoryDocumentService.GetByID(id);
                result.Successed = true;
                result.Data = mainCategoryDocument;
            }
            catch (Exception ex)
            {
                result.Successed = false;
                result.Message = "Something Went Wrong !!";
            }
            return result;
        }
        [HttpGet]
        public ResultViewModel<MainCategoryDocumentEditViewModel> Update(MainCategoryDocumentEditViewModel MainCategoryDocument)
        {
            ResultViewModel<MainCategoryDocumentEditViewModel> result
              = new ResultViewModel<MainCategoryDocumentEditViewModel>();

            try
            {
                if (!ModelState.IsValid)
                {
                    result.Message = "In Valid Model State";
                }
                else
                {
                    MainCategoryDocumentEditViewModel selectedMainCategoryDocument
                        = mainCategoryDocumentService.Update(MainCategoryDocument);
                    result.Successed = true;
                    result.Data = selectedMainCategoryDocument;
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
        public ResultViewModel<MainCategoryDocumentEditViewModel> Delete(int id)
        {
            ResultViewModel<MainCategoryDocumentEditViewModel> result
             = new ResultViewModel<MainCategoryDocumentEditViewModel>();

            try
            {
                if (!ModelState.IsValid)
                {
                    result.Message = "In Valid Model State";
                }
                else
                {
                    mainCategoryDocumentService.Remove(id);
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
