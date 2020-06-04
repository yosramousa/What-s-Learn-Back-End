using ITI.WhatsLearn.Entities;
using ITI.WhatsLearn.Reposatories;
using ITI.WhatsLearn.ViewModel;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace ITI.WhatsLearn.Services
{

    public class UserService
    {

        UnitOfWork unitOfWork;
        Generic<User> UserRepo;
        Generic<UserCertificate> UserCertificateRepo;
        Generic<UserSkill> UserSkillsRepo;
        Generic<UserSocialLink> UserSocialLinkRepo;

        public UserService(UnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            UserRepo = unitOfWork.UserRepo;
            UserCertificateRepo = unitOfWork.UserCertificateRepo;
            UserSkillsRepo = unitOfWork.UserSkillRepo;
            UserSocialLinkRepo = unitOfWork.UserSocialLinkRepo;
        }
        public UserEditViewModel Add(UserEditViewModel P)
        {
            User PP = UserRepo.Add(P.ToModel());
            unitOfWork.Commit();
            return PP.ToEditableViewModel();
        }
        public UserEditViewModel Update(UserEditViewModel User)
        {
            User user = UserRepo.Update(User.ToModel());
            var links = UserSocialLinkRepo.Get(i => i.UserID == user.ID);
            var certs = UserCertificateRepo.Get(i => i.UserID == user.ID);
            var skills = UserSkillsRepo.Get(i => i.UserID == user.ID);

            foreach (var Cer in user.Certificates)
            {
                if(Cer.ID == 0)  UserCertificateRepo.Add(Cer);
                else if (!certs.Contains(Cer)) UserCertificateRepo.Remove(Cer);
                else UserCertificateRepo.Update(Cer);
            }
            foreach (var skill in user.Skills)
            {
                if (skill.ID == 0) UserSkillsRepo.Add(skill);
                else if (!skills.Contains(skill)) UserSkillsRepo.Remove(skill);
                else UserSkillsRepo.Update(skill);
            }
            foreach (var link in user.SocialLinks)
            {
                if (link.ID == 0) UserSocialLinkRepo.Add(link);
                else if (!links.Contains(link)) UserSocialLinkRepo.Remove(link);
                else UserSocialLinkRepo.Update(link);
            }
            unitOfWork.Commit();

            return user.ToEditableViewModel();


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
        public IEnumerable<UserViewModel> GetAll(out int count ,int SortBy,int pageIndex, int pageSize = 20)
        {
            var query =
                UserRepo.GetAll();
            count = query.Count();

            switch (SortBy)
            {
                case 1:
                    query = query.OrderByDescending(i => i.ID);
                    break;
                case 2:
                    query = query.OrderBy(i => i.Name);
                    break;
                case 3:
                    query = query.OrderByDescending(i => i.Name);
                    break;
                case 4:
                    query = query.OrderBy(i => i.Email);
                    break;

                case 5:
                    query = query.OrderByDescending(i => i.Email);
                    break;
                case 6:
                    query = query.OrderBy(i => i.IsActive);
                    break;

                case 7:
                    query = query.OrderByDescending(i => i.IsActive);
                    break;
                default:
                    query = query.OrderBy(i => i.ID);

                    break;
            }
            query = query.Skip(pageIndex * pageSize).Take(pageSize);
           // query = query.OrderByDescending(i=>i.ID).Skip(pageIndex * pageSize).Take(pageSize);
            return query.ToList().Select(i => i.ToViewModel());
        }
        public IEnumerable<UserViewModel> Get(string Email, string Password)
        {
            var query =
                UserRepo.Get
                    (i => i.Email == Email && i.Password == Password);

            return query.ToList().Select(i => i.ToViewModel());
        }
        public IEnumerable<UserViewModel> SearchByName(out int count ,int SortBy,string Name, int pageIndex=0, int pageSize = 20)
        {
            var query =
                UserRepo.GetAll().Where(i => i.Name.ToLower() == Name.ToLower());
            count = query.Count();

            switch (SortBy)
            {
                case 0:
                    query = query.OrderBy(i => i.ID);
                    break;
                case 1:
                    query = query.OrderByDescending(i => i.ID);
                    break;
                case 2:
                    query = query.OrderBy(i => i.Name);
                    break;
                case 3:
                    query = query.OrderByDescending(i => i.Name);
                    break;
                case 4:
                    query = query.OrderBy(i => i.Email);
                    break;

                case 5:
                    query = query.OrderByDescending(i => i.Email);
                    break;
                case 6:
                    query = query.OrderBy(i => i.IsActive);
                    break;

                case 7:
                    query = query.OrderByDescending(i => i.IsActive);
                    break;
                default:
                    break;
            }
            query = query.Skip(pageIndex * pageSize).Take(pageSize);
            return query.ToList().Select(i => i.ToViewModel());
        }
        public IEnumerable<UserViewModel> SearchByTrackName(out int count, int SortBy, string TrackName, int pageIndex=0, int pageSize = 20)
        {
            var query =
                UserRepo.GetAll().Where
                    (i => i.Tracks.Where(x => x.Track.Name.ToLower() == TrackName.ToLower()).Count() > 0);
            count = query.Count();

            switch (SortBy)
            {
                case 0:
                    query = query.OrderBy(i => i.ID);
                    break;
                case 1:
                    query = query.OrderByDescending(i => i.ID);
                    break;
                case 2:
                    query = query.OrderBy(i => i.Name);
                    break;
                case 3:
                    query = query.OrderByDescending(i => i.Name);
                    break;
                case 4:
                    query = query.OrderBy(i => i.Email);
                    break;

                case 5:
                    query = query.OrderByDescending(i => i.Email);
                    break;
                case 6:
                    query = query.OrderBy(i => i.IsActive);
                    break;

                case 7:
                    query = query.OrderByDescending(i => i.IsActive);
                    break;
                default:
                    break;
            }
            query = query.Skip(pageIndex * pageSize).Take(pageSize);
            return query.ToList().Select(i => i.ToViewModel());
        }
        public void Remove(int id)
        {
            UserRepo.Remove(UserRepo.GetByID(id));


            unitOfWork.Commit();
        }
        public bool ChangeStatus(int id)
        {

            User user = GetByID(id);
            if(user!=null)
            {
                user.IsActive = !user.IsActive;
                unitOfWork.Commit();
                return true;
            }
            else
            {
                return false;
            }
           

        }

        public int Count()
        {
            return UserRepo.Count();
        }

    }
}
