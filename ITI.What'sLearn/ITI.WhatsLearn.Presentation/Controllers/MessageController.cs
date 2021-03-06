﻿using ITI.WhatsLearn.Presentation.Filters;
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
    [AUTHORIZE(Roles = "User,Admin")]

    public class MessageController : ApiController
    {
        private readonly MessageService messageService;
        private readonly IHubContext Hub;

        public MessageController(MessageService _messageService)
        {
            messageService = _messageService;
            Hub = GlobalHost.ConnectionManager.GetHubContext<WhatsLearnHub>();

        }

        [HttpGet]
        public ResultViewModel<IEnumerable<MessageViewModel>> GetAll(int pageIndex, int pageSize = 20)
        {
            ResultViewModel<IEnumerable<MessageViewModel>> result
               = new ResultViewModel<IEnumerable<MessageViewModel>>();
            int count = 0;
            try
            {
                var Messages = messageService.GetAll(out count, 0, pageIndex, pageSize).Where( i=>i.IsDeleted == false);
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


        public ResultViewModel<IEnumerable<MessageViewModel>> GetUnReaded(int pageIndex, int pageSize = 20)
        {
            ResultViewModel<IEnumerable<MessageViewModel>> result
               = new ResultViewModel<IEnumerable<MessageViewModel>>();
            int count = 0;
            try
            {
                var Messages = messageService.GetAll(out count, 0, pageIndex, pageSize).Where(i=>i.IsRead==false&&i.IsDeleted==false);
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
        [HttpPost]
        public ResultViewModel<MessageEditViewModel> Post(MessageEditViewModel Message)
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
                    MessageEditViewModel selectedMessage
                            = messageService.Add(Message);

                    Hub.Clients.All.MessageRecived(new {
                        UserName=Message.FullName,
                        PrefMessage=Message.Text.Substring(0,20),

                    });

                    result.Successed = true;
                    result.Data = selectedMessage;
                    result.Message = "Message Sent...";
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
        public ResultViewModel<MessageViewModel> GetByID(int id)
        {
            ResultViewModel<MessageViewModel> result
                = new ResultViewModel<MessageViewModel>();
            try
            {
                var message = messageService.GetByID(id).ToViewModel();
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
        [HttpPost]
       
        [HttpGet]
        public ResultViewModel<MessageEditViewModel> Update(MessageEditViewModel Message)
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
                    MessageEditViewModel selectedMessage
                        = messageService.Update(Message);
                    result.Successed = true;
                    result.Data = selectedMessage;
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
    }
}
