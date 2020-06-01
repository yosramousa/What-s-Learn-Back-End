using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.WhatsLearn.ViewModel
{
   public  class TrackViewModel: ManageCategoryViewModel
    {
       
        public string Discription { get; set; }

        public TrackLinkViewModel[] Links { get; set; }
        public TrackDocumentViewModel[] Documents { get; set; }
        public TrackVedioViewModel[] Vedios { get; set; }
        public String SubCategoryName { get; set; }
        public int ParentID { get; set; }

       
       
        public  List<CourseViewModel> Courses { get; set ; }
    }
}
