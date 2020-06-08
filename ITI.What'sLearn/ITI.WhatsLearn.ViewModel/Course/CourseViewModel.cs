using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.WhatsLearn.ViewModel
{
   public  class CourseViewModel :ManageCategoryViewModel
    {
        public string Discription { get; set; }
        public List<CourseLinkViewModel> Links { get; set; }
        public List<CourseDocumentViewModel> Documents { get; set; }
        public List<CourseVedioViewModel> Vedios { get; set; }
        public List<String> Tracks { get; set; }
        public bool IsFinshed { get; set; }

       





    }
}
