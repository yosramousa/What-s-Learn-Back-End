using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.WhatsLearn.Entities
{
    public class CourseVedio : BaseModel
    {
        public string Vedio { get; set; }
        public string Description { get; set; }
        public virtual Course Course { get; set; }
        public int CourseID { get; set; }
    }
}
