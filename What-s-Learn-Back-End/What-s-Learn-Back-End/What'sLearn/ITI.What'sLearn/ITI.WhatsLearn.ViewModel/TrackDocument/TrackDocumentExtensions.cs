using ITI.WhatsLearn.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.WhatsLearn.ViewModel
{
   public static class TrackDocumentExtensions
    {

        public static TrackDocumentViewModel ToViewModel(this TrackDocument model)
        {
            return new TrackDocumentViewModel()
            {
                ID = model.ID,
                File = model.File,
                Description = model.Description,
                ParentID=model.TrackID


            };

        }
        public static TrackDocument ToModel(this TrackDocumentEditViewModel editmodel)
        {
            return new TrackDocument()
            {
                ID = editmodel.ID,
                File = editmodel.File,
                Description = editmodel.Description,
                TrackID=editmodel.ParentID


            };

        }

        public static TrackDocumentEditViewModel ToEditableViewModel(this TrackDocument model)
        {
            return new TrackDocumentEditViewModel()
            {
                ID = model.ID,
                File = model.File,
                Description = model.Description,
                ParentID=model.TrackID
            };
        }

    }
}
