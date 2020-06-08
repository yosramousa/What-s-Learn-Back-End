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
                SignedTime = model.SignedTime,
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
                Tracks = model.Tracks.Select(i => i.Track.ToViewModel()).ToList(),
                Skills = model.Skills.Select(i=>i.ToViewModel()).ToList(),
                Certificates =model.Certificates.Select(i => i.ToViewModel()).ToList(),
                SocialLinks = model.SocialLinks.Select(i=>i.ToViewModel()).ToList()
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
                Phone = editModel.Phone,
                SignedTime = editModel.SignedTime,
                Certificates = editModel.Certificates?.Select(i=>i.ToModel()).ToList(),
                SocialLinks = editModel.SocialLinks?.Select(i=>i.ToModel()).ToList(),
                Skills = editModel.Skills?.Select(i=>i.ToModel()).ToList()
              
            };
        }
        public static UserEditViewModel ToEditableViewModel(this User model)
        {
            return new UserEditViewModel()
            {
                ID = model.ID,
                Education = model.Education,
                SignedTime = model.SignedTime,

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
                Skills = model.Skills.Select(i => i.ToEditableViewModel()).ToList(),
                Certificates = model.Certificates.Select(i => i.ToEditableViewModel()).ToList(),
                SocialLinks = model.SocialLinks.Select(i => i.ToEditableViewModel()).ToList()

            };
        }
    }
}
