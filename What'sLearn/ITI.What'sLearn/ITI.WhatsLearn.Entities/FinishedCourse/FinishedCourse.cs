using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.WhatsLearn.Entities
{
    public class FinishedCourse
    {
        public Course course { get; set; }
        public int  courseID { get; set; }
        public UserTrack UserTrack { get; set; }
        public int UserTrackID { get; set; }

    }
}
