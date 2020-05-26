﻿using ITI.WhatsLearn.Entities;
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
                Documents = model.MainCategoryDocuments.Select(i => i.ToViewModel()).ToArray(),
                Vedios = model.MainCategoryVedios.Select(i => i.ToViewModel()).ToArray(),
                Links = model.MainCategoryLinks.Select(i => i.ToViewModel()).ToArray(),
                SubCategories=model.SubCategories.Select(i => i.ToViewModel()).ToArray()
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
                MainCategoryDocuments=editModel.Documents.Select(i=>i.ToModel()).ToList(),
                MainCategoryVedios = editModel.Vedios.Select(i => i.ToModel()).ToList()
            };
        }
        public static MainCategoryEditViewModel ToEditableViewModel(this MainCategory model)
        {
            return new MainCategoryEditViewModel
            {
                ID = model.ID,
                Name = model.Name,
                Discription=model.Discription,
                Image=model.Image,
                Links=model.MainCategoryLinks.Select(i=>i.ToEditableViewModel()).ToArray(),
                Documents = model.MainCategoryDocuments.Select(i => i.ToEditableViewModel()).ToArray(),
                Vedios = model.MainCategoryVedios.Select(i => i.ToEditableViewModel()).ToArray()
            };
        }


    }
}