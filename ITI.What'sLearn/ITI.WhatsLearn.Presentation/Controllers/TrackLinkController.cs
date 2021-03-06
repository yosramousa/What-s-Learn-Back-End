﻿using ITI.WhatsLearn.Entities;
using ITI.WhatsLearn.Presentation.Filters;
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
     [AUTHORIZE(Roles = "User,Admin")]

    public class TrackLinkController : ApiController
    {
        private readonly TrackService trackService;
        public TrackLinkController(TrackService _trackService)
        {
            trackService = _trackService;
        }

        [HttpGet]
        public ResultViewModel<IEnumerable<TrackViewModel>> GetList()
        {
            ResultViewModel<IEnumerable<TrackViewModel>> result
                = new ResultViewModel<IEnumerable<TrackViewModel>>();
            int count = 0;
            try
            {
                var Tracks = trackService.GetAll(out count, 0, 0, 100);
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
        public ResultViewModel<Track> Post(TrackEditViewModel Track)
        {
            ResultViewModel<Track> result
                = new ResultViewModel<Track>();

            try
            {
                if (!ModelState.IsValid)
                {
                    result.Message = "In Valid Model State";
                }
                else
                {
                    Track selectedTrack
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
        public ResultViewModel<Track> Update(TrackEditViewModel track)
        {
            ResultViewModel<Track> result
                = new ResultViewModel<Track>();

            try
            {
                if (!ModelState.IsValid)
                {
                    result.Message = "In Valid Model State";
                }
                else
                {
                    Track selectedEmp
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
