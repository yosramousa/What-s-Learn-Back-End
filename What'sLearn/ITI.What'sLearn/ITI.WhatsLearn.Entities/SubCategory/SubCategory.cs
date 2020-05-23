using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.WhatsLearn.Entities
{
    public class SubCategory : BaseModel
    {
        public string Name { get; set; }
        public string Discription { get; set; }
        public string Image { get; set; }
        public bool IsDeleted { get; set; }
        public virtual ICollection<SubCategoryLink> SubCategoryLinks { get; set; }
        public virtual ICollection<SubCategoryDocument> SubCategoryDocuments { get; set; }
        public virtual ICollection<SubCategoryVedio> SubCategoryVedios { get; set; }
        public virtual MainCategory MainCategory { get; set; }
        public int MainCategoryID { get; set; }
    }
}
