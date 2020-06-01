using ITI.WhatsLearn.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.WhatsLearn.ViewModel
{
    public static class SubCategoryxtensions
    {
        public static SubCategoryViewModel ToViewModel(this SubCategory model)
        {
            return new SubCategoryViewModel
            {
                ID = model.ID,
                Name = model.Name,
                Discription = model.Discription,
                Image = model.Image,
                Documents = model.SubCategoryDocuments.Select(i => i.ToViewModel()).ToList(),
                Vedios = model.SubCategoryVedios.Select(i => i.ToViewModel()).ToList(),
                Links = model.SubCategoryLinks.Select(i => i.ToViewModel()).ToList(),
                Parent = model.MainCategory.Name,
                ParentID=model.MainCategoryID,
                Childs = model.Tracks.Select(i => i.Name).ToList()
            };
        }
        public static SubCategory ToModel(this SubCategoryEditViewModel editModel)
        {
            return new SubCategory
            {
                ID = editModel.ID,
                Name = editModel.Name,
                Discription = editModel.Discription,
                Image = editModel.Image,
                SubCategoryLinks = editModel.Links.Select(i=>i.ToModel()).ToList(),
                SubCategoryDocuments = editModel.Documents.Select(i => i.ToModel()).ToList(),
                SubCategoryVedios = editModel.Vedios.Select(i => i.ToModel()).ToList(),
                MainCategoryID=editModel.ParentID
            };
        }
        public static SubCategoryEditViewModel ToEditableViewModel(this SubCategory model)
        {
            return new SubCategoryEditViewModel
            {
                ID = model.ID,
                Name = model.Name,
                Discription = model.Discription,
                Image = model.Image,
                Links = model.SubCategoryLinks?.Select(i => i.ToEditableViewModel()).ToArray(),
                Documents = model.SubCategoryDocuments?.Select(i => i.ToEditableViewModel()).ToArray(),
                Vedios = model.SubCategoryVedios?.Select(i => i.ToEditableViewModel()).ToArray(),
                 Parent = model.MainCategory?.Name,
                 ParentID=model.MainCategoryID,
                Child = model.Tracks?.Select(i => i.Name).ToList()
            };
        }
        public static ManageCategoryViewModel ToManageCategoryViewModel(this SubCategoryViewModel model)
        {
            return new ManageCategoryViewModel
            {
                ID = model.ID,
                Name = model.Name,
                Childs = model.Childs,
                Parent = model.Parent,
                Image = model.Image

            };
        }
    }
}
