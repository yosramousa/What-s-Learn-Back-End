using ITI.WhatsLearn.Presentation.Filters;
using ITI.WhatsLearn.ViewModel;
using ITI.WhatsLearnServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ITI.WhatsLearn.Presentation.Controllers
{
    [AUTHORIZE(Roles = "Admin")]

    public class InboxController : ApiController
    {
        private readonly MessageService messageService;
        public InboxController(MessageService _messageService)
        {
            messageService = _messageService;
        }

        [HttpGet]
        public ResultViewModel<IEnumerable<InboxViewModel>> GetAll(int pageIndex, int pageSize)
        {
            ResultViewModel<IEnumerable<InboxViewModel>> result
               = new ResultViewModel<IEnumerable<InboxViewModel>>();
            int count = 0;
            try
            {
                var Messages = messageService.GetAll(out count, 0, pageIndex, pageSize);
                ;
                result.Successed = true;
                result.Count = count;
                result.Data = Messages.Select(i => new InboxViewModel()
                {
                    FullName = i.FullName,
                    Text = i.Text,
                    ID = i.ID,
                    Email = i.Email,
                    IsReaded = i.IsRead,
                    PriefMessage = String.Join(" ", i.Text.Split(' ').Take(4)),
                    Time = i.SendTime.ToString()
                });


            }
            catch (Exception ex)
            {
                result.Successed = false;
                result.Message = "Something Went Wrong !!";
            }
            return result;
        }

        [HttpGet]
        public ResultViewModel<IEnumerable<MessageViewModel>> GetUnReaded(int pageIndex, int pageSize = 20)
        {
            ResultViewModel<IEnumerable<MessageViewModel>> result
               = new ResultViewModel<IEnumerable<MessageViewModel>>();
            int count = 0;
            try
            {
                var Messages = messageService.GetAll(out count, 0, pageIndex, pageSize).Where(i => i.IsRead == false && i.IsDeleted == false);
                result.Successed = true;
                result.Data = Messages;
            }
            catch (Exception ex)
            {
                result.Successed = false;
                result.Message = "Something Went Wrong !!";
            }
            return result;
        }

        [HttpGet]
        public ResultViewModel<MessageEditViewModel> GetByID(int id)
        {
            ResultViewModel<MessageEditViewModel> result
                = new ResultViewModel<MessageEditViewModel>();
            try
            {
                var message = messageService.GetByID(id);
                result.Successed = true;
                result.Data = message.ToEditableViewModel();
            }
            catch (Exception ex)
            {
                result.Successed = false;
                result.Message = "Something Went Wrong !!";
            }
            return result;
        }


        [HttpGet]
        public ResultViewModel<MessageEditViewModel> Delete(int id)
        {
            ResultViewModel<MessageEditViewModel> result
             = new ResultViewModel<MessageEditViewModel>();

            try
            {
                if (!ModelState.IsValid)
                {
                    result.Message = "In Valid Model State";
                }
                else
                {
                    messageService.Remove(id);
                    result.Successed = true;
                }
            }
            catch (Exception ex)
            {
                result.Successed = false;
                result.Message = "Semething Went Wrong";
            }
            return result;
        }
        [HttpGet]
        public ResultViewModel<IEnumerable<InboxViewModel>> Search(int SortBy, int SearchOption, string SearchText, int pageIndex, int pageSize = 20)
        {
            ResultViewModel<IEnumerable<InboxViewModel>> result
               = new ResultViewModel<IEnumerable<InboxViewModel>>();
            IEnumerable<MessageViewModel> Messages = new List<MessageViewModel>();
            int count = 0;
            try
            {

                if (SearchOption == 0)//All
                {
                    Messages = messageService.GetAll(out count, SortBy, pageIndex, pageSize);

                }


                if (SearchOption == 1)//FullName
                {
                    Messages = messageService.GetByName(out count, SortBy, SearchText, pageIndex, pageSize);

                }

                if (SearchOption == 2)//Email
                {
                    Messages = messageService.GetByEmail(out count, SortBy, SearchText, pageIndex, pageSize);

                }

                //    Messages = messageService.GetAll(out count, SortBy, pageIndex, pageSize).Where(i => i.IsDeleted == false);

                result.Successed = true;
                result.Count = count;

                result.Data = Messages.Select(i => i.ToInboxViewModel());
            }
            catch (Exception ex)
            {
                result.Successed = false;
                result.Message = "Something Went Wrong !!";
            }
            return result;
        }

        [HttpGet]
        public ResultViewModel<MessageEditViewModel> IsSeen(int id)
        {
            ResultViewModel<MessageEditViewModel> result
              = new ResultViewModel<MessageEditViewModel>();

            try
            {
                messageService.ISseen(id);

                result.Successed = true;
                //  result.Data = selectedMessage;

            }
            catch (Exception ex)
            {
                result.Successed = false;
                result.Message = "Semething Went Wrong";
            }
            return result;
        }

    }
}
