using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ITI.WhatsLearn.ViewModel
{
   public  class CourseEditViewModel 
    {
        
       
        [Required]
        public  int ID { get; set; }

        [Required]
        [MaxLength(250)]
        public  string Name { get; set; }

        public  string Parent { get; set; }
        public  List<string> Childs { get; set; }
        [Required]
        [MaxLength(1000)]
        public string Discription { get; set; }


        public HttpPostedFileBase Photo { get; set; }

        public String Image { get; set; }
        public int ParentID { get; set; }

        [Required]
        public List<CourseLinkEditViewModel> Links { get; set; }
        [Required]

        public List<CourseDocumentEditViewModel> Documents { get; set; }
        [Required]

        public List<CourseVedioEditViewModel> Vedios { get; set; }
    }
}
