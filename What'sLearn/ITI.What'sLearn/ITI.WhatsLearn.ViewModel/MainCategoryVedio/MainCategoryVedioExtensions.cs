using ITI.WhatsLearn.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.WhatsLearn.ViewModel
{
    public static class MainCategoryVedioExtensions
    {
        public static MainCategoryVedioViewModel ToViewModel(this MainCategoryVedio model)
        {
            return new MainCategoryVedioViewModel()
            {
                ID = model.ID,
                Vedio = model.Vedio,
                Description = model.Description


            };

        }
        public static MainCategoryVedio ToModel(this MainCategoryVedioEditViewModel editmodel)
        {

            return new MainCategoryVedio()
            {
                ID = editmodel.ID,
                Vedio = editmodel.Vedio,
                Description = editmodel.Description


            };

        }

        public static MainCategoryVedioEditViewModel ToEditableViewModel(this MainCategoryVedio model)
        {
            return new MainCategoryVedioEditViewModel()
            {
                ID = model.ID,
                Vedio = model.Vedio,
                Description = model.Description
            };
        }
    }
}
