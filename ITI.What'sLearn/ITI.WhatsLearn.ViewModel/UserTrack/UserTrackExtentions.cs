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
                TrackName = model.Track.Name,
                UserName = model.User.Name,
                Date = model.Date,
                IsApproveed = model.IsApproveed,
                UserCount = model.Track.Users.Count
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
                UserID = model.UserID,
                TrackID = model.TrackID,
                Date = model.Date,
                IsApproveed = model.IsApproveed,
                UserCount = model.Track?.Users?.Count

            };
        }

        public static UserProfileTracksViewModel ToUserProfileTracksViewModel(this UserTrack model)
        {
            UserProfileTracksViewModel m = new UserProfileTracksViewModel()
            {
                ID = model.TrackID,
                Name = model.Track?.Name,
                Progess = ((float)model.FinishedCourses.Count() / model.Track.Courses.Count()) * 100,
                Courses = model.Track.Courses.Select(i => i.Course.ToUserProfileCourseViewModel()).ToList()
            };
            m.Courses.ForEach(x =>
            {
                if (model.FinishedCourses.Select(i => i.course.ID).ToList().Contains(x.ID))
                {
                    x.IsFinshed = true;

                }
            }); return m;

        }
        public static UserFinishedTrackViewModel ToFinishedTracks(this UserTrack model)
        {
            return new UserFinishedTrackViewModel()
            {
                TrackID = model.TrackID,
                TrackName = model.Track.Name
            };
        }

        //public static UserProfileViewModel ToUserProfileViewModel(this UserTrack model)
        //{
        //    return new UserProfileViewModel()
        //    {
        //        //ID = model.ID,
        //        //Name = model.Name,
        //        //Adress = model.Adress,
        //        //Age = model.Age,
        //        //Education = model.Education,
        //        //Gender = model.Gender,
        //        //Phone = model.Phone,
        //        //Image = model.Image,
        //        //Skills = model.Skills.Select(i => i.ToViewModel()).ToList(),
        //        //Certificates = model.Certificates.Select(i => i.ToViewModel()).ToList(),
        //        //Tracks = model.Tracks.Select(i => i.ToUserProfileTracksViewModel()).ToList()




        //    };

        //}
    }
}
