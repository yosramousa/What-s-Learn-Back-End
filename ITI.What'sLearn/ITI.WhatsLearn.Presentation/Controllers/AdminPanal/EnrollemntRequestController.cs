using ITI.WhatsLearn.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ITI.WhatsLearn.ViewModel;
using ITI.WhatsLearn.Entities;
using ITI.WhatsLearn.Presentation.Filters;
using System.Threading;

namespace ITI.WhatsLearn.Presentation.Controllers
{
    [AUTHORIZE(Roles = "Admin")]
    public class EnrollemntRequestController : ApiController
    {
        UserTrackService userTrackService;
        public EnrollemntRequestController(UserTrackService _userTrackService)
        {
            userTrackService = _userTrackService;

        }
        [HttpGet]
        public ResultViewModel<IEnumerable<EnrollemntRequestViewModel>> GetList(int PageIndex, int PageSize)
        {

            ResultViewModel<IEnumerable<EnrollemntRequestViewModel>> result
              = new ResultViewModel<IEnumerable<EnrollemntRequestViewModel>>();

            try
            {
                var tracksRequest = userTrackService.GetEnrollRequest(pageIndex: PageIndex, pageSize: PageSize);
                result.Successed = true;
                result.Count = userTrackService.Count();

                result.Data = tracksRequest.Select(i => new EnrollemntRequestViewModel()
                {
                    ID = i.ID,
                    TrackName = i.TrackName,
                    UserName = i.UserName
                });
            }
            catch (Exception ex)
            {
                result.Successed = false;
                result.Message = "Something Went Wrong !!";
            }
            return result;

        }

        [HttpGet]
        public ResultViewModel<IEnumerable<EnrollemntRequestViewModel>> Search(int SerachOption, String SerachText, int PageIndex, int PageSize)
        {
            ResultViewModel<IEnumerable<EnrollemntRequestViewModel>> result
              = new ResultViewModel<IEnumerable<EnrollemntRequestViewModel>>();
            IEnumerable<UserTrackViewModel> enrollRequests = new List<UserTrackViewModel>();
            int count = 0;
            try
            {
                if (SerachOption == 0)//By Name
                {
                    enrollRequests = userTrackService.GetRequest(out count, pageIndex: PageIndex, pageSize: PageSize);

                }
                if (SerachOption == 1)//By Name
                {
                    enrollRequests = userTrackService.SearchByName(out count,SerachText, pageIndex: PageIndex, pageSize: PageSize);

                }
                else if (SerachOption == 2)//BY TrackName
                {
                    enrollRequests = userTrackService.SearchByTrackName(out count,SerachText, pageIndex: PageIndex, pageSize: PageSize);
                }

                var EnrollRequests = enrollRequests.Select(i => new EnrollemntRequestViewModel
                {
                    ID = i.ID,
                    TrackName = i.TrackName,
                    UserName = i.UserName

                });
                result.Successed = true;
                result.Count = count;
                result.Data = EnrollRequests;
            }
            catch (Exception ex)
            {
                result.Successed = false;
                result.Message = "Something Went Wrong !!";
            }
            return result;

        }

        [HttpGet]
        public string Approve(int id)
        {
            try
            {
               
                userTrackService.Approve(id);
                return "Track Approved Sucessfully";
            }
            catch (Exception e)
            {
                return "Error";
            }

        }

        [HttpGet]
        public string Cancel (int id)
        {
            try
            {
                userTrackService.Remove(id);
                return "Track Canceld Sucessfully";
            }
            catch(Exception e)
            {
                return "Error";

            }
        }
    }
}
