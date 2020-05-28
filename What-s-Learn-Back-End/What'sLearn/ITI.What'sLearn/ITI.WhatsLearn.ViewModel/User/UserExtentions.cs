using ITI.WhatsLearn.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.WhatsLearn.ViewModel
{
    public static class UserExtentions
    {
        public static UserViewModel ToViewModel(this User model)
        {
            return new UserViewModel()
            {
                ID = model.ID,
                Education = model.Education,


                Name = model.Name,
                Adress = model.Adress,
                Age = model.Age,
                Email = model.Email,
                Gender = model.Gender,
                Image = model.Image,
                IsActive = model.IsActive,
                IsDeleted = model.IsDeleted,
                Password = model.Password,
                Phone = model.Phone,
                Tracks=model.Tracks.Select(i=>i.Track.ToViewModel()).ToList()
            };
        }
        public static User ToModel(this UserEditViewModel editModel)
        {
            return new User()
            {
                ID = editModel.ID,
                Education = editModel.Education,
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
        public static UserEditViewModel ToEditableViewModel(this User model)
        {
            return new UserEditViewModel()
            {
                ID = model.ID,
                Education = model.Education,

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
