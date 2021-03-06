﻿using ITI.WhatsLearn.Presentation.Filters;
using ITI.WhatsLearn.Presentation.Hubs;
using ITI.WhatsLearn.Services;
using ITI.WhatsLearn.ViewModel;
using ITI.WhatsLearnServices;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ITI.WhatsLearn.Presentation.Controllers
{
    [AUTHORIZE(Roles = "User,Admin")]

    public class MainCategoryController : ApiController
    {
        private readonly MainCategoryService mainCategoryService;
        private readonly IHubContext Hub;

        public MainCategoryController(MainCategoryService _mainCategoryService)
        {
            mainCategoryService = _mainCategoryService;
            Hub = GlobalHost.ConnectionManager.GetHubContext<WhatsLearnHub>();

        }

        [HttpGet]
        public ResultViewModel<IEnumerable<MainCategoryViewModel>> GetList(int pageIndex, int pageSize = 20)
        {
            ResultViewModel<IEnumerable<MainCategoryViewModel>> result
               = new ResultViewModel<IEnumerable<MainCategoryViewModel>>();
            int count = 0;
            try
            {
                var MainCategories = mainCategoryService.GetAll(out count, 0, pageIndex, pageSize);
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
                    Hub.Clients.All.MainCategoryCount(mainCategoryService.Count());

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
