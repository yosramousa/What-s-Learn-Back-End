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
    public class UserTrackService
    {

        UnitOfWork unitOfWork;
        Generic<UserTrack> UserTrackRepo;
        public UserTrackService(UnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            UserTrackRepo = unitOfWork.UserTrackRepo;
        }
        public UserTrackEditViewModel Add(UserTrackEditViewModel P)
        {
            UserTrack PP = UserTrackRepo.Add(P.ToModel());
            unitOfWork.Commit();
            return PP.ToEditableViewModel();
        }
        public UserTrackEditViewModel Update(UserTrackEditViewModel P)
        {
            UserTrack PP = UserTrackRepo.Update(P.ToModel());
            unitOfWork.Commit();
            return PP.ToEditableViewModel();
        }
        public UserTrack GetByID(int id)
        {
           
            return UserTrackRepo.GetByID(id);
        }
        public IEnumerable<UserTrackViewModel> GetAll(int pageIndex, int pageSize = 20)
        {
            var query =
                UserTrackRepo.GetAll().OrderBy(i => i.ID).Skip(pageIndex * pageSize).Take(pageSize);
            return query.ToList().Select(i => i.ToViewModel());
        }

        public IEnumerable<UserTrackViewModel> GetAll()
        {
            var query =
                UserTrackRepo.GetAll();
            return query.ToList().Select(i => i.ToViewModel());
        }


        public IEnumerable<UserTrackViewModel> GetEnrollRequest(int pageIndex, int pageSize = 20)
        {
            var query =
                UserTrackRepo.GetAll().Where(i => i.IsApproveed == false).OrderBy(i => i.ID).Skip(pageIndex * pageSize)
                .Take(pageSize);
            
            return query.ToList().Select(i => i.ToViewModel());
        }

        public IEnumerable<UserTrackViewModel> SearchByName(string Name, int pageIndex = 0, int pageSize = 20)
        {
            var query =
                UserTrackRepo.GetAll().Where
                    (i => i.IsApproveed==false && i.User.Name.ToLower()==Name.ToLower());
            query = query.OrderBy(i => i.ID).Skip(pageIndex * pageSize).Take(pageSize);
            return query.ToList().Select(i => i.ToViewModel());
        }
        public IEnumerable<UserTrackViewModel> SearchByTrackName(string TrackName, int pageIndex = 0, int pageSize = 20)
        {
            var query =
                UserTrackRepo.GetAll().Where
                    (i => i.IsApproveed==false&& i.Track.Name.ToLower()==TrackName.ToLower());
            query = query.OrderBy(i => i.ID).Skip(pageIndex * pageSize).Take(pageSize);
            return query.ToList().Select(i => i.ToViewModel());
        }

        public void Approve(int id)
        {

            UserTrack u = GetByID(id);
            if (u != null)
            {
                u.IsApproveed = true;
                unitOfWork.Commit();
            }

        }
        public void Remove(int id)
        {
            if (UserTrackRepo.GetByID(id)!= null)
            {
                UserTrackRepo.Remove(UserTrackRepo.GetByID(id));
                unitOfWork.Commit();
            }
        }

        public int Count()
        {
            return UserTrackRepo.Count();
        }

    }
}
