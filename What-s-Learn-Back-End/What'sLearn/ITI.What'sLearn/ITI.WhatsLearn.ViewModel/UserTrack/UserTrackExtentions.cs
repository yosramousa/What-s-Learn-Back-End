using ITI.WhatsLearn.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.ModelBinding;

namespace ITI.WhatsLearn.ViewModel
{
    public static class UserTrackExtentions
    {
        public static UserTrackViewModel ToViewModel(this UserTrack model)
        {
            return new UserTrackViewModel()
            {
                ID = model.ID,
                TrackName=model.Track.Name,
                UserName=model.User.Name,
                Date=model.Date,
                IsApproveed=model.IsApproveed,
              UserCount=model.Track.Users.Count
            };
        }
        public static UserTrack ToModel(this UserTrackEditViewModel editModel)
        {
            return new UserTrack()
            {
                ID = editModel.ID,
                TrackID = editModel.TrackID,
                UserID = editModel.UserID,
                Date = editModel.Date,
                IsApproveed = editModel.IsApproveed
            };
        }
        public static UserTrackEditViewModel ToEditableViewModel(this UserTrack model)
        {
            return new UserTrackEditViewModel()
            {
                ID = model.ID,
                UserID=model.UserID,
                TrackID=model.TrackID,
                Date=model.Date,
                IsApproveed=model.IsApproveed,
                UserCount = model.Track.Users.Count

            };
        }
    }
}
