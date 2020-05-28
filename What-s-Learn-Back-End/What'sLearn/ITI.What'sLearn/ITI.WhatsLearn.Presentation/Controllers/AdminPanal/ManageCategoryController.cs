﻿using ITI.WhatsLearn.Services;
using ITI.WhatsLearn.ViewModel;
//using ITI.WhatsLearn.ViewModel;
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
        private readonly Services.CourseService courseService;
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
        public ResultViewModel<IEnumerable<ManageCategoryViewModel>> GetList(int PageIndex, int PageSize,string SearchIn)
        {

            ResultViewModel<IEnumerable<ManageCategoryViewModel>> result
              = new ResultViewModel<IEnumerable<ManageCategoryViewModel>>();

            try
            {
                if (SearchIn == "MainCategory")
                {
                    var searshResult = mainCategoryService.GetAll(PageIndex, PageSize).
                        Select(i => new ManageCategoryViewModel()
                        {
                            ID = i.ID,
                            Name =i.Name,
                            Child = i.Child,
                            Parent=i.Parent
                        }).OrderByDescending(i=>i.ID);
                    result.Data = searshResult;
                }
                else if (SearchIn == "SubCategory")
                {
                    var searshResult = subCategoryService.GetAll(PageIndex, PageSize).
                        Select(i => new ManageCategoryViewModel()
                        {
                            ID = i.ID,
                            Name = i.Name,
                            Child = i.Child,
                            Parent = i.Parent
                        });
                    result.Data = searshResult;
                }
                else if (SearchIn == "Track")
                {
                    var searshResult = trackService.GetAll(PageIndex, PageSize).
                        Select(i => new ManageCategoryViewModel()
                        {
                            ID = i.ID,
                            Name = i.Name,
                            Child = i.Child,
                            Parent = i.Parent
                        });
                    result.Data = searshResult;
                }
                else if (SearchIn == "Course")
                {
                    var searshResult = courseService.GetAll(PageIndex, PageSize).
                        Select(i => new ManageCategoryViewModel()
                        {
                            ID = i.ID,
                            Name = i.Name,
                            Child = i.Child,
                            Parent = i.Parent
                        });
                    result.Data = searshResult;
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
        public ResultViewModel<IEnumerable<ManageCategoryViewModel>> SearchBy(int PageIndex, int PageSize,string SearchBy, string SearchIn , string SearchText)
        {
            ResultViewModel<IEnumerable<ManageCategoryViewModel>> result
            = new ResultViewModel<IEnumerable<ManageCategoryViewModel>>();

            try
            {
                if (SearchIn == "MainCategory")
                {
                    if (SearchBy == "Parent")
                    {
                        
                        var searshResult = mainCategoryService.GetAll(PageIndex, PageSize).
                             Select(i => new ManageCategoryViewModel()
                             {
                                 ID = i.ID,
                                 Name = i.Name,
                                 Child = i.Child,
                                 Parent = i.Parent
                             }).Where(i=>i.Parent==SearchText);

                        result.Data = searshResult;
                    }
                    else if (SearchBy == "Child")
                    {

                        var searshResult = mainCategoryService.GetAll(PageIndex, PageSize).
                             Select(i => new ManageCategoryViewModel()
                             {
                                 ID = i.ID,
                                 Name = i.Name,
                                 Child = i.Child,
                                 Parent = i.Parent
                             }).Where(i => i.Child.Contains(SearchText));

                        result.Data = searshResult;
                    }
                    else if (SearchBy == "Name")
                    {

                        var searshResult = mainCategoryService.GetAll(PageIndex, PageSize).
                             Select(i => new ManageCategoryViewModel()
                             {
                                 ID = i.ID,
                                 Name = i.Name,
                                 Child = i.Child,
                                 Parent = i.Parent
                             }).Where(i => i.Name == SearchText);

                        result.Data = searshResult;
                    }
                    else if (SearchBy == "ID")
                    {

                        var searshResult = mainCategoryService.GetAll(PageIndex, PageSize).
                             Select(i => new ManageCategoryViewModel()
                             {
                                 ID = i.ID,
                                 Name = i.Name,
                                 Child = i.Child,
                                 Parent = i.Parent
                             }).Where(i => i.ID ==int.Parse(SearchText));

                        result.Data = searshResult;
                    }
                }
                else if (SearchIn == "SubCategory")
                {
                    if (SearchBy == "Parent")
                    {

                        var searshResult = subCategoryService.GetAll(PageIndex, PageSize).
                             Select(i => new ManageCategoryViewModel()
                             {
                                 ID = i.ID,
                                 Name = i.Name,
                                 Child = i.Child,
                                 Parent = i.Parent
                             }).Where(i => i.Parent == SearchText);

                        result.Data = searshResult;
                    }
                    else if (SearchBy == "Child")
                    {

                        var searshResult = subCategoryService.GetAll(PageIndex, PageSize).
                             Select(i => new ManageCategoryViewModel()
                             {
                                 ID = i.ID,
                                 Name = i.Name,
                                 Child = i.Child,
                                 Parent = i.Parent
                             }).Where(i => i.Child.Contains(SearchText));

                        result.Data = searshResult;
                    }
                    else if (SearchBy == "Name")
                    {

                        var searshResult = subCategoryService.GetAll(PageIndex, PageSize).
                             Select(i => new ManageCategoryViewModel()
                             {
                                 ID = i.ID,
                                 Name = i.Name,
                                 Child = i.Child,
                                 Parent = i.Parent
                             }).Where(i => i.Name == SearchText);

                        result.Data = searshResult;
                    }
                    else if (SearchBy == "ID")
                    {

                        var searshResult = subCategoryService.GetAll(PageIndex, PageSize).
                             Select(i => new ManageCategoryViewModel()
                             {
                                 ID = i.ID,
                                 Name = i.Name,
                                 Child = i.Child,
                                 Parent = i.Parent
                             }).Where(i => i.ID == int.Parse(SearchText));

                        result.Data = searshResult;
                    }
                }
                else if (SearchIn == "Track")
                {
                    if (SearchBy == "Parent")
                    {

                        var searshResult = trackService.GetAll(PageIndex, PageSize).
                             Select(i => new ManageCategoryViewModel()
                             {
                                 ID = i.ID,
                                 Name = i.Name,
                                 Child = i.Child,
                                 Parent = i.Parent
                             }).Where(i => i.Parent == SearchText);

                        result.Data = searshResult;
                    }
                    else if (SearchBy == "Child")
                    {

                        var searshResult = trackService.GetAll(PageIndex, PageSize).
                             Select(i => new ManageCategoryViewModel()
                             {
                                 ID = i.ID,
                                 Name = i.Name,
                                 Child = i.Child,
                                 Parent = i.Parent
                             }).Where(i => i.Child.Contains(SearchText));

                        result.Data = searshResult;
                    }
                    else if (SearchBy == "Name")
                    {

                        var searshResult = trackService.GetAll(PageIndex, PageSize).
                             Select(i => new ManageCategoryViewModel()
                             {
                                 ID = i.ID,
                                 Name = i.Name,
                                 Child = i.Child,
                                 Parent = i.Parent
                             }).Where(i => i.Name == SearchText);

                        result.Data = searshResult;
                    }
                    else if (SearchBy == "ID")
                    {

                        var searshResult = trackService.GetAll(PageIndex, PageSize).
                             Select(i => new ManageCategoryViewModel()
                             {
                                 ID = i.ID,
                                 Name = i.Name,
                                 Child = i.Child,
                                 Parent = i.Parent
                             }).Where(i => i.ID == int.Parse(SearchText));

                        result.Data = searshResult;
                    }
                }
                else if (SearchIn == "Course")
                {
                    if (SearchBy == "Parent")
                    {

                        var searshResult = courseService.GetAll(PageIndex, PageSize).
                             Select(i => new ManageCategoryViewModel()
                             {
                                 ID = i.ID,
                                 Name = i.Name,
                                 Child = i.Child,
                                 Parent = i.Parent
                             }).Where(i => i.Parent == SearchText);

                        result.Data = searshResult;
                    }
                    else if (SearchBy == "Child")
                    {

                        var searshResult = courseService.GetAll(PageIndex, PageSize).
                             Select(i => new ManageCategoryViewModel()
                             {
                                 ID = i.ID,
                                 Name = i.Name,
                                 Child = i.Child,
                                 Parent = i.Parent
                             }).Where(i => i.Child.Contains(SearchText));

                        result.Data = searshResult;
                    }
                    else if (SearchBy == "Name")
                    {

                        var searshResult = courseService.GetAll(PageIndex, PageSize).
                             Select(i => new ManageCategoryViewModel()
                             {
                                 ID = i.ID,
                                 Name = i.Name,
                                 Child = i.Child,
                                 Parent = i.Parent
                             }).Where(i => i.Name == SearchText);

                        result.Data = searshResult;
                    }
                    else if (SearchBy == "ID")
                    {

                        var searshResult = courseService.GetAll(PageIndex, PageSize).
                             Select(i => new ManageCategoryViewModel()
                             {
                                 ID = i.ID,
                                 Name = i.Name,
                                 Child = i.Child,
                                 Parent = i.Parent
                             }).Where(i => i.ID == int.Parse(SearchText));

                        result.Data = searshResult;
                    }
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
        public String Delete( string SearchIn, int Num)
        {
            
            try
            {
                if (SearchIn == "MainCategory")
                {
                    if (mainCategoryService.GetByID(Num) != null)
                    {
                        mainCategoryService.Remove(Num);
                        return "mainCategory Deleted Sucessfully";
                    }
                    else
                        return "mainCategory Not Found !";

                }
                else if (SearchIn == "SubCategory")
                {
                    if (subCategoryService.GetByID(Num) != null)
                    {
                        subCategoryService.Remove(Num);
                        return "subCategory Deleted Sucessfully";
                    }
                    else
                        return "subCategory Not Found !";

                }
                else if (SearchIn == "Track")
                {

                    if (trackService.GetByID(Num) != null)
                    {
                        trackService.Remove(Num);
                        return "track Deleted Sucessfully";
                    }
                    else
                        return "track Not Found !";
                }
                else if (SearchIn == "Course")
                {
                     if (courseService.GetByID(Num) != null)
                    {
                        courseService.Remove(Num);
                        return "course Deleted Sucessfully";
                    }
                    else
                        return "course Not Found !";
                }



            }
            catch (Exception ex)
            {
                
               return  "Something Went Wrong !!";
            }

            return "";

        }

    }
}
