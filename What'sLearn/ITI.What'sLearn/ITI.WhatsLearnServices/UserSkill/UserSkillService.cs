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
    public class UserSkillService
    {
        
        UnitOfWork unitOfWork;
        Generic<UserSkill> UserSkillRepo;
        public UserSkillService(UnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            UserSkillRepo = unitOfWork.UserSkillRepo;
        }
        public UserSkillEditViewModel Add(UserSkillEditViewModel P)
        {
            UserSkill PP = UserSkillRepo.Add(P.ToModel());
            unitOfWork.Commit();
            return PP.ToEditViewModel();
        }
        public UserSkillEditViewModel Update(UserSkillEditViewModel P)
        {
            UserSkill PP = UserSkillRepo.Update(P.ToModel());
            unitOfWork.Commit();
            return PP.ToEditViewModel();
        }
        public UserSkill GetByID(int id)
        {
            return UserSkillRepo.GetByID(id);
        }
        public IEnumerable<UserSkillViewModel> GetAll(){
            var query =
                UserSkillRepo.GetAll();
               
            return query.ToList().Select(i => i.ToViewModel());
        }
        public IEnumerable<UserSkillViewModel> Get(int id, string skill, string username, int pageIndex, int pageSize = 20)
        {
            var query =
                UserSkillRepo.Get
                    (i => i.ID == id || i.Skill.skill == skill || i.User.Name == username);
            query = query.Skip(pageIndex * pageSize).Take(pageSize);
            return query.ToList().Select(i => i.ToViewModel());
        }
        public void Remove(int id)
        {
            UserSkillRepo.Remove(UserSkillRepo.GetByID(id));
            unitOfWork.Commit();
        }
    
    }
}
