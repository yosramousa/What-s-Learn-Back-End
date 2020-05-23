using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.WhatsLearn.Entities
{
    public  class TrackCourse:BaseModel
    {
        public Track Track { get; set; }
        public int  TrackID { get; set; }
        public Course Course { get; set; }
        public int CourseID { get; set; }

    }
}
