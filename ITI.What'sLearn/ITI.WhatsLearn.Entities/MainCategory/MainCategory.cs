using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.WhatsLearn.Entities
{
    public class MainCategory :BaseModel
    {
        public string Name { get; set; }
        public string Discription { get; set; }
        public string Image { get; set; }
        public string Icon { get; set; }

        public virtual ICollection<MainCategoryLink> MainCategoryLinks { get; set; }
        public virtual ICollection<MainCategoryDocument> MainCategoryDocuments { get; set; }
        public virtual ICollection<MainCategoryVedio> MainCategoryVedios { get; set; }
        public virtual ICollection<SubCategory> SubCategories { get; set; }

    }
}
