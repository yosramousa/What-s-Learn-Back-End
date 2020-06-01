using ITI.WhatsLearn.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.WhatsLearn.ViewModel
{
    public static class TrackCourseExtensions
    {
        public static TrackCourseViewModel ToViewModel(this TrackCourse model)
        {
            return new TrackCourseViewModel
            {
                ID = model.ID,
               TrackName=model.Track.Name,
               CourseName=model.Course.Name
            };
        }
        public static TrackCourse ToModel(this TrackCourseEditViewModel editModel)
        {
            return new TrackCourse
            {
                ID = editModel.ID,
                TrackID=editModel.TrackID,
                CourseID=editModel.CourseID
               
            };
        }
        public static TrackCourseEditViewModel ToEditableViewModel(this TrackCourse model)
        {
            return new TrackCourseEditViewModel
            {
                ID = model.ID,
                TrackID=model.TrackID,
                CourseID=model.CourseID
                
            };
        }

    }
}
