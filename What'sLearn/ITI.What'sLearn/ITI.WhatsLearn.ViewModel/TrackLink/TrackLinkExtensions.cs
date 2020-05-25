using ITI.WhatsLearn.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.WhatsLearn.ViewModel
{
   public static  class TrackLinkExtensions
    {
        public static TrackLinkViewModel ToViewModel(this  TrackLink model)
        {
            return new TrackLinkViewModel()
            {
                ID = model.ID,
                Link = model.Link,
                Description = model.Description


            };

        }
        public static  TrackLink ToModel(this  TrackLinkEditViewModel editmodel)
        {
            return new  TrackLink()
            {
                ID = editmodel.ID,
                Link = editmodel.Link,
                Description = editmodel.Description


            };

        }
        public static  TrackLinkEditViewModel ToEditableViewModel(this  TrackLink model)
        {
            return new  TrackLinkEditViewModel()
            {
                ID = model.ID,
                Link = model.Link,
                Description = model.Description
            };
        }

    }
}
