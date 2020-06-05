using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ITI.WhatsLearn.ViewModel
{
    public class CourseDocumentEditViewModel
    {
        [Required]

        public int ID { get; set; }
       // [Required]
        //public HttpPostedFileBase Document { get; set; }
        [Required]
        public String File { get; set; }
        public int ParentID { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }
    }
}
