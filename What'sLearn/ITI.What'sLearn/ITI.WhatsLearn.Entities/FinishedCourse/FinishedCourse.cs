using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.WhatsLearn.Entities
{
    public class FinishedCourse:BaseModel
    {
        public Course course { get; set; }
        public int  courseID { get; set; }
        public UserTrackCourse UserTrackCourse { get; set; }
        public int UserTrackCourseID { get; set; }

    }
}
