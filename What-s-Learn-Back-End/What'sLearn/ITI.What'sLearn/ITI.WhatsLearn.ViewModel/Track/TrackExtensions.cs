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
                Child = model.Courses.Select(i => i.Course.Name).ToList()
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
                TrackVedios = editModel.Videos.Select(i => i.ToModel()).ToList(),
                SubCategoryID = editModel.SubCategoryID
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
                Links = model.TrackLinks.Select(i => i.ToEditableViewModel()).ToArray(),
                Documents = model.TrackDocuments.Select(i => i.ToEditableViewModel()).ToArray(),
                Videos = model.TrackVedios.Select(i => i.ToEditableViewModel()).ToArray(),
                SubCategoryID = model.SubCategoryID,
                Parent = model.SubCategory.Name,
                Child = model.Courses.Select(i => i.Course.Name).ToList()

            };
        }

    }
}
