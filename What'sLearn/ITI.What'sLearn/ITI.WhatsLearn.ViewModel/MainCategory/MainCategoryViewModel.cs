using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.WhatsLearn.ViewModel
{
   public  class MainCategoryViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Discription { get; set; }
        public string Image { get; set; }
        /// <summary>
        /// ////////////////////////////////////////////
        /// </summary>
        public MainCategoryLinkViewModel[] Links { get; set; }
        public MainCategoryDocumentViewModel[] Documents { get; set; }
        public MainCategoryVedioViewModel[] Vedios { get; set; }
        public SubCategoryViewModel[] SubCategories { get; set; }
    }
}
