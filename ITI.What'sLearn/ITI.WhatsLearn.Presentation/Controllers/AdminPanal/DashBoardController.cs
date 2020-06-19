using ITI.WhatsLearn.Presentation.Filters;
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
    [AUTHORIZE(Roles = "Admin")]

    public class DashBoardController : ApiController
    {
        MainCategoryService mainCategoryService;
        UserService userService;
        TrackService trackService;
        UserTrackService userTrackService;
        AdminService adminService;
        private readonly ConfigurationService ConfigService;

        public DashBoardController(

            MainCategoryService _mainCategoryService,
            UserService  _userService,
            TrackService _trackService,
            UserTrackService _userTrackService,
                    AdminService _adminService,
                    ConfigurationService _configService

            )
        {
            mainCategoryService = _mainCategoryService;
            userService = _userService;
            trackService = _trackService;
            userTrackService = _userTrackService;
            adminService = _adminService;
            ConfigService = _configService;
        }
        [HttpGet]

        public Dictionary<string , Dictionary<string,int>> GatAllData()
        {
            Dictionary<string, Dictionary<string, int>> result = new Dictionary<string, Dictionary<string, int>>();
            result.Add("Statistic", GetData());
            result.Add("MonthlyChart", userService.UpdateLineChart());
            result.Add("PiChart", userTrackService.GetPieChartData());
            return result;
        }

        [HttpGet]
        public Dictionary<string , int> GetData()
        {
            Dictionary<string, int> result = new Dictionary<string, int>();
            result.Add("MainCategoryCount", mainCategoryService.Count());
            result.Add("VisitorCount", ConfigService.Count("VisitorCount"));
            result.Add("trackCount", trackService.Count());
            result.Add("UserCount", userService.Count());

            return result;
        }

       

    }
}
