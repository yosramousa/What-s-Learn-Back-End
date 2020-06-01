using ITI.WhatsLearn.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.WhatsLearn.ViewModel
{
    public static class FinishedCourseExtentions
    {
        public static FinishedCourseViewModel ToViewModel(this FinishedCourse model)
        {
            return new FinishedCourseViewModel()
            {
                TrackName = model.UserTrack.Track.Name,
                UserName = model.UserTrack.User.Name,
                CourseName = model.course.Name,
                UserTrackID = model.UserTrackID               

            };
        }
        public static FinishedCourse ToModel(this FinishedCourseEditViewModel editModel)
        {
            return new FinishedCourse()
            {
                courseID = editModel.CourseID,
                UserTrackID = editModel.UserTrackID

            };
        }
        public static FinishedCourseEditViewModel ToEditableViewModel(this FinishedCourse model)
        {
            return new FinishedCourseEditViewModel
            {
                TrackID = model.UserTrack.Track.ID,
                UserID = model.UserTrack.User.ID,
                CourseID = model.course.ID ,
                UserTrackID = model.UserTrackID

            };
        }
    }
}
