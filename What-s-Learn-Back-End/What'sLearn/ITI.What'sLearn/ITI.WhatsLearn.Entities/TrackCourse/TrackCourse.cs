using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.WhatsLearn.Entities
{
    public  class TrackCourse:BaseModel
    {
        public virtual Track Track { get; set; }
        public int  TrackID { get; set; }
        public virtual Course Course { get; set; }
        public int CourseID { get; set; }

    }
}
