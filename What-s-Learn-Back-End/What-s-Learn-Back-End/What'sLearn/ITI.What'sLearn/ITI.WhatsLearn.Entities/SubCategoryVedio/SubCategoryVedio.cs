using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.WhatsLearn.Entities
{
    public class SubCategoryVedio : BaseModel
    {
        public string Vedio { get; set; }
        public string Description { get; set; }
        public virtual SubCategory SubCategory { get; set; }
        public int SubCategoryID { get; set; }
    }
}
