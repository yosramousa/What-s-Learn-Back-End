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
    public class UserSocialLinkService
    {
        
        UnitOfWork unitOfWork;
        Generic<UserSocialLink> UserSocialLinkRepo;
        public UserSocialLinkService(UnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            UserSocialLinkRepo = unitOfWork.UserSocialLinkRepo;
        }
        public UserSocialLinkEditViewModel Add(UserSocialLinkEditViewModel P)
        {
            UserSocialLink PP = UserSocialLinkRepo.Add(P.ToModel());
            unitOfWork.Commit();
            return PP.ToEditViewModel();
        }
        public UserSocialLinkEditViewModel Update(UserSocialLinkEditViewModel P)
        {
            UserSocialLink PP = UserSocialLinkRepo.Update(P.ToModel());
            unitOfWork.Commit();
            return PP.ToEditViewModel();
        }
        public UserSocialLink GetByID(int id)
        {
            return UserSocialLinkRepo.GetByID(id);
        }
        public IEnumerable<UserSocialLinkViewModel> GetAll(){
            var query =
                UserSocialLinkRepo.GetAll();
               
            return query.ToList().Select(i => i.ToViewModel());
        }
        public IEnumerable<UserSocialLinkViewModel> Get(int id, string link, string username, int pageIndex, int pageSize = 20)
        {
            var query =
                UserSocialLinkRepo.Get
                    (i => i.ID == id || i.link == link || i.User.Name == username);
            query = query.Skip(pageIndex * pageSize).Take(pageSize);
            return query.ToList().Select(i => i.ToViewModel());
        }
        public void Remove(int id)
        {
            UserSocialLinkRepo.Remove(UserSocialLinkRepo.GetByID(id));
            unitOfWork.Commit();
        }
    
    }
}
