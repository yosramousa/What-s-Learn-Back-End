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
    public class TrackController : ApiController
    {
        private readonly TrackService trackService;
        public TrackController(TrackService _trackService)
        {
            trackService = _trackService;
        }

        [HttpGet]
        public ResultViewModel<IEnumerable<TrackViewModel>> GetList()
        {
            ResultViewModel<IEnumerable<TrackViewModel>> result
                = new ResultViewModel<IEnumerable<TrackViewModel>>();
            try
            {
                var Tracks = trackService.GetAll();
                result.Successed = true;
                result.Data = Tracks;
            }
            catch (Exception ex)
            {
                result.Successed = false;
                result.Message = "Something Went Wrong !!";
            }
            return result;
        }


        [HttpPost]
        public ResultViewModel<TrackEditViewModel> Post(TrackEditViewModel Track)
        {
            ResultViewModel<TrackEditViewModel> result
                = new ResultViewModel<TrackEditViewModel>();

            try
            {
                if (!ModelState.IsValid)
                {
                    result.Message = "In Valid Model State";
                }
                else
                {
                    TrackEditViewModel selectedTrack
                        = trackService.Add(Track);
                   
                    result.Successed = true;
                    result.Data = selectedTrack;
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
        public ResultViewModel<TrackEditViewModel> Update(TrackEditViewModel track)
        {
            ResultViewModel<TrackEditViewModel> result
                = new ResultViewModel<TrackEditViewModel>();

            try
            {
                if (!ModelState.IsValid)
                {
                    result.Message = "In Valid Model State";
                }
                else
                {
                    TrackEditViewModel selectedEmp
                        = trackService.Update(track);

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
        public ResultViewModel<TrackViewModel> GetByID(int id)
        {
            ResultViewModel<TrackViewModel> result
                = new ResultViewModel<TrackViewModel>();
            try
            {
                var Track =  trackService.GetByID(id)?.ToViewModel();
                result.Successed = true;
                result.Data = Track;
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
            if (trackService.GetByID(id) != null)
            {
                trackService.Remove(id);
                return "Track Deleted Sucessfully";
            }
            else
                return "Track Not Found !";
        }

    }
}
