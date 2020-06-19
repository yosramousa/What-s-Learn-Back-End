using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.WhatsLearn.Entities
{
     public class UserTrack:BaseModel
    {
        public virtual  User User { get; set; }
        public int UserID { get; set; }

        public virtual Track Track { get; set; }
        public int TrackID { get; set; }
        public DateTime EnrollDate { get; set; }
        public DateTime FinshedDate { get; set; }

        public bool IsApproveed { get; set; } = false;


        public virtual ICollection<FinishedCourse> FinishedCourses { get; set; }


    }
}
