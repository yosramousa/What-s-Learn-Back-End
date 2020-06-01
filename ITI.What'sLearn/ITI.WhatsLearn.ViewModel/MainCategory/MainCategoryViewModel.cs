using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.WhatsLearn.ViewModel
{
   public  class MainCategoryViewModel:ManageCategoryViewModel
    {
      
        public override string Parent { get; set; } = "Main Category Parent";
       
        public string Discription { get; set; }

        public List<MainCategoryLinkViewModel> Links { get; set; }
        public List<MainCategoryDocumentViewModel> Documents { get; set; }
        public List<MainCategoryVedioViewModel> Vedios { get; set; }



    }
}
