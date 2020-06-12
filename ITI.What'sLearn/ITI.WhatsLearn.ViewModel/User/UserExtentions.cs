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
                Skills = model.Skills?.Select(i => i.ToEditableViewModel()).ToList(),
                Certificates = model.Certificates?.Select(i => i.ToEditableViewModel()).ToList(),
                SocialLinks = model.SocialLinks?.Select(i => i.ToEditableViewModel()).ToList()

            };
        }

        public static UserProfileViewModel ToUserProfileViewModel(this User model)
        {
            return new UserProfileViewModel()
            {
                ID = model.ID,
                Name = model.Name,
                Adress = model.Adress,
                Age = model.Age,
                Education = model.Education,
                Gender = model.Gender,
                Phone = model.Phone,
                Image = model.Image,
                Skills = model.Skills.Select(i => i.ToViewModel()).Where(i=>!i.IsDeleted).ToList(),
                Certificates = model.Certificates.Select(i => i.ToViewModel()).Where(i => !i.IsDeleted).ToList(),
                Links = model.SocialLinks.Select(i => i.ToViewModel()).Where(i => !i.IsDeleted).ToList(),
                Tracks = model.Tracks.Where(i => !i.IsDeleted && i.IsApproveed && i.Track.Courses.Count > i.FinishedCourses.Count).Select(i => i.ToUserProfileTracksViewModel()).ToList(),
                FinishedTracks = model.Tracks.Where(i => i.Track.Courses.Count == i.FinishedCourses.Count && !i.IsDeleted).Select(i => i.ToFinishedTracks()).ToList()

            };

        }
      
        public static UserProfileEditViewModel ToUserProfileEditViewModel(this UserEditViewModel model)
        {
            return new UserProfileEditViewModel()
            {
                ID = model.ID,
                Name = model.Name,
                Adress = model.Adress,
                Age = model.Age,
                Education = model.Education,
                Gender = model.Gender,
                Phone = model.Phone,
                Image = model.Image,
                Email =model.Email,
                Password = model.Password
               
            };

        }


        public static UserEditViewModel ToUserEditViewModel(this UserProfileEditViewModel model)
        {
            return new UserEditViewModel()
            {
                ID = model.ID,
                Name = model.Name,
                Adress = model.Adress,
                Age = model.Age,
                Education = model.Education,
                Gender = model.Gender,
                Phone = model.Phone,
                Image = model.Image,
                Password = model.Password,
                Email = model.Email

            };

        }



    }
}
