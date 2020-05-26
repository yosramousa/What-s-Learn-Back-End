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
                TrackCourseName = model.UserTrackCourse.TrackCourse.Name,
                UserName = model.UserTrackCourse.User.Name,
                CourseName = model.course.Name,
                UserTrackCourseID =model.UserTrackCourseID               

            };
        }
        public static FinishedCourse ToModel(this FinishedCourseEditViewModel editModel)
        {
            return new FinishedCourse()
            {
                courseID = editModel.CourseID,
                UserTrackCourseID =editModel.UserTrackCourseID

            };
        }
        public static FinishedCourseEditViewModel ToEditableViewModel(this FinishedCourse model)
        {
            return new FinishedCourseEditViewModel
            {
                TrackCourseID = model.UserTrackCourse.TrackCourse.ID,
                UserID = model.UserTrackCourse.User.ID,
                CourseID = model.course.ID ,
                UserTrackCourseID = model.UserTrackCourseID

            };
        }
    }
}
