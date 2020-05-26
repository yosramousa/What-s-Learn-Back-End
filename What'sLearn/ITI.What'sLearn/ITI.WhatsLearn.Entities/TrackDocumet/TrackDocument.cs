using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.WhatsLearn.Entities
{
    public class  TrackCourseDocument : BaseModel
    {
        public string File { get; set; }
        public string Description { get; set; }
        public virtual TrackCourse TrackCourse { get; set; }
        public int TrackCourseID { get; set; }

    }
}
