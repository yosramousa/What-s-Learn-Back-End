using ITI.WhatsLearn.Entities;
using ITI.WhatsLearn.Reposatories;
using ITI.WhatsLearn.ViewModel;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.WhatsLearn.Services
{
    public class UserService
    {

        UnitOfWork unitOfWork;
        Generic<User> UserRepo;
        public UserService(UnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            UserRepo = unitOfWork.UserRepo;
        }
        public UserEditViewModel Add(UserEditViewModel P)
        {
            User PP = UserRepo.Add(P.ToModel());
            unitOfWork.Commit();
            return PP.ToEditableViewModel();
        }
        public UserEditViewModel Update(UserEditViewModel P)
        {
            User PP = UserRepo.Update(P.ToModel());
            unitOfWork.Commit();
            return PP.ToEditableViewModel();
        }
        public User GetByID(int id)
        {
            return UserRepo.GetByID(id);
        }
        public IEnumerable<UserViewModel> GetAll()
        {
            var query =
                UserRepo.GetAll();

            return query.ToList().Select(i => i.ToViewModel());
        }
        public IEnumerable<UserViewModel> Get(int id, string skill, string Username, int pageIndex, int pageSize = 20)
        {
            var query =
                UserRepo.Get
                    (i => i.ID == id);
            query = query.Skip(pageIndex * pageSize).Take(pageSize);
            return query.ToList().Select(i => i.ToViewModel());
        }
        public void Remove(int id)
        {
            UserRepo.GetByID(id);
            unitOfWork.Commit();
        }

    }
}
