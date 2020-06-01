using ITI.WhatsLearn.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.WhatsLearn.ViewModel
{
   public static class TrackVedioExtensions
    {
        public static  TrackVedioViewModel ToViewModel(this  TrackVedio model)
        {
            return new  TrackVedioViewModel()
            {
                ID = model.ID,
                Vedio = model.Vedio,
                Description = model.Description


            };

        }
        public static  TrackVedio ToModel(this  TrackVedioEditViewModel editmodel)
        {

            return new  TrackVedio()
            {
                ID = editmodel.ID,
                Vedio = editmodel.Vedio,
                Description = editmodel.Description


            };

        }

        public static  TrackVedioEditViewModel ToEditableViewModel(this  TrackVedio model)
        {
            return new  TrackVedioEditViewModel()
            {
                ID = model.ID,
                Vedio = model.Vedio,
                Description = model.Description
            };
        }

    }
}
