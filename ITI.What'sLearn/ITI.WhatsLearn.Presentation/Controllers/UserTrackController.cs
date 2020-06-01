using ITI.WhatsLearn.Entities;
using ITI.WhatsLearn.Services;
using ITI.WhatsLearn.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ITI.WhatsLearn.Presentation
{
    public class UserTrackController : ApiController
    {
        private readonly UserTrackService UserTrackService;
        public UserTrackController(UserTrackService _UserTrackService)
        {
            UserTrackService = _UserTrackService;
        }

        [HttpGet]
        public ResultViewModel<IEnumerable<UserTrackViewModel>> GetList()
        {
            ResultViewModel<IEnumerable<UserTrackViewModel>> result
                = new ResultViewModel<IEnumerable<UserTrackViewModel>>();
            try
            {
                var UserTracks = UserTrackService.GetAll(pageIndex:0);
                result.Successed = true;
                result.Data = UserTracks;
            }
            catch (Exception ex)
            {
                result.Successed = false;
                result.Message = "Something Went Wrong !!";
            }
            return result;
        }


        [HttpPost]
        public ResultViewModel<UserTrackEditViewModel> Post(UserTrackEditViewModel UserTrack)
        {
            ResultViewModel<UserTrackEditViewModel> result
                = new ResultViewModel<UserTrackEditViewModel>();

            try
            {
                if (!ModelState.IsValid)
                {
                    result.Message = "In Valid Model State";
                }
                else
                {
                    UserTrackEditViewModel selectedUserTrack
                        = UserTrackService.Add(UserTrack);

                    result.Successed = true;
                    result.Data = selectedUserTrack;
                }
            }
            catch (Exception ex)
            {
                result.Successed = false;
                result.Message = "Semething Went Wrong";
            }
            return result;
        }

        [HttpPost]
        public ResultViewModel<UserTrackEditViewModel> Update(UserTrackEditViewModel UserTrack)
        {
            ResultViewModel<UserTrackEditViewModel> result
                = new ResultViewModel<UserTrackEditViewModel>();

            try
            {
                if (!ModelState.IsValid)
                {
                    result.Message = "In Valid Model State";
                }
                else
                {
                    UserTrackEditViewModel selectedEmp
                        = UserTrackService.Update(UserTrack);

                    result.Successed = true;
                    result.Data = selectedEmp;
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
        public ResultViewModel<UserTrackViewModel> GetByID(int id)
        {
            ResultViewModel<UserTrackViewModel> result
                = new ResultViewModel<UserTrackViewModel>();
            try
            {
                var UserTrack = UserTrackService.GetByID(id)?.ToViewModel();
                result.Successed = true;
                result.Data = UserTrack;
            }
            catch (Exception ex)
            {
                result.Successed = false;
                result.Message = "Something Went Wrong !!";
            }
            return result;
        }

        [HttpGet]
        public string Delete(int id)
        {
            if (UserTrackService.GetByID(id) != null)
            {
                UserTrackService.Remove(id);
                return "UserTrack Deleted Sucessfully";
            }
            else
                return "UserTrack Not Found !";
        }

    }
}
