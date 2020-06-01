using ITI.WhatsLearn.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ITI.WhatsLearn.ViewModel
{
    public static class MainCategoryExtensions

    {
        public static MainCategoryViewModel ToViewModel(this MainCategory model)
        {
            return new MainCategoryViewModel
            {
                ID = model.ID,
                Name = model.Name,
                Discription = model.Discription,
                Image = model.Image,
                Parent = "Main Category Parent",
                Documents = model.MainCategoryDocuments.Select(i => i.ToViewModel()).ToList(),
                Vedios = model.MainCategoryVedios.Select(i => i.ToViewModel()).ToList(),
                Links = model.MainCategoryLinks.Select(i => i.ToViewModel()).ToList(),



                Childs = model.SubCategories.Select(i => i.Name).ToList()

            };
        }
        public static MainCategory ToModel(this MainCategoryEditViewModel editModel)
        {
            return new MainCategory
            {
                ID = editModel.ID,
                Name = editModel.Name,
                Discription = editModel.Discription,
                Image = editModel.Image,
                MainCategoryLinks = editModel.Links.Select(i => i.ToModel()).ToList(),
                MainCategoryDocuments = editModel.Documents.Select(i => i.ToModel()).ToList(),
                MainCategoryVedios = editModel.Vedios.Select(i => i.ToModel()).ToList()
            };
        }
        public static MainCategoryEditViewModel ToEditableViewModel(this MainCategory model)
        {
            return new MainCategoryEditViewModel
            {
                ID = model.ID,
                Name = model.Name,
                Discription = model.Discription,
                Image = model.Image,
                Links = model.MainCategoryLinks.Select(i => i.ToEditableViewModel()).ToArray(),
                Documents = model.MainCategoryDocuments.Select(i => i.ToEditableViewModel()).ToArray(),
                Vedios = model.MainCategoryVedios.Select(i => i.ToEditableViewModel()).ToArray(),
                Parent = null,
                Child = model.SubCategories?.Select(i => i.Name).ToList()
            };
        }
        public static ManageCategoryViewModel ToManageCategoryViewModel(this MainCategoryViewModel model)
        {
            return new ManageCategoryViewModel
            {
                ID = model.ID,
                Name = model.Name,
                Childs = model.Childs,
                Parent = "Main Category Parent",
                Image = model.Image

            };
        }


    }
}
