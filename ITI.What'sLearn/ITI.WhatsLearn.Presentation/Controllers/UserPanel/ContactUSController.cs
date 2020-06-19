
using ITI.WhatsLearn.Entities;
using ITI.WhatsLearn.Presentation.Hubs;
using ITI.WhatsLearn.ViewModel;
using ITI.WhatsLearnServices;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ITI.WhatsLearn.Presentation.Controllers
{
    public class ContactUSController : ApiController
    {
        MessageService messageService;
        private readonly IHubContext Hub;

        public ContactUSController(MessageService _messageService)
        {
            messageService = _messageService;
            Hub = GlobalHost.ConnectionManager.GetHubContext<WhatsLearnHub>();

        }
        [HttpPost]
        public ResultViewModel<MessageEditViewModel> Post(MessageEditViewModel message)
        {
            ResultViewModel<MessageEditViewModel> result = new ResultViewModel<MessageEditViewModel>();
            try
            {


                if (!ModelState.IsValid)
                {
                    result.Successed = false;
                    result.Message = "Invaild Model State";

                }
                else
                {
                    MessageEditViewModel m = messageService.Add(message);
                    result.Data = m;
                    result.Successed = true;
                    result.Message = "Message Add Successfully";
                    Hub.Clients.All.MessageRecived(new
                    {
                        UserName = message.FullName,
                        PrefMessage = string.Join( " ",message.Text.Split(' ').Take(3)),

                    });


                }
            }
            catch (Exception e)
            {
                result.Successed = false;
                result.Message = "Somting Wrong !";


            }
            return result;

        }
    }
}
