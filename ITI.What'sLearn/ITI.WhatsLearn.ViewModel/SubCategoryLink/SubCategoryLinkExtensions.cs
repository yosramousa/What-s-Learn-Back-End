using ITI.WhatsLearn.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.WhatsLearn.ViewModel
{
   public static  class SubCategoryLinkExtensions
    {
        public static SubCategoryLinkViewModel ToViewModel(this  SubCategoryLink model)
        {
            return new SubCategoryLinkViewModel()
            {
                ID = model.ID,
                Link = model.Link,
                Description = model.Description,
                ParentID=model.SubCategoryID


            };

        }
        public static  SubCategoryLink ToModel(this  SubCategoryLinkEditViewModel editmodel)
        {
            return new  SubCategoryLink()
            {
                ID = editmodel.ID,
                Link = editmodel.Link,
                Description = editmodel.Description,
                SubCategoryID=editmodel.ParentID


            };

        }
        public static  SubCategoryLinkEditViewModel ToEditableViewModel(this  SubCategoryLink model)
        {
            return new  SubCategoryLinkEditViewModel()
            {
                ID = model.ID,
                Link = model.Link,
                Description = model.Description,
                ParentID=model.SubCategoryID
            };
        }

    }
}
