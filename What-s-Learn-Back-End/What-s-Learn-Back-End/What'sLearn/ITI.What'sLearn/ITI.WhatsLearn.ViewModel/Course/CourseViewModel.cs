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
        public override List<string> Child { get; set; }

        public string Discription { get; set; }
        public string Image { get; set; }
        public CourseLinkViewModel[] Links { get; set; }
        public CourseDocumentViewModel[] Documents { get; set; }
        public CourseVedioViewModel[] Vedios { get; set; }
        public TrackCourseViewModel[] TrackCourses { get; set; }
        



    }
}
