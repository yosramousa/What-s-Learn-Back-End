using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.WhatsLearn.ViewModel
{
    public class UserProfileTracksViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<UserProfileCourseViewModel> Courses { get; set; }
        public float Progess { get; set; }

    }
}
