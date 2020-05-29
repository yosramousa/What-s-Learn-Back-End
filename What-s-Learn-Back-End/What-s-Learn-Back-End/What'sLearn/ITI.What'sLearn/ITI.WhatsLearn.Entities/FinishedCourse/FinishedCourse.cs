using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.WhatsLearn.Entities
{
    public class FinishedCourse:BaseModel
    {
        public virtual Course course { get; set; }
        public int  courseID { get; set; }
        public virtual  UserTrack UserTrack { get; set; }
        public int UserTrackID { get; set; }

    }
}
