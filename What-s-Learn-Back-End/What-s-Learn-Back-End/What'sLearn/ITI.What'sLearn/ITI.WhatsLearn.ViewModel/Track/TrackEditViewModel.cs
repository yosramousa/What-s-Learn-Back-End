using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ITI.WhatsLearn.ViewModel
{
   public  class TrackEditViewModel 
    {
  
        public  int ID { get; set; }

        [Required]
        [MaxLength(250)]
        public  string Name { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Discription { get; set; }


        public HttpPostedFileBase Photo { get; set; }

        public String Image { get; set; }
        [Required]
        public int ParentID { get; set; }
        public String Parent { get; set; }
        public List<string> Childs { get; set; }

        [Required]
        public TrackLinkEditViewModel[] Links { get; set; }

        [Required]
        public TrackDocumentEditViewModel[] Documents { get; set; }

        [Required]
        public TrackVedioEditViewModel[] Vedios { get; set; }


    }
}
