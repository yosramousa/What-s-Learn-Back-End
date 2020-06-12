using ITI.WhatsLearn.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.WhatsLearn.ViewModel
{
    public static class UserSocialLinkExtentions
    {
        public static UserSocialLinkViewModel ToViewModel(this UserSocialLink model)
        {
            return new UserSocialLinkViewModel()
            {
                ID = model.ID,
                Link = model.link,
                UserName = model.User.Name,
                IsDeleted =model.IsDeleted,
                UserID = model.UserID
            };
        }
        public static UserSocialLink ToModel(this UserSocialLinkEditViewModel editModel)
        {
            return new UserSocialLink()
            {
                ID = editModel.ID,
                link = editModel.Link,
                UserID = editModel.UserID,
                IsDeleted = editModel.IsDeleted
                

            };
        }
        public static UserSocialLinkEditViewModel ToEditableViewModel(this UserSocialLink model)
        {
            return new UserSocialLinkEditViewModel()
            {
                ID = model.ID,

                Link = model.link,
                UserID = model.UserID,
                IsDeleted = model.IsDeleted


            };
        }
    }
}
