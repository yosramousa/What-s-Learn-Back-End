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

    public class MainCategoryLinkController : ApiController
    {
        private readonly MainCategoryLinkService mainCategoryLinkService;
        public MainCategoryLinkController(MainCategoryLinkService _mainCategoryLinkService)
        {
            mainCategoryLinkService = _mainCategoryLinkService;
        }

        [HttpGet]
        public ResultViewModel<IEnumerable<MainCategoryLinkViewModel>> GetList(int pageIndex, int pageSize = 20)
        {
            ResultViewModel<IEnumerable<MainCategoryLinkViewModel>> result
               = new ResultViewModel<IEnumerable<MainCategoryLinkViewModel>>();

            try
            {
                var MainCategoryLink = mainCategoryLinkService.GetAll(pageIndex, pageSize);
                result.Successed = true;
                result.Data = MainCategoryLink;
            }
            catch (Exception ex)
            {
                result.Successed = false;
                result.Message = "Something Went Wrong !!";
            }
            return result;
        }
        [HttpPost]
        public ResultViewModel<MainCategoryLinkEditViewModel> Post(MainCategoryLinkEditViewModel MainCategoryLink)
        {
            ResultViewModel<MainCategoryLinkEditViewModel> result
                = new ResultViewModel<MainCategoryLinkEditViewModel>();

            try
            {
                if (!ModelState.IsValid)
                {
                    result.Message = "In Valid Model State";
                }
                else
                {
                    MainCategoryLinkEditViewModel selectedMainCategoryLink
                        = mainCategoryLinkService.Add(MainCategoryLink);

                    result.Successed = true;
                    result.Data = selectedMainCategoryLink;
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
        public ResultViewModel<MainCategoryLinkViewModel> GetByID(int id)
        {
            ResultViewModel<MainCategoryLinkViewModel> result
                = new ResultViewModel<MainCategoryLinkViewModel>();
            try
            {
                var mainCategoryLink = mainCategoryLinkService.GetByID(id);
                result.Successed = true;
                result.Data = mainCategoryLink;
            }
            catch (Exception ex)
            {
                result.Successed = false;
                result.Message = "Something Went Wrong !!";
            }
            return result;
        }
        [HttpGet]
        public ResultViewModel<MainCategoryLinkEditViewModel> Update(MainCategoryLinkEditViewModel MainCategoryLink)
        {
            ResultViewModel<MainCategoryLinkEditViewModel> result
              = new ResultViewModel<MainCategoryLinkEditViewModel>();

            try
            {
                if (!ModelState.IsValid)
                {
                    result.Message = "In Valid Model State";
                }
                else
                {
                    MainCategoryLinkEditViewModel selectedMainCategoryLink
                        = mainCategoryLinkService.Update(MainCategoryLink);
                    result.Successed = true;
                    result.Data = selectedMainCategoryLink;
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
        public ResultViewModel<MainCategoryLinkEditViewModel> Delete(int id)
        {
            ResultViewModel<MainCategoryLinkEditViewModel> result
             = new ResultViewModel<MainCategoryLinkEditViewModel>();

            try
            {
                if (!ModelState.IsValid)
                {
                    result.Message = "In Valid Model State";
                }
                else
                {
                    mainCategoryLinkService.Remove(id);
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
