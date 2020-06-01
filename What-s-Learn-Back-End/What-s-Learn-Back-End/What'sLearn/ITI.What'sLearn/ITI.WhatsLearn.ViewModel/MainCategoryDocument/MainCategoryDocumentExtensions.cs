using ITI.WhatsLearn.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.WhatsLearn.ViewModel
{
    public static class MainCategoryDocumentExtensions
    {
        public static MainCategoryDocumentViewModel ToViewModel(this MainCategoryDocument model)
        {
            return new MainCategoryDocumentViewModel()
            {
                ID=model.ID,
                File = model.File,
                Description = model.Description,
                ParentID=model.MainCategoryID



            };

        }
        public static MainCategoryDocument ToModel(this MainCategoryDocumentEditViewModel editmodel)
        {
            return new MainCategoryDocument()
            {
                ID = editmodel.ID,
                File = editmodel.File,
                Description = editmodel.Description,
                MainCategoryID=editmodel.ParentID
               


            };

        }

        public static MainCategoryDocumentEditViewModel ToEditableViewModel(this MainCategoryDocument model)
        {
            return new MainCategoryDocumentEditViewModel()
            {
                ID = model.ID,
                File = model.File,
                Description = model.Description,
                ParentID=model.MainCategoryID
            };
        }
    }
}
