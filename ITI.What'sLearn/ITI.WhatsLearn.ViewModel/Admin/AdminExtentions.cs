using ITI.WhatsLearn.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.WhatsLearn.ViewModel
{
    public static class AdminExtentions
    {
        public static AdminViewModel ToViewModel(this Admin model)
        {
            return new AdminViewModel()
            {
                ID = model.ID,
                Name = model.Name,
                Adress = model.Adress,
                Age = model.Age,
                Email = model.Email,
                Gender = model.Gender,
                Image = model.Image,
                IsActive = model.IsActive,
                IsDeleted = model.IsDeleted,
                Password = model.Password,
                Phone = model.Phone
            };
        }
        public static Admin ToModel(this AdminEditViewModel editModel)
        {
            return new Admin()
            {

                ID = editModel.ID,
                Name = editModel.Name,
                Adress = editModel.Adress,
                Age = editModel.Age,
                Email = editModel.Email,
                Gender = editModel.Gender,
                Image = editModel.Image,
                IsActive = editModel.IsActive,
                IsDeleted = editModel.IsDeleted,
                Password = editModel.Password,
                Phone = editModel.Phone
            };
        }
        public static AdminEditViewModel ToEditableViewModel(this Admin model)
        {
            return new AdminEditViewModel
            {

                ID = model.ID,
                Name = model.Name,
                Adress = model.Adress,
                Age = model.Age,
                Email = model.Email,
                Gender = model.Gender,
                Image = model.Image,
                IsActive = model.IsActive,
                IsDeleted = model.IsDeleted,
                Password = model.Password,
                Phone = model.Phone
            };
        }
    }
}
