using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.WhatsLearn.ViewModel
{
    public class LevelViewModel
    {
        public  int ID { get; set; }
        public  string Name { get; set; }
        public string Discription { get; set; }
        public string Image { get; set; }
        public List<MainCategoryLinkViewModel> Links { get; set; }
        public List<MainCategoryDocumentViewModel> Documents { get; set; }
        public List<MainCategoryVedioViewModel> Vedios { get; set; }
    }
}
