using ITI.WhatsLearn.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.WhatsLearn.ViewModel
{
    public static class TrackExtensions
    {
        public static TrackViewModel ToViewModel(this Track model)
        {
            return new TrackViewModel
            {
                ID = model.ID,
                Name = model.Name,
                Discription = model.Discription,
                Image = model.Image,
                Documents = model.TrackDocuments.Select(i => i.ToViewModel()).ToArray(),
                Vedios = model.TrackVedios.Select(i => i.ToViewModel()).ToArray(),
                Links = model.TrackLinks.Select(i => i.ToViewModel()).ToArray(),
                SubCategoryName = model.SubCategory?.Name,
                Parent = model.SubCategory.Name,
                ParentID=model.SubCategoryID,
                Childs = model.Courses.Select(i => i.Course.Name).ToList()
            };
        }
        public static Track ToModel(this TrackEditViewModel editModel)
        {
            return new Track
            {
                ID = editModel.ID,
                Name = editModel.Name,
                Discription = editModel.Discription,
                Image = editModel.Image,
                TrackLinks = editModel.Links.Select(i => i.ToModel()).ToList(),
                TrackDocuments = editModel.Documents.Select(i => i.ToModel()).ToList(),
                TrackVedios = editModel.Vedios.Select(i => i.ToModel()).ToList(),
                SubCategoryID = editModel.ParentID
            };
        }
        public static TrackEditViewModel ToEditableViewModel(this Track model)
        {
            return new TrackEditViewModel
            {
                ID = model.ID,
                Name = model.Name,
                Discription = model.Discription,
                Image = model.Image,
                Links = model.TrackLinks.Count()>0 ? model.TrackLinks.Select(i => i.ToEditableViewModel()).ToArray():null,
                Documents = model.TrackDocuments.Count()>0 ? model.TrackDocuments.Select(i => i.ToEditableViewModel()).ToArray():null,
                Vedios = model.TrackVedios.Count()>0? model.TrackVedios.Select(i => i.ToEditableViewModel())?.ToArray():null,
                ParentID = model.SubCategoryID,
                Parent = model.SubCategory!=null? model.SubCategory.Name:"",
                Childs = model.Courses.Count()>0? model.Courses.Select(i => i.Course.Name).ToList():null

            };
        }
        public static ManageCategoryViewModel ToManageCategoryViewModel(this TrackViewModel model)
        {
            return new ManageCategoryViewModel
            {
                ID = model.ID,
                Name = model.Name,
                Childs = model.Childs,
                Parent = model.Parent,
                Image = model.Image,
                Users=model.Users

            };
        }

    }
}
