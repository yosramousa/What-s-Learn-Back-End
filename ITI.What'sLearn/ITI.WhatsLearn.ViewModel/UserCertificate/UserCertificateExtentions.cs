using ITI.WhatsLearn.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.WhatsLearn.ViewModel
{
    public static class UserCertificateExtentions
    {
        public static UserCertificateViewModel ToViewModel(this UserCertificate model)
        {
            return new UserCertificateViewModel()
            {
               ID = model.ID,
               Title=model.Title,
               UserName=model.User.Name,
               IsDeleted = model.IsDeleted,
               Image =model.Image,
               UserID = model.UserID

            };
        }
        public static UserCertificate ToModel(this UserCertificateEditViewModel editModel)
        {
            return new UserCertificate()
            {
                ID = editModel.ID,
               Title=editModel.Title,
               UserID=editModel.UserID,
               IsDeleted =editModel.IsDeleted,
               Image = editModel.Image
            };
        }
        public static UserCertificateEditViewModel ToEditableViewModel(this UserCertificate model)
        {
            return new UserCertificateEditViewModel()
            {
                ID = model.ID,
                Title=model.Title,
                UserID=model.UserID,
                IsDeleted =model.IsDeleted,
                Image = model.Image
                

            };
        }
    }
}
