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
    public class InboxController : ApiController
    {
        private readonly MessageService messageService;
        public InboxController(MessageService _messageService)
        {
            messageService = _messageService;
        }

        [HttpGet]
        public ResultViewModel<IEnumerable<InboxViewModel>> GetAll(int pageIndex, int pageSize )
        {
            ResultViewModel<IEnumerable<InboxViewModel>> result
               = new ResultViewModel<IEnumerable<InboxViewModel>>();

            try
            {
                var Messages = messageService.GetAll(pageIndex, pageSize).Where(i => i.IsDeleted == false)
                    ;
                result.Successed = true;
                result.Data = Messages.Select(i=>new InboxViewModel()
                {
                    FullName = i.FullName,
                    Text = i.Text,
                    ID = i.ID,
                    Email = i.Email,
                    IsReaded =i.IsRead,
                    Time = (DateTime.Now -i.SendTime  ).TotalMinutes.ToString()
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

            try
            {
                var Messages = messageService.GetAll(pageIndex, pageSize).Where(i => i.IsRead == false && i.IsDeleted == false);
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
        public ResultViewModel<MessageViewModel> GetByID(int id)
        {
            ResultViewModel<MessageViewModel> result
                = new ResultViewModel<MessageViewModel>();
            try
            {
                var message = messageService.GetByID(id);
                result.Successed = true;
                result.Data = message;
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
        public ResultViewModel<IEnumerable<InboxViewModel>> Search(int SearchOption,string SearchText, int pageIndex, int pageSize = 20)
        {
            ResultViewModel<IEnumerable<InboxViewModel>> result
               = new ResultViewModel<IEnumerable<InboxViewModel>>();
            IEnumerable<MessageViewModel> Messages = new List<MessageViewModel>();
            try
            {

                if(SearchOption == 0)//All
                {
                     Messages = messageService.GetAll(pageIndex, pageSize);

                }


                if (SearchOption == 1)//FullName
                {
                    Messages = messageService.GetByName(SearchText,pageIndex, pageSize);

                }

                if (SearchOption == 2)//Email
                {
                    Messages = messageService.GetByEmail(SearchText, pageIndex, pageSize);

                }

                Messages = messageService.GetAll(pageIndex, pageSize).Where(i => i.IsDeleted == false);
                    
                result.Successed = true;
                result.Data = Messages.Select(i => new InboxViewModel()
                {
                    FullName = i.FullName,
                    Text = i.Text,
                    ID = i.ID,
                    IsReaded = i.IsRead,
                    Time = (i.SendTime - DateTime.Now).ToString()
                });

            }
            catch (Exception ex)
            {
                result.Successed = false;
                result.Message = "Something Went Wrong !!";
            }
            return result;
        }


    }
}
