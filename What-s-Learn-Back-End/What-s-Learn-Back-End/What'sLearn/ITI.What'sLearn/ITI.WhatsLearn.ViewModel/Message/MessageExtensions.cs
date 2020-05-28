using ITI.WhatsLearn.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.WhatsLearn.ViewModel
{
    public static class MessageExtensions
    {
        public static MessageViewModel ToViewModel(this Message model)
        {
            return new MessageViewModel
            {
                ID = model.ID,
                FullName = model.FullName,
                Text = model.Text,
                Email = model.Email,
                SendTime = model.SendTime,
                IsDeleted = model.IsDeleted
            };
        }
        public static Message ToModel(this MessageEditViewModel editModel)
        {
            return new Message
            {
                ID = editModel.ID,
                FullName = editModel.FullName,
                Text = editModel.Text,
                Email = editModel.Email,
                SendTime = editModel.SendTime,
                IsDeleted = editModel.IsDeleted


            };
        }
        public static MessageEditViewModel ToEditableViewModel(this Message model)
        {
            return new MessageEditViewModel
            {
                ID = model.ID,
                FullName = model.FullName,
                Text = model.Text,
                Email = model.Email,
                SendTime = model.SendTime,
                IsDeleted = model.IsDeleted

            };
        }
    }
}
