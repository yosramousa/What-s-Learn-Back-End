using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.WhatsLearn.ViewModel
{
   public  class SubCategoryViewModel :ManageCategoryViewModel
    {
        
        public string Discription { get; set; }
        
        public List<SubCategoryLinkViewModel> Links { get; set; }
        public List<SubCategoryDocumentViewModel> Documents { get; set; }
        public List<SubCategoryVedioViewModel> Vedios { get; set; }
        public String MainCategoryName { get; set; }
        public int ParentID { get; set; }

        public TrackCourseViewModel[] TrackCourses { get; set; }
       


    }
}
