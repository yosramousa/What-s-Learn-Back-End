using ITI.WhatsLearn.Services;
using ITI.WhatsLearn.ViewModel;
using ITI.WhatsLearnServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ITI.WhatsLearn.Presentation.Controllers.UserPanel
{
    public class HomeController : ApiController
    {
        private readonly MainCategoryService mainCategoryService;
        private readonly SubCategoryService subCategoryService;
        private readonly TrackService trackService;
        private readonly CourseService courseService;
       
        public HomeController
            (
             MainCategoryService _mainCategoryService,
             SubCategoryService _subCategoryService,
             TrackService _trackService,
             CourseService _courseService
            
            )
        {
            mainCategoryService = _mainCategoryService;
            subCategoryService = _subCategoryService;
            trackService = _trackService;
            courseService = _courseService;
      
        }
        [HttpGet]

        public ResultViewModel<IEnumerable<HomeViewModel>> GetAllMainCategory(int PageSize ,int  PageIndex )
        {
            ResultViewModel<IEnumerable<HomeViewModel>> result
                = new ResultViewModel<IEnumerable<HomeViewModel>>();

            try
            {
                result.Data = mainCategoryService.GetAll(PageIndex, PageSize).Select(i => i.ToHomeViewmodel());
                result.Successed = true;
            }
            catch (Exception ex)
            {
                result.Successed = false;
                result.Message = "Something Went Wrong !!";
            }
            return result;
        }

        [HttpGet]
        public ResultViewModel<DataDetails> GetByID(int ID,int Level ,int PageSize, int PageIndex)
        {
            ResultViewModel<DataDetails> result
                = new ResultViewModel<DataDetails>();
            DataDetails details = new DataDetails();
            try
            {
                switch (Level)
                {
                    case 1:
                        details.LevelDetails = mainCategoryService.GetByID(ID);
                        details.Childs = subCategoryService.GetByParentID(ID, PageIndex , PageSize).Select(i => i.ToHomeViewmodel()).ToList();
                    break;
                    case 2:
                        details.LevelDetails = subCategoryService.GetByID(ID);
                        details.Childs = trackService.GetByParentID(ID, PageIndex, PageSize).Select(i => i.ToHomeViewmodel()).ToList();
                        break;
                    case 3:
                        details.LevelDetails = trackService.GetByID(ID);
                        details.Childs = courseService.GetByParentID(ID,  PageIndex, PageSize).Select(i => i.ToHomeViewmodel()).ToList();
                        break;
                }
                result.Data = details;
                result.Successed = true;
            }
            catch (Exception ex)
            {
                result.Successed = false;
                result.Message = "Something Went Wrong !!";
            }
            return result;
        }

      
      
    }
}
