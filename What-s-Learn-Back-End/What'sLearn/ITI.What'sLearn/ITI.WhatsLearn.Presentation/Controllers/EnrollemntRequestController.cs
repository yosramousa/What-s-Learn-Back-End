using ITI.WhatsLearn.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ITI.WhatsLearn.ViewModel;
using ITI.WhatsLearn.Entities;

namespace ITI.WhatsLearn.Presentation.Controllers
{
    public class EnrollemntRequestController : ApiController
    {
        UserTrackService userTrackService;
        public EnrollemntRequestController(UserTrackService _userTrackService)
        {
            userTrackService = _userTrackService;

        }
        [HttpGet]
        public ResultViewModel<IEnumerable<EnrollemntRequestViewModel>> GetList(int PagIndex, int Pagsize)
        {

            ResultViewModel<IEnumerable<EnrollemntRequestViewModel>> result
              = new ResultViewModel<IEnumerable<EnrollemntRequestViewModel>>();

            try
            {
                var tracksRequest = userTrackService.GetEnrollRequest(pageIndex: PagIndex, pageSize: Pagsize);
                result.Successed = true;
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
            try
            {

                if (SerachOption == 0)//By Name
                {
                    enrollRequests = userTrackService.SearchByName(SerachText, pageIndex: PageIndex, pageSize: PageSize);

                }
                else if (SerachOption == 1)//BY TrackName
                {
                    enrollRequests = userTrackService.SearchByTrackName(SerachText, pageIndex: PageIndex, pageSize: PageSize);
                }

                var EnrollRequests = enrollRequests.Select(i => new EnrollemntRequestViewModel
                {
                    ID = i.ID,
                    TrackName = i.TrackName,
                    UserName = i.UserName

                });
                result.Successed = true;
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
                UserTrack u = userTrackService.GetByID(id);
                u.IsApproveed = true;
                userTrackService.Update(u.ToEditableViewModel());
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
