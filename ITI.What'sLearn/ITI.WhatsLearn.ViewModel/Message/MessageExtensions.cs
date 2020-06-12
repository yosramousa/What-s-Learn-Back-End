using ITI.WhatsLearn.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
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
                IsDeleted = model.IsDeleted,
                Subject = model.Subject
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
                IsDeleted = editModel.IsDeleted,
                Subject = editModel.Subject

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
                IsDeleted = model.IsDeleted,
                Subject=model.Subject

            };
        }

        public static InboxViewModel ToInboxViewModel(this MessageViewModel model) 
        {
            TimeSpan span = ( DateTime.Now- model.SendTime );
            string time =
            String.Format("{0} days, {1} hours, {2} minutes, {3} seconds",
                span.Days, span.Hours, span.Minutes, span.Seconds);

            return new InboxViewModel()
            {
                Email = model.Email,
                FullName = model.FullName,
                ID = model.ID,
                PriefMessage = String.Join(" ", model.Text.Split(' ').Take(4)),
                Text = model.Text,
                IsReaded = model.IsRead,
                Time = time

            };
        }
    }
}
