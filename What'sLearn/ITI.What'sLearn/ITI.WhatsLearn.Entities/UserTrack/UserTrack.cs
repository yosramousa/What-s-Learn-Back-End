using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.WhatsLearn.Entities
{
     public class UserTrackCourse:BaseModel
    {
        public User User { get; set; }
        public int UserID { get; set; }

        public TrackCourse TrackCourse { get; set; }
        public int TrackCourseID { get; set; }
        public DateTime Date { get; set; }
        public bool IsApproveed { get; set; } = false;

        public virtual ICollection<FinishedCourse> FinishedCourses { get; set; }

    }
}
