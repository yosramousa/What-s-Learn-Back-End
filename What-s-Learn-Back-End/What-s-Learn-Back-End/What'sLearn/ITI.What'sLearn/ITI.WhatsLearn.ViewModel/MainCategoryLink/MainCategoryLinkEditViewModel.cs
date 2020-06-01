using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.WhatsLearn.ViewModel
{
    public  class MainCategoryLinkEditViewModel
    {
      
        public int ID { get; set; }
        [Required]
        [MaxLength(1000)]
        public string Link { get; set; }
        [MaxLength(250)]
        public string Description { get; set; }
        [Required]
        public int ParentID { get; set; }


    }
}
