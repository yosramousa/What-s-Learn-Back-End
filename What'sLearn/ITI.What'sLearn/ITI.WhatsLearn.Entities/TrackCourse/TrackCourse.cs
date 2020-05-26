using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.WhatsLearn.Entities
{
    public  class TrackCourseCourse:BaseModel
    {
        public TrackCourse TrackCourse { get; set; }
        public int  TrackCourseID { get; set; }
        public Course Course { get; set; }
        public int CourseID { get; set; }

    }
}
