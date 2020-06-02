using ITI.WhatsLearn.Services;
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
    public class ManageCategoryController : ApiController
    {
        private readonly MainCategoryService mainCategoryService;
        private readonly SubCategoryService subCategoryService;
        private readonly TrackService trackService;
        private readonly CourseService courseService;
        public ManageCategoryController
            (
             MainCategoryService _mainCategoryService,
             SubCategoryService _subCategoryService,
             TrackService _trackService,
             Services.CourseService _courseService
            )
        {
            mainCategoryService = _mainCategoryService;
            subCategoryService = _subCategoryService;
            trackService = _trackService;
            courseService = _courseService;
        }

        [HttpGet]
        public ResultViewModel<IEnumerable<ManageCategoryViewModel>> GetList(int PageIndex, int PageSize, string SearchIn)
        {

            ResultViewModel<IEnumerable<ManageCategoryViewModel>> result
              = new ResultViewModel<IEnumerable<ManageCategoryViewModel>>();

            try
            {
                if (SearchIn == "MainCategory")
                {
                    var searshResult = mainCategoryService.GetAll(PageIndex, PageSize).
                       Select(i => i.ToManageCategoryViewModel()).OrderBy(i => i.ID);
                    result.Data = searshResult;
                }
                else if (SearchIn == "SubCategory")
                {
                    var searshResult = subCategoryService.GetAll(PageIndex, PageSize).
                       Select(i => i.ToManageCategoryViewModel());
                    result.Data = searshResult;
                }
                else if (SearchIn == "Track")
                {
                    var searshResult = trackService.GetAll(PageIndex, PageSize).
                       Select(i => i.ToManageCategoryViewModel());
                    result.Data = searshResult;

                }
                else if (SearchIn == "Course")
                {
                    var searshResult = courseService.GetAll(PageIndex, PageSize).
                        Select(i => i.ToManageCategoryViewModel());
                    result.Data = searshResult;
                    result.Count = courseService.Count();
                }


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
        public ResultViewModel<IEnumerable<ManageCategoryViewModel>> Search(int SearchBy, int SearchIn, string SearchText, int PageIndex, int PageSize)
        {
            ResultViewModel<IEnumerable<ManageCategoryViewModel>> result
            = new ResultViewModel<IEnumerable<ManageCategoryViewModel>>();
            int count = 0;

            try
            {

                if (SearchIn == 1)//mainCategory
                {
                    if (SearchBy == 0)
                    {
                        var searshResult = mainCategoryService.GetAll(PageIndex, PageSize).Select(i => i.ToManageCategoryViewModel());
                        result.Data = searshResult;

                    }
                    else if (SearchBy == 1)//SearchByParent
                    {

                        var searshResult = mainCategoryService.GetAll(PageIndex, PageSize).
                             Select(i => i.ToManageCategoryViewModel());

                        result.Data = searshResult;
                    }
                    else if (SearchBy == 2) //searchbychild
                    {

                        var searshResult = mainCategoryService.SearchByChilds(SearchText, PageIndex, PageSize).
                              Select(i => i.ToManageCategoryViewModel());

                        result.Data = searshResult;
                    }
                    else if (SearchBy == 3)//SearchByName
                    {

                        var searshResult = mainCategoryService.SearchByName(SearchText, PageIndex, PageSize)
                            .Select(i => i.ToManageCategoryViewModel());

                        result.Data = searshResult;
                    }
                    else if (SearchBy == 4) //SearchByID
                    {
                        int ID;
                        bool VaildID = int.TryParse(SearchText, out ID);
                        if (VaildID)
                        {
                            var searshResult = mainCategoryService.GetAll(PageIndex, PageSize).Where(i => i.ID == ID)
                                .Select(i => i.ToManageCategoryViewModel());
                            result.Data = searshResult;
                        }
                    }
                }
                else if (SearchIn == 2)//SubCategory
                {
                    if (SearchBy == 0)
                    {
                        var searshResult = subCategoryService.GetAll(PageIndex, PageSize)
                              .Select(i => i.ToManageCategoryViewModel());

                        result.Data = searshResult;

                    }
                    else if (SearchBy == 1)
                    {

                        var searshResult = subCategoryService.SearchByName(SearchText, PageIndex, PageSize)
                            .Select(i => i.ToManageCategoryViewModel());

                        result.Data = searshResult;
                    }
                    else if (SearchBy == 2)
                    {
                        var searshResult = subCategoryService.SearchByChilds(SearchText, PageIndex, PageSize)
                            .Select(i => i.ToManageCategoryViewModel());

                        result.Data = searshResult;
                    }
                    else if (SearchBy == 3)
                    {

                        var searshResult = subCategoryService.SearchByName(SearchText, PageIndex, PageSize).
                            Select(i => i.ToManageCategoryViewModel());

                        result.Data = searshResult;
                    }
                    else if (SearchBy == 4)
                    {
                        int ID;
                        bool VaildID = int.TryParse(SearchText, out ID);
                        if (VaildID)
                        {

                            var searshResult = subCategoryService.SeachByID(ID).
                            Select(i => i.ToManageCategoryViewModel());


                            result.Data = searshResult;
                        }
                    }
                }
                else if (SearchIn == 3)//Track
                {
                    if (SearchBy == 0)
                    {

                        var searshResult = trackService.GetAll(PageIndex, PageSize).
                            Select(i => i.ToManageCategoryViewModel());

                        result.Data = searshResult;
                    }
                    else if (SearchBy == 1)
                    {

                        var searshResult = trackService.SearchByParentName(SearchText, PageIndex, PageSize).
                             Select(i => i.ToManageCategoryViewModel());

                        result.Data = searshResult;
                    }
                    else if (SearchBy == 2)
                    {

                        var searshResult = trackService.SearchByChilds(SearchText, PageIndex, PageSize).
                             Select(i => i.ToManageCategoryViewModel());

                        result.Data = searshResult;
                    }
                    else if (SearchBy == 3)
                    {

                        var searshResult = trackService.SearchByName(SearchText, PageIndex, PageSize).
                             Select(i => i.ToManageCategoryViewModel());

                        result.Data = searshResult;
                    }
                    else if (SearchBy == 4)
                    {
                        int ID;
                        bool VaildID = int.TryParse(SearchText, out ID);
                        if (VaildID)
                        {
                            var searshResult = trackService.SeachByID(ID).
                             Select(i => i.ToManageCategoryViewModel());

                            result.Data = searshResult;
                        }
                    }
                }
                else if (SearchIn == 4)//Course
                {
                    if (SearchBy == 0)
                    {

                        var searshResult = courseService.GetAll(PageIndex, PageSize).
                            Select(i => i.ToManageCategoryViewModel());

                        result.Data = searshResult;
                    }
                    else if (SearchBy == 1)
                    {

                        var searshResult = courseService.SearchByParentName(SearchText, PageIndex, PageSize).
                           Select(i => i.ToManageCategoryViewModel());
                        result.Data = searshResult;



                    }
                    else if (SearchBy == 2)
                    {

                        result.Data = new List<ManageCategoryViewModel>();
                    }
                    else if (SearchBy == 3)
                    {


                        var searshResult = courseService.SearchByName(SearchText, PageIndex, PageSize).
                             Select(i => i.ToManageCategoryViewModel());

                        result.Data = searshResult;
                    }
                    else if (SearchBy == 4)
                    {
                        int ID;
                        bool VaildID = int.TryParse(SearchText, out ID);
                        if (VaildID)
                        {
                            var searshResult = courseService.SeachByID(ID).
                             Select(i => i.ToManageCategoryViewModel());

                            result.Data = searshResult;
                        }
                    }
                }

                else
                {
                    
                    List<ManageCategoryViewModel> res = new List<ManageCategoryViewModel>();
                    var searshResult = new ManageCategoryViewModel()
                    {
                        ID = 1,
                        Name = "Main Category Parent",
                        Childs = mainCategoryService.GetAll(PageIndex, PageSize).Select(i => i.Name).ToList(),
                        Parent = ""
                    };
                    res.Add(searshResult);

                    result.Data = res;

                }
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
        public String Delete(int level, int ID)
        {

            try
            {
                if (level == 1)
                {
                    if (mainCategoryService.GetByID(ID) != null)
                    {
                        mainCategoryService.Remove(ID);
                        return "mainCategory Deleted Sucessfully";
                    }
                    else
                        return "mainCategory Not Found !";

                }
                else if (level == 2)
                {
                    if (subCategoryService.GetByID(ID) != null)
                    {
                        subCategoryService.Remove(ID);
                        return "subCategory Deleted Sucessfully";
                    }
                    else
                        return "subCategory Not Found !";

                }
                else if (level == 3)
                {

                    if (trackService.GetByID(ID) != null)
                    {
                        trackService.Remove(ID);
                        return "track Deleted Sucessfully";
                    }
                    else
                        return "track Not Found !";
                }
                else if (level == 4)
                {
                    if (courseService.GetByID(ID) != null)
                    {
                        courseService.Remove(ID);
                        return "course Deleted Sucessfully";
                    }
                    else
                        return "course Not Found !";
                }



            }
            catch (Exception ex)
            {

                return "Something Went Wrong !!";
            }

            return "";

        }

        //public ResultViewModel<LevelViewModel> GetByID(int level, int ID)
        //{

        //    ResultViewModel<LevelViewModel> result
        //        = new ResultViewModel<LevelViewModel>();
        //    try
        //    {
        //        if (level == 1)
        //        {

        //            var mainCategory = mainCategoryService.GetByID(ID);
        //            result.Successed = true;
        //            result.Data = new LevelViewModel()
        //            {
        //                ID = mainCategory.ID,
        //                Discription = mainCategory.Discription,
        //                Documents = mainCategory.Documents  ,
        //                Links = mainCategory.Links,
        //                Vedios = mainCategory.Vedios

        //            };


        //        }
        //        else if (level == 2)
        //        {
        //            //var mainCategory = subCategoryService.GetByID(ID);
        //            //result.Successed = true;
        //            //result.Data = new LevelViewModel()
        //            //{
        //            //    ID = mainCategory.ID,
        //            //    Discription = mainCategory.Discription,
        //            //    Documents = ,
        //            //    Links = mainCategory.Links,
        //            //    Vedios = mainCategory.Vedios

        //            //};
        //        }
        //        else if (level == 3)
        //        {


        //        }
        //        else if (level == 4)
        //        {

        //        }

        //        return result;

        //    }
        //    catch (Exception ex)
        //    {


        //    }



    }

}

