using ITI.WhatsLearn.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.WhatsLearn.ViewModel
{
   public static class SubCategoryDocumentExtensions
    {

        public static SubCategoryDocumentViewModel ToViewModel(this SubCategoryDocument model)
        {
            return new SubCategoryDocumentViewModel()
            {
                ID = model.ID,
                File = model.File,
                Description = model.Description,
                ParentID=model.SubCategoryID


            };

        }
        public static SubCategoryDocument ToModel(this SubCategoryDocumentEditViewModel editmodel)
        {
            return new SubCategoryDocument()
            {
                ID = editmodel.ID,
                File = editmodel.File,
                Description = editmodel.Description,
                SubCategoryID=editmodel.ParentID


            };

        }

        public static SubCategoryDocumentEditViewModel ToEditableViewModel(this SubCategoryDocument model)
        {
            return new SubCategoryDocumentEditViewModel()
            {
                ID = model.ID,
                File = model.File,
                Description = model.Description,
                ParentID=model.SubCategoryID
            };
        }

    }
}
