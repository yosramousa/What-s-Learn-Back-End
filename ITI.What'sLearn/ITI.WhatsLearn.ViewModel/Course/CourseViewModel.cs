using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.WhatsLearn.ViewModel
{
   public  class CourseViewModel :ManageCategoryViewModel
    {

       
        public override int ID { get; set; }

        public override string Name { get; set; }

        public override string Parent { get; set; }

        public string Discription { get; set; }
        public string Image { get; set; }
        public List<CourseLinkViewModel> Links { get; set; }
        public List<CourseDocumentViewModel> Documents { get; set; }
        public List<CourseVedioViewModel> Vedios { get; set; }
        public TrackCourseViewModel[] TrackCourses { get; set; }
        



    }
}
