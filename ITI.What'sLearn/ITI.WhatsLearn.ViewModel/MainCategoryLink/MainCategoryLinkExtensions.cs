using ITI.WhatsLearn.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.WhatsLearn.ViewModel
{
    public static class MainCategoryLinkExtensions
    {

        public static MainCategoryLinkViewModel ToViewModel(this MainCategoryLink model)
        {
            return new MainCategoryLinkViewModel()
            {
                ID = model.ID,
                Link = model.Link,
                Description = model.Description,
                ParentID = model.MainCategoryID



            };

        }
        public static MainCategoryLink ToModel(this MainCategoryLinkEditViewModel editmodel)
        {
            return new MainCategoryLink()
            {
                ID = editmodel.ID,
                Link = editmodel.Link,
                Description = editmodel.Description,
                MainCategoryID = editmodel.ParentID

            };

        }
        public static MainCategoryLinkEditViewModel ToEditableViewModel(this MainCategoryLink model)
        {
            return new MainCategoryLinkEditViewModel()
            {
                ID = model.ID,
                Link = model.Link,
                Description = model.Description,
                ParentID = model.MainCategoryID

            };
        }
    }
}
