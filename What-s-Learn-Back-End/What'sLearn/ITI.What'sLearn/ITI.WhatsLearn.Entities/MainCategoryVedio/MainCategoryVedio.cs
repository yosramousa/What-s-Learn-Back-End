using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.WhatsLearn.Entities
{
    public class MainCategoryVedio : BaseModel
    {
        public string Vedio { get; set; }
        public string Description { get; set; }
        public virtual MainCategory MainCategory { get; set; }
        public int MainCategoryID { get; set; }
    }
}
