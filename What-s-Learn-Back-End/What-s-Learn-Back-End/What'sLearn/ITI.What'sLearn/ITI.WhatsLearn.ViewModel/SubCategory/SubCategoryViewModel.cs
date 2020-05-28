using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.WhatsLearn.ViewModel
{
   public  class SubCategoryViewModel :ManageCategoryViewModel
    {
        public override int ID { get; set; }
        public override string Name { get; set; }
        public string Discription { get; set; }
        public string Image { get; set; }
        public SubCategoryLinkViewModel[] Links { get; set; }
        public SubCategoryDocumentViewModel[] Documents { get; set; }
        public SubCategoryVedioViewModel[] Vedios { get; set; }
        public String MainCategoryName { get; set; }
        public TrackCourseViewModel[] TrackCourses { get; set; }
        public override string Parent { get; set; }
        public override List<string> Child { get; set; }


    }
}
