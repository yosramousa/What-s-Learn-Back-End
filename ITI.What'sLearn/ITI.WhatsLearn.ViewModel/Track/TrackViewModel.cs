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

        public  List<TrackLinkViewModel> Links { get; set; }
        public  List<TrackDocumentViewModel> Documents { get; set; }
        public List<TrackVedioViewModel> Vedios { get; set; }
        public String SubCategoryName { get; set; }
        public int ParentID { get; set; }

        public override List<string> Users { get; set; }


        public List<CourseViewModel> Courses { get; set ; }
    }
}
