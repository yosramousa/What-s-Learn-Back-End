using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.WhatsLearn.ViewModel
{
   public  class CourseViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Discription { get; set; }
        public string Image { get; set; }
        public CourseLinkViewModel[] Links { get; set; }
        public CourseDocumentEditViewModel[] Documents { get; set; }
        public CourseVedioViewModel[] Vedios { get; set; }
        public TrackViewModel[] Tracks { get; set; }
        



    }
}
