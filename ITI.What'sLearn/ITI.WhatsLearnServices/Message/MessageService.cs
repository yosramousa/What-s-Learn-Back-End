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
        public Message GetByID(int id)
        {
            return MessageRepo.GetByID(id);
        }
        public IEnumerable<MessageViewModel> GetAll( out int count , int SortBy , int pageIndex, int pageSize = 20)
        {
            var query =
                MessageRepo.GetAll();

            count = query.Count();

            switch (SortBy)
            {
                 case 1:
                    query = query.OrderBy(i => i.ID);
                    break;
                case 2:
                    query = query.OrderBy(i => i.FullName);
                    break;
                case 3:
                    query = query.OrderByDescending(i => i.FullName);
                    break;
                case 4:
                    query = query.OrderBy(i => i.Email);
                    break;
                case 5:
                    query = query.OrderByDescending(i => i.Email);
                    break;

                default:
                    query = query.OrderByDescending(i => i.ID);

                    break;
            }
            query = query.Skip(pageIndex * pageSize).Take(pageSize).OrderBy(i => i.IsRead);
            return query.ToList().Select(i => i.ToViewModel());
        }

        public IEnumerable<MessageViewModel> GetByName(out int count,int SortBy,string SearchText, int pageIndex, int pageSize = 20)
        {

            var query =
                MessageRepo.GetAll().Where(i => i.FullName.Contains(SearchText));
            count = query.Count();

            switch (SortBy)
            {
                case 0:
                    query = query.OrderByDescending(i => i.ID);
                    break;
                case 1:
                    query = query.OrderBy(i => i.ID);
                    break;
                case 2:
                    query = query.OrderBy(i => i.FullName);
                    break;
                case 3:
                    query = query.OrderByDescending(i => i.FullName);
                    break;
                case 4:
                    query = query.OrderBy(i => i.SendTime);
                    break;
                case 5:
                    query = query.OrderByDescending(i => i.SendTime);
                    break;

                default:
                    break;
            }

            query = query.OrderBy(i => i.ID).Skip(pageIndex * pageSize).Take(pageSize);
            return query.ToList().Select(i => i.ToViewModel());
        }
        public IEnumerable<MessageViewModel> GetByEmail(out int count,int SortBy,string SearchText,int pageIndex, int pageSize = 20)
        {
            var query =
                MessageRepo.GetAll().Where(i=>i.FullName.Contains(SearchText));
            count = query.Count();

            switch (SortBy)
            {
                case 0:
                    query = query.OrderByDescending(i => i.ID);
                    break;
                case 1:
                    query = query.OrderBy(i => i.ID);
                    break;
                case 2:
                    query = query.OrderBy(i => i.FullName);
                    break;
                case 3:
                    query = query.OrderByDescending(i => i.FullName);
                    break;
                case 4:
                    query = query.OrderBy(i => i.SendTime);
                    break;
                case 5:
                    query = query.OrderByDescending(i => i.SendTime);
                    break;

                default:
                    break;
            }

            query = query.OrderBy(i => i.ID).Skip(pageIndex * pageSize).Take(pageSize);
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

        public int Count()
        {
            return MessageRepo.Count();
        }

        public bool ISseen(int id)
        {

            Message m = GetByID(id);
            if ( m!= null)
            {
                m.IsRead = true;
               // Update(m);
                unitOfWork.Commit();
                return true;
            }
            return false;


        }
    }
}
