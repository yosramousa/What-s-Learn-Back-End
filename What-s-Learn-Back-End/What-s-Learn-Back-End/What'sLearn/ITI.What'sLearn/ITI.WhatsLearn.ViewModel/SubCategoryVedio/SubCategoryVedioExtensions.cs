using ITI.WhatsLearn.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.WhatsLearn.ViewModel
{
   public static class SubCategoryVedioExtensions
    {
        public static  SubCategoryVedioViewModel ToViewModel(this  SubCategoryVedio model)
        {
            return new  SubCategoryVedioViewModel()
            {
                ID = model.ID,
                Vedio = model.Vedio,
                Description = model.Description


            };

        }
        public static  SubCategoryVedio ToModel(this  SubCategoryVedioEditViewModel editmodel)
        {

            return new  SubCategoryVedio()
            {
                ID = editmodel.ID,
                Vedio = editmodel.Vedio,
                Description = editmodel.Description


            };

        }

        public static  SubCategoryVedioEditViewModel ToEditableViewModel(this  SubCategoryVedio model)
        {
            return new  SubCategoryVedioEditViewModel()
            {
                ID = model.ID,
                Vedio = model.Vedio,
                Description = model.Description
            };
        }

    }
}
