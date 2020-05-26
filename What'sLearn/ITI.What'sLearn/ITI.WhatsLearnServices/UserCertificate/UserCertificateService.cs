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
            return PP.ToEditViewModel();
        }
        public UserEditViewModel Update(UserEditViewModel P)
        {
            User PP = UserRepo.Update(P.ToModel());
            unitOfWork.Commit();
            return PP.ToEditViewModel();
        }
        public User GetByID(int id)
        {
            return UserRepo.GetByID(id);
        }
        public IEnumerable<UserViewModel> GetAll(){
            var query =
                UserRepo.GetAll();
               
            return query.ToList().Select(i => i.ToViewModel());
        }
        public IEnumerable<UserViewModel> Get(int id, string name, string email, int pageIndex, int pageSize = 20)
        {
            var query =
                UserRepo.Get
                    (i => i.ID == id || i.Name == name || i.Email == email);
            query = query.Skip(pageIndex * pageSize).Take(pageSize);
            return query.ToList().Select(i => i.ToViewModel());
        }
        public void Remove(int id)
        {
            UserRepo.Remove(UserRepo.GetByID(id));
            unitOfWork.Commit();
        }
    
    }
}
