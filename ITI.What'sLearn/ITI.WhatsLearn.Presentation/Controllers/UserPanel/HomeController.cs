using BroadCaster.Helpers;
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
    public class HomeController : ApiController
    {
        private readonly MainCategoryService mainCategoryService;
        private readonly SubCategoryService subCategoryService;
        private readonly TrackService trackService;
        private readonly CourseService courseService;
        private readonly UserTrackService userTrackService;

        public HomeController
            (
             MainCategoryService _mainCategoryService,
             SubCategoryService _subCategoryService,
             TrackService _trackService,
             CourseService _courseService,
             UserTrackService _userTrackService

            )
        {
            mainCategoryService = _mainCategoryService;
            subCategoryService = _subCategoryService;
            trackService = _trackService;
            courseService = _courseService;
            userTrackService = _userTrackService;
        }
        [HttpGet]

        public ResultViewModel<IEnumerable<HomeViewModel>> GetAllMainCategory(int PageSize, int PageIndex)
        {
            ResultViewModel<IEnumerable<HomeViewModel>> result
                = new ResultViewModel<IEnumerable<HomeViewModel>>();
            int count = 0;

            try
            {
                result.Data = mainCategoryService.GetAll(out count,0,PageIndex, PageSize).Select(i => i.ToHomeViewmodel());
                result.Successed = true;
                result.Count = count;
            }
            catch (Exception ex)
            {
                result.Successed = false;
                result.Message = "Something Went Wrong !!";
                
            }
            return result;
        }

        [HttpGet]
        public ResultViewModel<DataDetails> GetByID(int ID, int Level, int PageSize, int PageIndex)
        {
            ResultViewModel<DataDetails> result
                = new ResultViewModel<DataDetails>();
            DataDetails details = new DataDetails();
            int count = 0;
            try
            {
                switch (Level)
                {
                    case 1:
                        details.LevelDetails = mainCategoryService.GetByID(ID);
                        details.Childs = subCategoryService.GetByParentID(out count,ID, PageIndex, PageSize).Select(i => i.ToHomeViewmodel()).ToList();
                        break;
                    case 2:
                        details.LevelDetails = subCategoryService.GetByID(ID);
                        details.Childs = trackService.GetByParentID(out count,ID, PageIndex, PageSize).Select(i => i.ToHomeViewmodel()).ToList();
                        break;
                    case 3:
                        details.LevelDetails = trackService.GetByID(ID).ToViewModel();
                        details.Childs = courseService.GetByParentID(out count,ID, PageIndex, PageSize).Select(i => i.ToHomeViewmodel()).ToList();
                        //details.Childs = trackService.GetByID(ID).Courses.Select(i => i.Course.ToViewModel().ToHomeViewmodel()).ToList();
                        break;
                }
                result.Data = details;
                result.Successed = true;
                result.Count = count;
            }
            catch (Exception ex)
            {
                result.Successed = false;
                result.Message = "Something Went Wrong !!";
            }
            return result;
        }

        [HttpGet]
        public ResultViewModel<IEnumerable<LevelSerachViewModel>> GetList(int level = 1, int ParentID =1)
        {
            ResultViewModel<IEnumerable<LevelSerachViewModel>> result
          = new ResultViewModel<IEnumerable<LevelSerachViewModel>>();

            
            try
            {
                if (level == 1)
                {
                    result.Data = mainCategoryService.GetAll().Select(i => i.TolevelSerachViewModel());
                    //main
                }
                else if (level == 2)
                {
                    //sub
                    result.Data = subCategoryService.Get(i => i.MainCategoryID == ParentID).Select(i => i.TolevelSerachViewModel());
                }
                else
                {
                    //track
                    result.Data = trackService.Get(i => i.SubCategoryID == ParentID).Select(i => i.TolevelSerachViewModel());


                }
                result.Successed = true;

            }
            catch
            {
                result.Successed = false;

            }
            return result;

        }
        [HttpGet]
        public ResultViewModel<UserTrackEditViewModel> Enroll(int TrackID)
        {

            ResultViewModel<UserTrackEditViewModel> result = new ResultViewModel<UserTrackEditViewModel>();
            try
            {
                string Token = Request.Headers.Authorization?
                       .Parameter;

                Dictionary<string, string>
                                cliams = SecurityHelper.Validate(Token);
                int UserID = int.Parse(cliams.First(i => i.Key == "ID").Value);

                if (userTrackService.GetUserTracksCount(UserID) < 2)
                {
                    UserTrackEditViewModel userTrack = userTrackService.Add(new UserTrackEditViewModel()
                    {
                        ID = 0,
                        TrackID = TrackID,
                        UserID = UserID,
                        Date = DateTime.Now,
                        IsApproveed = false
                    });
                    result.Successed = true;
                    result.Data = userTrack;
                }
                else
                {

                    result.Successed = false;
                    result.Message = "User exceeded the maximum number of incomplete tracks ";

                }


            }
            catch (Exception e)
            {
                result.Successed = false;
                result.Message = "Error";

            }

            return result;

        }

        [HttpGet]
        public ResultViewModel<IEnumerable<MenuVewModel>> GetAll()
        {
            ResultViewModel<IEnumerable<MenuVewModel>> result
          = new ResultViewModel<IEnumerable<MenuVewModel>>();
            try
            {

                result.Data = mainCategoryService.Get().Select(i => i.ToMenuVewModel()).ToList();
                result.Successed = true;
            }
            catch(Exception ex)
            {
                result.Successed = false;
               
            }
            return result;


        }

    }
}
