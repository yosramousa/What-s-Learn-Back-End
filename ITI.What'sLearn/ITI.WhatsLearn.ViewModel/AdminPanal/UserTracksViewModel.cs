using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.WhatsLearn.ViewModel
{
     public  class UserTracksViewModel
    {
        public int ID { get; set; } 
        public string TrackName { get; set; }
        public double Progress { get; set; }
        public List<String> FinshedCourses { get; set; }
        public List<String> FutureCourses { get; set; }
        public string CuurentCourse { get; set; }

    }
}
