using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.WhatsLearn.ViewModel
{
   public  class SubCategoryViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Discription { get; set; }
        public string Image { get; set; }
        public SubCategoryLinkViewModel[] Links { get; set; }
        public SubCategoryDocumentViewModel[] Documents { get; set; }
        public SubCategoryVedioViewModel[] Vedios { get; set; }
        public String MainCategoryName { get; set; }
        public TrackViewModel[] Tracks { get; set; }



    }
}
