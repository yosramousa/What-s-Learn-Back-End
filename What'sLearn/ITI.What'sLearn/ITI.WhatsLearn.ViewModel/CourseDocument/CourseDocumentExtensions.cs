using ITI.WhatsLearn.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.WhatsLearn.ViewModel
{
   public static class CourseDocumentExtensions
    {

        public static CourseDocumentViewModel ToViewModel(this CourseDocument model)
        {
            return new CourseDocumentViewModel()
            {
                ID = model.ID,
                File = model.File,
                Description = model.Description


            };

        }
        public static CourseDocument ToModel(this CourseDocumentEditViewModel editmodel)
        {
            return new CourseDocument()
            {
                ID = editmodel.ID,
                File = editmodel.File,
                Description = editmodel.Description


            };

        }

        public static CourseDocumentEditViewModel ToEditableViewModel(this CourseDocument model)
        {
            return new CourseDocumentEditViewModel()
            {
                ID = model.ID,
                File = model.File,
                Description = model.Description
            };
        }

    }
}
