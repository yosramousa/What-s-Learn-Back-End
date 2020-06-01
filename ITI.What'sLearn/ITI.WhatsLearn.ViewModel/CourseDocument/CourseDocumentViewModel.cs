using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.WhatsLearn.ViewModel
{
   public  class CourseDocumentViewModel
    {
        public int ID { get; set; }
        public string File { get; set; }
        public string Description { get; set; }
        public int ParentID { get; set; }

    }
}
