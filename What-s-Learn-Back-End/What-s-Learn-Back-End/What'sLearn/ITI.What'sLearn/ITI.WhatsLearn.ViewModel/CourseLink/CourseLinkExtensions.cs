using ITI.WhatsLearn.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.WhatsLearn.ViewModel
{
   public static  class CourseLinkExtensions
    {
        public static CourseLinkViewModel ToViewModel(this  CourseLink model)
        {
            return new CourseLinkViewModel()
            {
                ID = model.ID,
                Link = model.Link,
                Description = model.Description,
                ParentID=model.CourseID


            };

        }
        public static  CourseLink ToModel(this  CourseLinkEditViewModel editmodel)
        {
            return new  CourseLink()
            {
                ID = editmodel.ID,
                Link = editmodel.Link,
                Description = editmodel.Description,
                CourseID=editmodel.ParentID


            };

        }
        public static  CourseLinkEditViewModel ToEditableViewModel(this  CourseLink model)
        {
            return new  CourseLinkEditViewModel()
            {
                ID = model.ID,
                Link = model.Link,
                Description = model.Description,
                ParentID=model.CourseID
            };
        }

    }
}
