using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.WhatsLearn.Entities
{
    public class TrackCourseVedio : BaseModel
    {
        public string Vedio { get; set; }
        public string Description { get; set; }
        public virtual TrackCourse TrackCourse { get; set; }
        public int TrackCourseID { get; set; }
    }
}
