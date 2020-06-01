using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ITI.WhatsLearn.ViewModel
{
    public class MainCategoryEditViewModel 
    {
        [Required]
        public  int ID { get; set; } 

        [Required]
        [MaxLength(250)]
        public  string Name { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Discription { get; set; }
      
        public string Image { get; set; }

        [Required]
        public MainCategoryLinkEditViewModel[] Links { get; set; }

        [Required]
        public MainCategoryDocumentEditViewModel[] Documents { get; set; }

        [Required]
        public MainCategoryVedioEditViewModel[] Vedios { get; set; }
        public  string Parent { get; set; }
        public  List<string> Child { get; set; }


    }
}
