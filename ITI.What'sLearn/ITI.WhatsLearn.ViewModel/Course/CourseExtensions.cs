using ITI.WhatsLearn.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.WhatsLearn.ViewModel
{
    public static class CourseExtensions
    {
        public static CourseViewModel ToViewModel(this Course model)
        {
            return new CourseViewModel
            {
                ID = model.ID,
                Name = model.Name,
                Discription = model.Discription,
                Image = model.Image,
                Documents = model.CourseDocuments.Count()>0? model.CourseDocuments.Select(i => i.ToViewModel()).ToList():null,
                Vedios = model.CourseVedios.Count()>0?model.CourseVedios.Select(i => i.ToViewModel()).ToList():null,
                Links = model.CourseLinks?.Select(i => i.ToViewModel()).ToList(),
                Parent = model.Tracks.Count()>0? model.Tracks.FirstOrDefault().Track.Name:"",
                
                Child = null
            };
        }
        public static Course ToModel(this CourseEditViewModel editModel)
        {
            return new Course
            {
                ID = editModel.ID,
                Name = editModel.Name,
                Discription = editModel.Discription,
                Image = editModel.Image,
                CourseLinks = editModel.Links?.Select(i => i.ToModel()).ToList(),
                CourseDocuments = editModel.Documents?.Select(i => i.ToModel()).ToList(),
                CourseVedios = editModel.Vedios?.Select(i => i.ToModel()).ToList(),
                
                

            };
        }
        public static CourseEditViewModel ToEditableViewModel(this Course model)
        {
            return new CourseEditViewModel
            {
                ID = model.ID,
                Name = model.Name,
                Discription = model.Discription,
                Image = model.Image,
                Links = model.CourseLinks?.Select(i => i.ToEditableViewModel()).ToList(),
                Documents = model.CourseDocuments?.Select(i => i.ToEditableViewModel()).ToList(),
                Vedios = model.CourseVedios?.Select(i => i.ToEditableViewModel()).ToList(),
                Parent = model.Tracks?.FirstOrDefault()?.Track.Name,
                Child = null
            };
        }

    }
}
