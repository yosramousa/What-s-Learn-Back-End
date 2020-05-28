using ITI.WhatsLearn.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.WhatsLearn.ViewModel
{
   public static class CoursekVedioExtensions
    {
        public static  CourseVedioViewModel ToViewModel(this  CourseVedio model)
        {
            return new  CourseVedioViewModel()
            {
                ID = model.ID,
                Vedio = model.Vedio,
                Description = model.Description


            };

        }
        public static  CourseVedio ToModel(this  CourseVedioEditViewModel editmodel)
        {

            return new  CourseVedio()
            {
                ID = editmodel.ID,
                Vedio = editmodel.Vedio,
                Description = editmodel.Description


            };

        }

        public static  CourseVedioEditViewModel ToEditableViewModel(this  CourseVedio model)
        {
            return new  CourseVedioEditViewModel()
            {
                ID = model.ID,
                Vedio = model.Vedio,
                Description = model.Description
            };
        }

    }
}
