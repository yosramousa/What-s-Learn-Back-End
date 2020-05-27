using ITI.WhatsLearn.Entities;
using ITI.WhatsLearn.Reposatories;
using ITI.WhatsLearn.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ITI.WhatsLearnServices
{
    public class MessageService
    {
        UnitOfWork unitOfWork;
        Generic<Message> MessageRepo;
        public MessageService(UnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            MessageRepo = unitOfWork.MessageRepo;
        }
        public MessageEditViewModel Add(MessageEditViewModel Message)
        {
            Message c = MessageRepo.Add(Message.ToModel());
            unitOfWork.Commit();
            return c.ToEditableViewModel();
        }
        public MessageEditViewModel Update(MessageEditViewModel Message)
        {
            Message c = MessageRepo.Update(Message.ToModel());
            unitOfWork.Commit();
            return c.ToEditableViewModel();
        }
        public MessageViewModel GetByID(int id)
        {
            return MessageRepo.GetByID(id)?.ToViewModel();
        }
        public IEnumerable<MessageViewModel> GetAll( int pageIndex, int pageSize = 20)
        {
            var query =
                MessageRepo.GetAll();
            query = query.Skip(pageIndex * pageSize).Take(pageSize);
            return query.ToList().Select(i => i.ToViewModel());
        }
        public IEnumerable<MessageViewModel> Get(Expression<Func<Message, bool>> filter)
        {
            var query =
                MessageRepo.Get(filter);
            return query.ToList().Select(i => i.ToViewModel());
        }
        public void Remove(int id)
        {
            MessageRepo.Remove(MessageRepo.GetByID(id));
            unitOfWork.Commit();

        }
    }
}
