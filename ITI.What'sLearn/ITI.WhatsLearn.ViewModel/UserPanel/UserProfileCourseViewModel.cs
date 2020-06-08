using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.WhatsLearn.ViewModel
{
    public class UserProfileCourseViewModel
    { 
        public virtual int ID { get; set; }
        public virtual string Name { get; set; }
        public string Image { get; set; }
        public string Discription { get; set; }
        public bool IsFinshed { get; set; }
        public List<CourseLinkViewModel> Links { get; set; }
        public List<CourseDocumentViewModel> Documents { get; set; }
        public List<CourseVedioViewModel> Vedios { get; set; }
    }
    
}
